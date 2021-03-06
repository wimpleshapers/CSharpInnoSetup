
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TNewEdit : TEdit
    {
        /// <summary>
        /// Initializes a new <see cref="TNewEdit"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TNewEdit(TComponent AOwner) : base(AOwner) { }
    }
}
