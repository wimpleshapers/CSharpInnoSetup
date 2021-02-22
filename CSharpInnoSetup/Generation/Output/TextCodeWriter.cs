
using CodingMuscles.CSharpInnoSetup.Utilities;
using System;
using System.IO;
using System.Linq;

namespace CodingMuscles.CSharpInnoSetup.Generation.Output
{
    /// <summary>
    /// A <see cref="ICodeWriter"/> that writes to a <see cref="TextWriter"/>
    /// </summary>
    internal class TextCodeWriter : Disposable, ICodeWriter
    {
        private readonly TextWriter _textWriter;
        private readonly string _indentation;
        private readonly bool _leaveOpen;
        private int _indentationDepth;
        private string _linePrefix;

        /// <summary>
        /// Initializes a new <see cref="TextCodeWriter"/>
        /// </summary>
        /// <param name="textWriter">The underlying <see cref="TextWriter"/></param>
        /// <param name="indentation">The indentation to use</param>
        /// <param name="leaveOpen">True if the <paramref name="textWriter"/> should be left open when this object is disposed</param>
        public TextCodeWriter(TextWriter textWriter, string indentation = null, bool leaveOpen = false)
        {
            _textWriter = textWriter;
            _indentation = indentation ?? "   ";
            _indentationDepth = 0;
            _leaveOpen = leaveOpen;
        }

        /// <inheritdoc/>
        public void Indent(Indentation indentation)
        {
            _indentationDepth = ComputeIndentationDepth(_indentationDepth, indentation);
        }

        /// <inheritdoc/>
        public IDisposable Indent()
        {
            return new Intedentor(this);
        }

        /// <inheritdoc/>
        public void Write(string code, Indentation indentation = Indentation.Current)
        {
            if (_linePrefix == null)
            {
                _linePrefix = "";
                var indentationDepth = ComputeIndentationDepth(_indentationDepth, indentation);
                Enumerable.Range(0, indentationDepth).ForEach(i => _linePrefix += _indentation);
            }

            _linePrefix += code;
        }

        /// <inheritdoc/>
        public void WriteLine(string code, Indentation indentation = Indentation.Current)
        {
            if (_linePrefix == null)
            {
                var indentationDepth = ComputeIndentationDepth(_indentationDepth, indentation);
                Enumerable.Range(0, indentationDepth).ForEach(i => _textWriter.Write(_indentation));
            }
            else
            {
                _textWriter.Write(_linePrefix);
                _linePrefix = null;
            }

            _textWriter.WriteLine(code);
        }

        /// <inheritdoc/>
        protected override void OnDisposing()
        {
            if(_linePrefix != null)
            {
                // write any outstanding text
                _textWriter.Write(_linePrefix);
            }

            if (_leaveOpen)
            {
                _textWriter.Flush();
            }
            else
            {
                _textWriter.Close();
            }
        }

        private int ComputeIndentationDepth(int currentDepth, Indentation indentation)
        {
            switch (indentation)
            {
                case Indentation.None:
                    currentDepth = 0;
                    break;

                case Indentation.Increase:
                    currentDepth++;
                    break;

                case Indentation.Decrease:
                    if (currentDepth == 0)
                    {
                        throw new Exception($"Invalid indentation depth");
                    }

                    currentDepth--;
                    break;
            }

            return currentDepth;
        }

        class Intedentor : Disposable
        {
            private readonly TextCodeWriter _writer;

            public Intedentor(TextCodeWriter writer)
            {
                _writer = writer;
                _writer.Indent(Indentation.Increase);
            }

            protected override void OnDisposing()
            {
                _writer.Indent(Indentation.Decrease);
            }
        }
    }
}
