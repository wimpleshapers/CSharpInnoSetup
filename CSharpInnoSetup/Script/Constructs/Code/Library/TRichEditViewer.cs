
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TRichEditViewer : TMemo
    {
        /// <summary>
        /// Initializes a new <see cref="TRichEditViewer"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TRichEditViewer(TComponent AOwner) : base(AOwner) { }

        //public TAnchors Anchors { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TBevelKind BevelKind { get; set; }
        //public TBorderStyle BorderStyle { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public AnsiString RTFText { set => throw new NotSupportedException(); }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public bool UseRichEdit { get; set; }
    }
}