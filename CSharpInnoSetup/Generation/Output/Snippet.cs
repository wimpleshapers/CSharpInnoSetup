
using CodingMuscles.CSharpInnoSetup.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodingMuscles.CSharpInnoSetup.Generation.Output
{
    /// <summary>
    /// A chunk of code written to memory
    /// </summary>
    internal class Snippet : Disposable
    {
        private readonly MemoryStream _memoryStream;
        private readonly StreamWriter _streamWriter;

        /// <summary>
        /// Initializes a new <see cref="Snippet"/>
        /// </summary>
        /// <param name="encoding">The encoding to use, or null to use UTF8</param>
        public Snippet(Encoding encoding = null)
        {
            _streamWriter = new StreamWriter(_memoryStream = new MemoryStream(), encoding ?? new UTF8Encoding(false));
        }

        /// <summary>
        /// The lines of code written
        /// </summary>
        public IEnumerable<string> Lines
        {
            get
            {
                _streamWriter.Flush();
                _memoryStream.Seek(0, SeekOrigin.Begin);

                var code = Encoding.UTF8.GetString(_memoryStream.ToArray());
                var lines = code.Split(Environment.NewLine);

                int take = lines.Length;
                // Sometimes a single line may be written as "[text]\r\n" in 
                // which case Split would return two elements.  In that case
                // we want to ignore the last, empty line.
                if (take > 1 && code.EndsWith(Environment.NewLine))
                    take--;

                return lines.Take(take);
            }
        }

        /// <summary>
        /// Converts this class to a <see cref="TextWriter"/>
        /// </summary>
        /// <param name="snippet">The snippet to convert</param>
        public static implicit operator TextWriter(Snippet snippet) => snippet._streamWriter;

        /// <summary>
        /// Copies the contents to a <see cref="ICodeWriter"/>
        /// </summary>
        /// <param name="codeWriter">The code writer to write to</param>
        public void CopyTo(ICodeWriter codeWriter)
        {
            Lines.ForEach(l => codeWriter.WriteLine(l));
        }

        /// <inheritdoc/>
        protected override void OnDisposing()
        {
            _streamWriter.Dispose();
        }

        private static int NextLineBreak(string snippet, int startIndex)
        {
            var nextIndex = snippet.IndexOf(Environment.NewLine, startIndex);
            return nextIndex == -1 ? snippet.Length : nextIndex;
        }
    }
}
