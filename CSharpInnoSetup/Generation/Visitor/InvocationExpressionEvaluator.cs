
using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    /// <summary>
    /// Converts nodes to their resultant objects as they are visited
    /// </summary>
    internal class InvocationExpressionEvaluator
    {
        private readonly PascalScriptVisitorContext _context;
        private readonly List<MethodInfo> _visitedMethods;
        private readonly Func<Type, bool> _declaringTypeFilter;

        /// <summary>
        /// Initializes a new <see cref="InvocationExpressionEvaluator"/>
        /// </summary>
        /// <param name="context">The visitor context</param>
        /// <param name="visitedMethods">A list that is populated with visited methods</param>
        /// <param name="declaringTypeFilter">Predicate that determines whether a type's methods should be considered</param>
        public InvocationExpressionEvaluator(
            PascalScriptVisitorContext context, 
            List<MethodInfo> visitedMethods, 
            Func<Type, bool> declaringTypeFilter = null)
        {
            _context = context;
            _visitedMethods = visitedMethods;
            _declaringTypeFilter = declaringTypeFilter ?? (t => true);
        }

        /// <summary>
        /// The evaluation result 
        /// </summary>
        public object Result { get; private set; }

        /// <summary>
        /// Attempts to visit an <see cref="InvocationExpression"/> node
        /// </summary>
        /// <param name="syntax">The node to evaluate</param>
        /// <returns>True if it was visited, otherwise false</returns>
        public bool TryVisit(InvocationExpression syntax)
        {
            var methodToEval = GetMethodToEval(syntax, _context, _declaringTypeFilter);

            if (methodToEval != null)
            {
                var arguments = syntax.Arguments
                    .Select(arg =>
                    {
                        // allow all methods
                        var visitor = new EvaluationVisitor(_context, _visitedMethods, t => true);
                        arg.AcceptVisitor(visitor);

                        return visitor.Result;
                    })
                    .ToArray();

                Result = _context.Invoke(methodToEval, arguments);
                return true;
            }

            return false;
        }

        class EvaluationVisitor : AbstractVisitor
        {
            private readonly PascalScriptVisitorContext _context;
            private readonly Func<Type, bool> _declaringTypeFilter;
            private readonly List<MethodInfo> _visitedMethods;

            public EvaluationVisitor(PascalScriptVisitorContext context, List<MethodInfo> visitedMethods, Func<Type, bool> declaringTypeFilter = null)
            {
                _context = context;
                _declaringTypeFilter = declaringTypeFilter ?? InstallationOnlyMethods;
                _visitedMethods = visitedMethods;
            }

            /// <summary>
            /// The evaluation result 
            /// </summary>
            public object Result { get; private set; }

            /// <inheritdoc/>
            public override void VisitInvocationExpression(InvocationExpression syntax)
            {
                var methodToEval = GetMethodToEval(syntax, _context, _declaringTypeFilter);

                if (methodToEval == null)
                {
                    throw new NotSupportedException($"Encountered syntax that is unable to be evaluated: {syntax}");
                }

                var arguments = syntax.Arguments
                    .Select(arg =>
                    {
                        var visitor = new EvaluationVisitor(_context, _visitedMethods);
                        arg.AcceptVisitor(visitor);

                        return visitor.Result;
                    })
                    .ToArray();

                Result = _context.Invoke(methodToEval, arguments);
            }

            /// <inheritdoc/>
            public override void VisitPrimitiveExpression(PrimitiveExpression syntax)
            {
                Result = syntax.Value;
            }

            /// <inheritdoc/>
            public override void VisitObjectCreateExpression(ObjectCreateExpression syntax)
            {
                var type = _context.GetType(syntax.Type.ToString());

                if (type != null)
                {
                    var arguments = syntax.Arguments
                        .Select(arg =>
                        {
                            var visitor = new EvaluationVisitor(_context, _visitedMethods);
                            arg.AcceptVisitor(visitor);

                            return visitor.Result;
                        })
                        .ToArray();

                    Result = Activator.CreateInstance(type, arguments);
                }
            }

            /// <inheritdoc/>
            public override void VisitLambdaExpression(LambdaExpression syntax)
            {
                if (syntax.Body is IdentifierExpression identifierExpression)
                {
                    var methodInfo = BindingSearch.Flags.Select(f => _context.GetMethod(identifierExpression.Identifier, f)).FirstOrDefault(m => m != null);

                    if (methodInfo.ReturnType == typeof(void) && methodInfo.GetParameters().SingleOrDefault()?.ParameterType == typeof(string))
                    {
                        var createDelegateMethod = typeof(MethodInfo).GetMethod("CreateDelegate", new[] { typeof(Type), typeof(object) });

                        var createDelegateExpression = System.Linq.Expressions.Expression.Call(
                            System.Linq.Expressions.Expression.Constant(methodInfo),
                            createDelegateMethod,
                            System.Linq.Expressions.Expression.Constant(typeof(Action<string>)),
                            _context.GetConstant());

                        var convert = System.Linq.Expressions.Expression.Convert(createDelegateExpression, typeof(Action<string>));

                        Result = System.Linq.Expressions.Expression.Lambda<Func<Action<string>>>(convert);
                    }
                    else
                    {
                        throw new NotSupportedException($"Lambdas the prototype of the method {methodInfo.Name} are not supported");
                    }

                    _visitedMethods.Add(methodInfo);
                }
                else
                {
                    throw new NotSupportedException($"Lambdas expressing {syntax} are not supported");
                }
            }

            private bool InstallationOnlyMethods(Type t)
            {
                return t == typeof(Installation);
            }
        }

        public static MethodInfo GetMethodToEval(
            InvocationExpression syntax, 
            PascalScriptVisitorContext context,
            Func<Type, bool> declaringTypeFilter)
        {
            var target = syntax.Target.ToString();
            var targetParts = target.Split(".");
            var methodName = targetParts[^1];

            MethodInfo methodToEval = null;
            try
            {
                methodToEval = BindingSearch.Flags
                    .Select(f => context.GetMethod(methodName, f))
                    .Where(m => m != null)
                    .Where(m => declaringTypeFilter(m.DeclaringType))
                    .FirstOrDefault();
            }
            catch (AmbiguousMatchException)
            {
                // We have overloads that won't result in a direct match, so in that
                // case try to match on method name and argument count.  This isn't 
                // foolproof because overloads can have identical argument counts but
                // differenty types, but this is the best that can be done given we
                // don't know the argument types until we evaluate them, which doesn't 
                // happen until after this.
                methodToEval = BindingSearch.Flags
                    .SelectMany(f => context.GetMethods(f))
                    .Where(m => m.Name == methodName &&
                                m.DeclaringType == typeof(Installation) &&
                                m.GetParameters().Length == syntax.Arguments.Count)
                    .FirstOrDefault(m => m != null);
            }

            return methodToEval;
        }
    }
}
