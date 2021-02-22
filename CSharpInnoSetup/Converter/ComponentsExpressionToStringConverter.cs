
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts an expression, that evaluates to a <see cref="bool"/>, containing a logical combination of
    /// one or more <see cref="Component{T}"/> objects
    /// </summary>
    internal class ComponentsExpressionToStringConverter : ToStringConverter<Expression<Func<bool>>>
    {
        /// <inheritdoc/>
        protected override string Convert(Expression<Func<bool>> expression)
        {
            var result = Visit(expression.Body);
            
            if(result.StartsWith("("))
            {
                // parens around the outside are superfluous
                result = result[1..^1];
            }

            return result;
        }

        private string Visit(Expression expression)
        {
            if (expression is BinaryExpression binaryExpression)
            {
                var left = Visit(binaryExpression.Left);
                var right = Visit(binaryExpression.Right);

                string op;

                switch(binaryExpression.NodeType)
                {
                    case ExpressionType.OrElse:
                        op = "or";
                        break;

                    case ExpressionType.AndAlso:
                        op = "and";
                        break;

                    default:
                        throw new NotSupportedException($"Operator {binaryExpression.NodeType} is not supported");
                }

                return $"({left} {op} {right})";
            }
            else if (expression is UnaryExpression unaryExpression)
            {
                var prefix = unaryExpression.NodeType == ExpressionType.Not ? "not " : string.Empty;

                return prefix + Visit(unaryExpression.Operand);
            }
            else if (expression is MemberExpression memberExpression)
            {
                return GetPropertyName(memberExpression);
            }

            throw new NotSupportedException($"Expression type {expression.GetType().Name} is not supported");
        }

        private string GetPropertyName(Expression expression)
        {
            if (expression is MemberExpression memberExpression)
            {
                var name = GetPropertyName(memberExpression.Expression);

                if (memberExpression.Member is PropertyInfo propertyInfo)
                {
                    if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Component<>))
                    {
                        name = Path.Combine(name, propertyInfo.Name);
                    }
                    else if (propertyInfo.Name != nameof(Component<object>.Children))
                    {
                        throw new NotSupportedException($"Property type {propertyInfo.PropertyType.Name} is not supported");
                    }
                }

                return name;
            }

            return string.Empty;
        }
    }
}
