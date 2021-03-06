
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TNewCheckBox : TCheckBox
    {
        /// <summary>
        /// Initializes a new <see cref="TNewCheckBox"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TNewCheckBox(TComponent AOwner) : base(AOwner) { }
    }
}