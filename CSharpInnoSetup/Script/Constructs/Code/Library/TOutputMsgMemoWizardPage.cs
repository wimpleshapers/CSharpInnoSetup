
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TOutputMsgMemoWizardPage : TWizardPage
    {
        /// <summary>
        /// Initializes a new <see cref="TOutputMsgMemoWizardPage"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TOutputMsgMemoWizardPage(TComponent AOwner) : base(AOwner) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TRichEditViewer RichEditViewer { get; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TNewStaticText SubCaptionLabel { get; }
    }
}
