
using System;

namespace CodingMuscles.CSharpInnoSetup.Generation.Output
{
    /// <summary>
    /// Implemented by objects capable of writing the [Code] section of the script
    /// which requires indentation
    /// </summary>
    internal interface ICodeWriter : IDisposable
    {
        /// <summary>
        /// Appends code to the current line
        /// </summary>
        /// <param name="code">The code to write</param>
        /// <param name="indentation">The indentation to use at the start of the line</param>
        void Write(string code, Indentation indentation = Indentation.Current);

        /// <summary>
        /// Writes a line of code
        /// </summary>
        /// <param name="code">The code to write</param>
        /// <param name="indentation">The indentation to use at the start of the line</param>
        /// <remarks><paramref name="code"/> is appended to any code that was previously 
        /// written with <see cref="Write(string, Indentation)"/></remarks>
        void WriteLine(string code, Indentation indentation = Indentation.Current);

        /// <summary>
        /// Increases the current indentation
        /// </summary>
        /// <returns>An object that, when disposed, returns the indentation to the previous level</returns>
        IDisposable Indent();

        /// <summary>
        /// Updates the current indentation
        /// </summary>
        /// <param name="indentation">The new indentation to use</param>
        void Indent(Indentation indentation);
    }
}
