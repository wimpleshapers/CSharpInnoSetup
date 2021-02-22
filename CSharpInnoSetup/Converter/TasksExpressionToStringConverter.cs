
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a lambda <see cref="Expression"/> that returns an array of <see cref="ITask"/> objects
    /// into a space-separated string of the referenced <see cref="ITask"/> object property or field name.
    /// </summary>
    internal class TasksExpressionToStringConverter : ToStringConverter<Expression<Func<ITask[]>>>
    {
        /// <inheritdoc/>
        protected override string Convert(Expression<Func<ITask[]>> value)
        {
            if(value.Body is NewArrayExpression expression)
            {
                return string.Join(" ", expression.Expressions.Select(GetPropertyName));
            }

            throw new NotSupportedException("A tasks expression accepts only new arrays");
        }

        private string GetPropertyName(Expression expression)
        {
            if(expression is MemberExpression memberExpression)
            {
                var name = GetPropertyName(memberExpression.Expression);

                if(memberExpression.Member is PropertyInfo propertyInfo)
                {
                    if (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(Task<>))
                    {
                        name = Path.Combine(name, propertyInfo.Name);
                    }
                    else if(propertyInfo.Name != nameof(Task<object>.Children))
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
