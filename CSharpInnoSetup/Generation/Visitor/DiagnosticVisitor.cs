
using ICSharpCode.Decompiler.CSharp.Syntax;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    /// <summary>
    /// Writes the names of node types as they are visited, indenting child nodes
    /// one level deeper than their parent.
    /// </summary>
    internal class DiagnosticVisitor : AbstractVisitor
    {
        private readonly TextWriter _textWriter;

        /// <summary>
        /// Initializes a new <see cref="DiagnosticVisitor"/>
        /// </summary>
        /// <param name="textWriter">The <see cref="TextWriter"/> to write to</param>
        public DiagnosticVisitor(TextWriter textWriter)
        {
            _textWriter = textWriter;
        }

        /// <summary>
        /// The number of spaces to indent child nodes
        /// </summary>
        public int Indentation { get; set; }

        private void Write(string line)
        {
            _textWriter.WriteLine($"{new string(' ', Indentation * 3)}{line}");
        }

        protected void Visit(AstNode node)
        {
            Write($"{node.GetType().Name}: {node}");

            Indentation++;
            try
            {
                node.VisitChildren(this);
            }
            finally
            {
                Indentation--;
            }
        }

        protected override void VisitNode(AstNode syntax)
        {
            Write($"{syntax.GetType().Name}: {syntax}");

            Indentation++;
            try
            {
                syntax.VisitChildren(this);
            }
            finally
            {
                Indentation--;
            }
        }
    }
}
