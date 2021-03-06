
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TNewButton : TButton
    {
        /// <summary>
        /// Initializes a new <see cref="TNewButton"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TNewButton(TComponent AOwner) : base(AOwner) { }
    }
}