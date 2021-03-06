
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public class TScrollingWinControl : TWinControl
    {
        /// <summary>
        /// Initializes a new <see cref="TScrollingWinControl"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TScrollingWinControl(TComponent AOwner) : base(AOwner) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public void ScrollInView(TControl AControl) { }
    }
}
