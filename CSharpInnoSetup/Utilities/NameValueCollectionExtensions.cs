
using System.Collections.Specialized;
using System.Linq;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Extensions to the <see cref="NameValueCollection"/> class
    /// </summary>
    internal static class NameValueCollectionExtensions
    {
        /// <summary>
        /// Formats a <see cref="NameValueCollection"/> as a string
        /// </summary>
        /// <param name="nameValueCollection">The collection to format</param>
        /// <param name="valueSeperator">The string that separates a name from its value</param>
        /// <param name="propertySeparator">The string that separates one name/value from another</param>
        /// <returns></returns>
        public static string Format(
            this NameValueCollection nameValueCollection, 
            string valueSeperator = ": ", 
            string propertySeparator = "; ")
        {
            return string.Join(propertySeparator, nameValueCollection.Keys
                .Cast<string>()
                .Select(k => $"{k}{valueSeperator}{nameValueCollection[k]}"));
        }
    }
}
