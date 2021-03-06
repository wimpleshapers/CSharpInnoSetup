
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public class TCustomMemo : TCustomEdit
    {
        /// <summary>
        /// Initializes a new <see cref="TCustomMemo"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TCustomMemo(TComponent AOwner) : base(AOwner) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TStrings Lines { get; set; }
    }
}