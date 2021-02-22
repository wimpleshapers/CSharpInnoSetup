
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Utilities
{
    /// <summary>
    /// Extensions to the <see cref="TextWriter"/> class
    /// </summary>
    internal static class TextWriterExtensions
    {
        /// <summary>
        /// Writes a blank line
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter"/> being written to</param>
        public static void WriteBlankLine(this TextWriter textWriter)
        {
            textWriter.WriteLine(string.Empty);
        }
    }
}
