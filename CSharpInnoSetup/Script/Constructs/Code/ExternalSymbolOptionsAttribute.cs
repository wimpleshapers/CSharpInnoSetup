
using System;
using System.Runtime.InteropServices;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code
{
    /// <summary>
    /// Attribute applied to methods that, along with the <see cref="DllImportAttribute"/>,
    /// indicate how to load the DLL containing an external symbol
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public sealed class ExternalSymbolOptionsAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="ExternalSymbolOptionsAttribute"/>
        /// </summary>
        /// <param name="options"></param>
        public ExternalSymbolOptionsAttribute(ExternalSymbolOption options)
        {
            Options = options;
        }

        /// <summary>
        /// The DLL load options
        /// </summary>
        public ExternalSymbolOption Options { get; }
    }
}
