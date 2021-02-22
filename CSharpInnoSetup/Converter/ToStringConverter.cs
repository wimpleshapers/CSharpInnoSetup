
using System;
using System.ComponentModel;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Convenience base class used as a one-way conversion between the type <typeparamref name="TIncoming"/>
    /// and a <see cref="string"/>
    /// </summary>
    /// <typeparam name="TIncoming"></typeparam>
    internal abstract class ToStringConverter<TIncoming> : TypeConverter
    {
        /// <inheritdoc/>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string);
        }

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return Convert(value == null ? default : (TIncoming)value);
        }

        protected abstract string Convert(TIncoming value);
    }
}
