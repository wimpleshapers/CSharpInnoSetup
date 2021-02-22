
using System;

namespace CodingMuscles.CSharpInnoSetup.Generation.Output
{
    /// <summary>
    /// Factory that creates instances of an <see cref="ICodeWriter"/>, the content of which
    /// isn't transferred to the underlying <see cref="_rootCodeWriter"/> until it is disposed.
    /// </summary>
    /// <remarks>
    /// When parsing methods that call other methods, this factory ensures nested methods are
    /// defined first.  This happens because a method's code contents are not written until the 
    /// writer is disposed...iow, first in last out.
    /// </remarks>
    internal class NestedCodeWriterFactory
    {
        private readonly ICodeWriter _rootCodeWriter;

        /// <summary>
        /// Initializes a new <see cref="NestedCodeWriterFactory"/>
        /// </summary>
        /// <param name="rootCodeWriter">The code writer to which all code is written</param>
        public NestedCodeWriterFactory(ICodeWriter rootCodeWriter)
        {
            _rootCodeWriter = rootCodeWriter;
        }

        /// <summary>
        /// Creates a new code writer instance
        /// </summary>
        /// <returns>The new <see cref="ICodeWriter"/></returns>
        public ICodeWriter New()
        {
            return new NestedCodeWriter(this);
        }

        class NestedCodeWriter : ICodeWriter
        {
            private readonly Snippet _snippet;
            private readonly TextCodeWriter _codeWriter;
            private readonly NestedCodeWriterFactory _factory;

            public NestedCodeWriter(NestedCodeWriterFactory factory)
            {
                _snippet = new Snippet();
                _codeWriter = new TextCodeWriter(_snippet, null, true);
                _factory = factory;
            }

            public void Dispose()
            {
                _codeWriter.Dispose();

                _snippet.CopyTo(_factory._rootCodeWriter);
                _snippet.Dispose();
            }

            public IDisposable Indent()
            {
                return _codeWriter.Indent();
            }

            public void Indent(Indentation indentation)
            {
                _codeWriter.Indent(indentation);
            }

            public void Write(string code, Indentation indentation = Indentation.Current)
            {
                _codeWriter.Write(code, indentation);
            }

            public void WriteLine(string code, Indentation indentation = Indentation.Current)
            {
                _codeWriter.WriteLine(code, indentation);
            }
        }
    }
}
