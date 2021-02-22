
using System;
using System.IO;
using System.Text;

namespace CodingMuscles.CSharpInnoSetup.Example
{
    /// <summary>
    /// Writes what is written to an underlying <see cref="TextWriter"/> 
    /// to the <see cref="Console.Out"/> as well
    /// </summary>
    public class DiagnosticStreamWriter : TextWriter
    {
        private int _line = 1;
        private string _buffer = string.Empty;
        private readonly TextWriter _underlyingTextmWriter;

        public DiagnosticStreamWriter(TextWriter underlyingTextmWriter)
        {
            _underlyingTextmWriter = underlyingTextmWriter;
        }

        public override Encoding Encoding => _underlyingTextmWriter.Encoding;


        public override void Write(string value)
        {
            _buffer += value;
            _underlyingTextmWriter.Write(value);
        }

        public override void WriteLine(string value)
        {
            Console.WriteLine($"{_line++:0000} {_buffer}{value}");
            _buffer = string.Empty;

            _underlyingTextmWriter.WriteLine(value);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _underlyingTextmWriter.Dispose();
            }
        }
    }
}
