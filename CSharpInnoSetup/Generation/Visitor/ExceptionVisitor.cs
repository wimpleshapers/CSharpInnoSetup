
using CodingMuscles.CSharpInnoSetup.Utilities;
using ICSharpCode.Decompiler.CSharp.Syntax;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    internal class ExceptionVisitor : PascalScriptVisitor
    {
        public ExceptionVisitor(PascalScriptVisitorContext context) : base(context)
        {

        }

        public override void VisitObjectCreateExpression(ObjectCreateExpression syntax)
        {
            WriteLParen();

            syntax.Arguments.ForEach((arg, index) =>
            {
                if(index > 0)
                {
                    WriteComma();
                }

                arg.Visit(this);
            });

            WriteRParen();
        }
    }
}
