
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts a lambda <see cref="Expression"/> that returns an array of <see cref="Language"/> objects
    /// into a space-separated string of the referenced <see cref="Language"/> object property or field name.
    /// </summary>
    internal class LanguagesToSpaceSeparatedStringConverter : ToStringConverter<Expression<Func<Language[]>>>
    {
        /// <inheritdoc/>
        protected override string Convert(Expression<Func<Language[]>> expression)
        {
            return Visit(expression.Body);
        }

        private string Visit(Expression expression)
        {
            if (expression is NewArrayExpression newArrayExpression)
            {
                return string.Join(" ", newArrayExpression.Expressions.Select(Visit));
            }
            else if (expression is MemberExpression memberExpression)
            {
                if(memberExpression.Member is PropertyInfo propertyInfo)
                {
                    if (propertyInfo.PropertyType != typeof(Language))
                    {
                        throw new NotSupportedException($"Unsupported property type {propertyInfo.PropertyType.Name} used in component expression");
                    }

                    return propertyInfo.Name;
                }
                else if(memberExpression.Member is FieldInfo fieldInfo)
                {
                    if (fieldInfo.FieldType != typeof(Language))
                    {
                        throw new NotSupportedException($"Unsupported property type {fieldInfo.FieldType.Name} used in component expression");
                    }

                    return fieldInfo.Name;
                }
            }

            throw new NotSupportedException($"Expression type {expression.GetType().Name} is not supported");
        }
    }
}
