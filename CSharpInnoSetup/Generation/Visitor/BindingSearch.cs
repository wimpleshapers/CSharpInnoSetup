
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    internal static class BindingSearch
    {
        /// <summary>
        /// Defines the binding order in which class members searches are performed
        /// </summary>
        public static readonly BindingFlags[] Flags =
        {
            // look in the top class first
            BindingFlags.Instance | BindingFlags.Public,
            BindingFlags.Instance | BindingFlags.NonPublic,
            BindingFlags.Static | BindingFlags.Public,
            BindingFlags.Static | BindingFlags.NonPublic,
            // next search all levels
            BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public,
            BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic,
            BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public,
            BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.NonPublic
        };
    }
}
