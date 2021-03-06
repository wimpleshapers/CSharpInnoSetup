
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TOutputMsgWizardPage : TWizardPage
    {
        /// <summary>
        /// Initializes a new <see cref="TOutputMsgWizardPage"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TOutputMsgWizardPage(TComponent AOwner) : base(AOwner) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TNewStaticText MsgLabel { get; }
    }
}
