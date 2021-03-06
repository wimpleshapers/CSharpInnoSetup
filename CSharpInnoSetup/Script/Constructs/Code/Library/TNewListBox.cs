
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TNewListBox : TListBox
    {
        /// <summary>
        /// Initializes a new <see cref="TNewListBox"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TNewListBox(TComponent AOwner) : base(AOwner) { }
    }
}