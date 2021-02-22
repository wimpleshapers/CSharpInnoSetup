
using CodingMuscles.CSharpInnoSetup.Script;
using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Converter
{
    /// <summary>
    /// Converts the properties of an arbitrary object into a <see cref="NameValueCollection"/>, where the 
    /// name is the property name, and the value is the property's value.
    /// </summary>
    /// <remarks>
    /// Each property's <see cref="object.ToString"/> method is used to convert the value to a string, unless
    /// the property declares a <see cref="TypeConverterAttribute"/>, in which case the type converter is used.
    /// The values of properties declared with a <see cref="DoubleQuoteAttribute"/> will be enclosed with 
    /// double quotes if the value contains a space.
    /// </remarks>
    internal class PropertiesToNameValuePairsConverter : TypeConverter
    {
        private readonly Func<TypeConverterAttribute, TypeConverter> _typeConverterFactory;
        private readonly Func<string, PropertyInfo, string> _propertyFormatter = (s, p) => s;

        /// <summary>
        /// Initializes a new <see cref="PropertiesToNameValuePairsConverter"/>
        /// </summary>
        /// <param name="typeConverterFactory">Factory for creating <see cref="TypeConverter"/> objects</param>
        public PropertiesToNameValuePairsConverter(Func<TypeConverterAttribute, TypeConverter> typeConverterFactory = null)
        {
            _typeConverterFactory = typeConverterFactory ?? (tc => (TypeConverter)Activator.CreateInstance(Type.GetType(tc.ConverterTypeName)));
        }

        /// <summary>
        /// Initializes a new <see cref="PropertiesToNameValuePairsConverter"/>
        /// </summary>
        /// <param name="propertyFormatter">Responsible for the final formatting of a stringized property value</param>
        /// <param name="typeConverterFactory">Factory for creating <see cref="TypeConverter"/> objects</param>
        public PropertiesToNameValuePairsConverter(Func<string, PropertyInfo, string> propertyFormatter, Func<TypeConverterAttribute, TypeConverter> typeConverterFactory = null) : this(typeConverterFactory)
        {
            _propertyFormatter = propertyFormatter;
        }

        /// <inheritdoc/>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(NameValueCollection);
        }

        /// <inheritdoc/>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            var pairs = new NameValueCollection();
            var type = value.GetType();

            foreach (var property in type.GetProperties())
            {
                var propertyValue = property.GetValue(value);

                if (propertyValue != null)
                {
                    if(property.GetCustomAttribute<IgnoreAttribute>() != null)
                    {
                        continue;
                    }

                    var name = property.GetCustomAttribute<AliasAttribute>()?.Name ?? property.Name;
                    var typeConverter = property.GetCustomAttribute<TypeConverterAttribute>();

                    if (typeConverter == null)
                    {
                        // try to get converter off interface
                        // this doesn't account for explicit implementations
                        // which we won't have anyway
                        var ifaceProperty = type.GetInterfaces()
                            .SelectMany(iface => iface.GetProperties())
                            .FirstOrDefault(p => p.Name == property.Name);

                        typeConverter = ifaceProperty?.GetCustomAttribute<TypeConverterAttribute>();
                    }

                    string convertedValue;
                    if (typeConverter == null)
                    {
                        if(property.PropertyType.IsArray)
                        {
                            var values = ((IEnumerable)propertyValue).Cast<object>().Select(v => v.ToString());
                            convertedValue = string.Join(" ", values);
                        }
                        else
                        {
                            convertedValue = propertyValue.ToString();
                        }
                    }
                    else
                    {
                        var converter = _typeConverterFactory(typeConverter);
                        convertedValue = converter.ConvertTo(propertyValue, typeof(string)) as string;
                    }

                    if (convertedValue != null)
                    {
                        convertedValue = _propertyFormatter(convertedValue, property);
                        pairs.Add(name, convertedValue);
                    }
                }
            }

            return pairs;
        }
    }
}

