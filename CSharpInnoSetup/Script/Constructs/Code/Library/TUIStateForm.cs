
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public class TUIStateForm : TForm
    {
        /// <summary>
        /// Initializes a new <see cref="TUIStateForm"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TUIStateForm(TComponent AOwner) : base(AOwner) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public new static TUIStateForm CreateNew(TComponent AOwner) => null;
    }
}