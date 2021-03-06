
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public class TCustomControl : TWinControl
    {
        /// <summary>
        /// Initializes a new <see cref="TCustomControl"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TCustomControl(TComponent AOwner) : base(AOwner) { }
    }
}