
using System;
using System.Linq.Expressions;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Specialized converter that adapts true/false expressions to a directive yes/no
    /// </summary>
    /// <typeparam name="TMethod">The delegate type</typeparam>
    internal class DirectiveMethodCallExpressionToStringConverter<TMethod> : DelegateExpressionToStringConverter<TMethod> where TMethod : Delegate
    {
        /// <inheritdoc/>
        protected override string Convert(Expression<TMethod> expression)
        {
            var value = base.Convert(expression);

            return value switch
            {
                "True" => "yes",
                "False"=> "no",
                _ => value
            };
        }
    }
}
