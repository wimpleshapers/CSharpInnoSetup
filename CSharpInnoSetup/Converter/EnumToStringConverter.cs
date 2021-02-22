
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Utilities;
using System;
using System.Linq;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts an enumerated value of type <typeparamref name="TEnum"/> to its string name
    /// if a single value, or a space separated string of values if the enumeration uses the
    /// <see cref="FlagsAttribute"/>
    /// </summary>
    /// <typeparam name="TEnum">The type of enumeration</typeparam>
    internal class EnumToStringConverter<TEnum> : ToStringConverter<TEnum> where TEnum : Enum
    {
        /// <inheritdoc/>
        /// <remarks>
        /// Flag enumerations with a value of 0 are converted to null
        /// </remarks>
        protected override string Convert(TEnum value)
        {
            var type = typeof(TEnum);
            
            if(type.GetCustomAttributes(typeof(FlagsAttribute), false).Any())
            {
                if(System.Convert.ToInt64(value) == 0)
                {
                    return null;
                }

                var flags = value.GetFlags().ToList();
                var values = flags.Select(f => GetEnumName(f.ToString()));

                return string.Join(" ", values);
            }

            return GetEnumName((value).ToString());
        }

        private string GetEnumName(string enumName)
        {
            var member = typeof(TEnum).GetMember(enumName).Single();
            var symbol = member.GetCustomAttributes(typeof(AliasAttribute), false).Cast<AliasAttribute>().SingleOrDefault();

            return symbol?.Name ?? enumName;
        }
    }
}
