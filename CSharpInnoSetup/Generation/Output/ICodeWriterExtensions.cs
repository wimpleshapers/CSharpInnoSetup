
using System.Collections.Generic;

namespace CodingMuscles.CSharpInnoSetup.Generation.Output
{
    /// <summary>
    /// Extensions for the <see cref="ICodeWriter"/> interface
    /// </summary>
    internal static class ICodeWriterExtensions
    {
        /// <summary>
        /// Writes a single comma
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteComma(this ICodeWriter codeWriter)
        {
            codeWriter.Write(",");
        }

        /// <summary>
        /// Writes a single semi-colon
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteSemicolon(this ICodeWriter codeWriter)
        {
            codeWriter.Write(";");
        }

        /// <summary>
        /// Writes a comma separated collection of objects
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        /// <param name="list">The collection to write</param>
        public static void WriteCommaSeparatedList(this ICodeWriter codeWriter, IEnumerable<string> list)
        {
            codeWriter.Write(string.Join(",", list));
        }

        /// <summary>
        /// Writes a space-separated assignment expression
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteAssign(this ICodeWriter codeWriter)
        {
            codeWriter.Write(" := ");
        }

        /// <summary>
        /// Writes a single blank space
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteSpace(this ICodeWriter codeWriter)
        {
            codeWriter.Write(" ");
        }

        /// <summary>
        /// Writes a new line, appending a semi-colon on the end
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteEndOfStatement(this ICodeWriter codeWriter)
        {
            codeWriter.WriteLine(";");
        }

        /// <summary>
        /// Writes the "var" keyword
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteVar(this ICodeWriter codeWriter)
        {
            codeWriter.WriteLine("var");
        }

        /// <summary>
        /// Writes the "begin" keyword
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteBegin(this ICodeWriter codeWriter)
        {
            codeWriter.WriteLine("begin");
        }

        /// <summary>
        /// Writes a line containing the "end" keyword and semi-colon
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteEnd(this ICodeWriter codeWriter)
        {
            codeWriter.WriteLine("end;");
        }

        /// <summary>
        /// Writes 
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteLParen(this ICodeWriter codeWriter)
        {
            codeWriter.Write("(");
        }

        /// <summary>
        /// Writes a single right-parenthesis
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteRParen(this ICodeWriter codeWriter)
        {
            codeWriter.Write(")");
        }

        /// <summary>
        /// Writes a single left-parenthesis
        /// </summary>
        /// <param name="codeWriter">The code writer to affect</param>
        public static void WriteBlankLine(this ICodeWriter codeWriter)
        {
            codeWriter.WriteLine(string.Empty, Indentation.None);
        }
    }
}
