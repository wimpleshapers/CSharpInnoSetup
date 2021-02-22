
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using CodingMuscles.CSharpInnoSetup.Generation.Visitor;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a lambda <see cref="Expression"/> that calls a method of prototype <typeparamref name="TMethod"/>
    /// </summary>
    /// <typeparam name="TMethod">The delegate type</typeparam>
    internal class DelegateExpressionToStringConverter<TMethod> : ToStringConverter<Expression<TMethod>> where TMethod : Delegate
    {
        private readonly Action<MethodInfo> _visitMethodHandler;
        private readonly string _methodCallFormat = "{0}({1})";
        private readonly bool _quoteStrings = true;

        /// <summary>
        /// Initializes a new <see cref="DelegateExpressionToStringConverter{T}"/>
        /// </summary>
        /// <param name="visitMethodHandler">Called when a user defined (not built-in) method is encountered</param>
        public DelegateExpressionToStringConverter(Action<MethodInfo> visitMethodHandler)
        {
            _visitMethodHandler = visitMethodHandler ?? (mi => { });
        }

        /// <summary>
        /// Initializes a new <see cref="DelegateExpressionToStringConverter{T}"/>
        /// </summary>
        /// <param name="visitMethodHandler">Called when a user defined (not built-in) method is encountered</param>
        /// <param name="methodCallFormat">String used to format the method call (e.g., test(1) or test|1)</param>
        /// <param name="quotedStrings">True if string parameters should be quoted</param>
        public DelegateExpressionToStringConverter(
            Action<MethodInfo> visitMethodHandler, 
            string methodCallFormat,
            bool quotedStrings) : this(visitMethodHandler)
        {
            _visitMethodHandler = visitMethodHandler ?? (mi => { });
            _methodCallFormat = methodCallFormat;
            _quoteStrings = quotedStrings;
        }

        public DelegateExpressionToStringConverter() : this(null)
        {
        }

        /// <inheritdoc/>
        protected override string Convert(Expression<TMethod> expression)
        {
            var visitor = new DelegateVisitor(this, 1);
            visitor.Visit(expression.Body);

            return visitor.Resolution;
        }

        class DelegateVisitor : ExpressionVisitor
        {
            private readonly int _methodDepth;
            private readonly object _objectInstance;
            private readonly DelegateExpressionToStringConverter<TMethod> _converter;

            public DelegateVisitor(DelegateExpressionToStringConverter<TMethod> converter, int methodDepth, object objectInstance = null)
            {
                _methodDepth = methodDepth;
                _objectInstance = objectInstance;
                _converter = converter;
            }

            public string Resolution { get; private set; }

            protected override Expression VisitBinary(BinaryExpression node)
            {
                var op = node.NodeType switch
                {
                    ExpressionType.Add => "+",
                    ExpressionType.AndAlso => "and",
                    ExpressionType.OrElse => "or",
                    _ => throw new NotSupportedException($"Binary operator {node.NodeType}")
                };

                var leftVisitor = new DelegateVisitor(_converter, _methodDepth, _objectInstance);
                leftVisitor.Visit(node.Left);

                var rightVisitor = new DelegateVisitor(_converter, _methodDepth, _objectInstance);
                rightVisitor.Visit(node.Right);

                Resolution += $"{leftVisitor.Resolution} {op} {rightVisitor.Resolution}";

                return node;
            }

            protected override Expression VisitUnary(UnaryExpression node)
            {
                if(node.NodeType != ExpressionType.Not)
                {
                    throw new NotSupportedException($"Unary expression {node.NodeType}");
                }

                var visitor = new DelegateVisitor(_converter, _methodDepth, _objectInstance);
                visitor.Visit(node.Operand);

                Resolution += $"not ({visitor.Resolution})";

                return node;
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                Resolution += _converter._quoteStrings && node.Value is string s ? $"'{s}'" : node.Value.ToString();

                return node;
            }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                var objectInstance = (node.Object is ConstantExpression constant) ? constant.Value : _objectInstance;

                var methodCallFormatter = new Func<string, ReadOnlyCollection<Expression>, string>((name, args) =>
                {
                    var arguments = args.Select(arg =>
                    {
                        var argVisitor = new DelegateVisitor(_converter, _methodDepth + 1, objectInstance);
                        argVisitor.Visit(arg);

                        return argVisitor.Resolution;
                    });

                    return string.Format(_converter._methodCallFormat, name, string.Join(", ", arguments));
                });

                var supportMethods = new Func<IEnumerable<MethodInfo>>(() => typeof(Installation).GetMethods(BindingFlags.Instance | BindingFlags.Public)
                                                                                                 .Where(m => m.GetCustomAttribute<BuiltInSymbolAttribute>() != null));

                switch (_methodDepth)
                {
                    case 1:
                        var supportMethod = supportMethods().FirstOrDefault(m => m.Name == node.Method.Name);
                        if(supportMethod == null)
                        {
                            var handler = BindingSearch.Flags
                                .Select(f => objectInstance.GetType().GetMethod(node.Method.Name, f))
                                .FirstOrDefault(m => m != null);

                            if (handler == null)
                            {
                                var msg = $"Only class instance methods may be invoked; {node.Method.Name} is not supported";
                                throw new NotSupportedException(msg);
                            }

                            _converter._visitMethodHandler(node.Method);
                        }
                        break;

                    case 2:
                        var expandConstantMethod = supportMethods().FirstOrDefault(m => m.Name == nameof(Installation.ExpandConstant));

                        if (expandConstantMethod == null || node.Method.MetadataToken != expandConstantMethod.MetadataToken)
                        {
                            var msg = $"Only the method call {nameof(Installation.ExpandConstant)} is allowed at this depth; {node.Method.Name} is not supported";
                            throw new NotSupportedException(msg);
                        }
                        break;

                    default:
                        methodCallFormatter = (name, args) =>
                        {
                            var visitor = new InvokingVisitor(objectInstance);
                            visitor.Visit(node);

                            return visitor.Results[0] is string ? $"'{visitor.Results[0]}'" : visitor.Results[0].ToString();
                        };

                        break;
                }

                var methodName = node.Method.GetCustomAttribute<AliasAttribute>()?.Name ?? node.Method.Name;

                Resolution += methodCallFormatter(methodName, node.Arguments);

                return node;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                var visitor = new InvokingVisitor(_objectInstance);
                visitor.Visit(node);

                Resolution += $"'{visitor.Results[0]}'";

                return node;
            }

            protected override Expression VisitParameter(ParameterExpression node)
            {
                throw new NotSupportedException($"Use of the CurrentFileName is not currently supported");
            }
        }

        /// <summary>
        /// Visits nodes, converting each into its resultant object by invoking/getting the member
        /// </summary>
        class InvokingVisitor : ExpressionVisitor
        {
            private readonly object _objectInstance;

            public List<object> Results { get; } = new List<object>();

            public InvokingVisitor(object objectInstance)
            {
                _objectInstance = objectInstance;
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                Results.Add(node.Value);
                return node;
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                var field = BindingSearch.Flags
                    .Select(f => _objectInstance.GetType().GetField(node.Member.Name, f))
                    .FirstOrDefault(f => f != null);

                if (field == null)
                {
                    var property = BindingSearch.Flags
                        .Select(f => _objectInstance.GetType().GetProperty(node.Member.Name, f))
                        .FirstOrDefault(f => f != null);

                    if (property != null)
                    {
                        Results.Add(property.GetValue(_objectInstance));
                    }
                }
                else
                {
                    Results.Add(field.GetValue(_objectInstance));
                }

                return node;
            }

            protected override Expression VisitLambda<T>(Expression<T> node)
            {
                Results.Add(node);
                return node;
            }

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                var parameterVisitor = new InvokingVisitor(_objectInstance);

                node.Arguments.ForEach(arg => parameterVisitor.Visit(arg));

                Results.Add(node.Method.Invoke(_objectInstance, parameterVisitor.Results.ToArray()));

                return node;
            }
        }
    }
}
