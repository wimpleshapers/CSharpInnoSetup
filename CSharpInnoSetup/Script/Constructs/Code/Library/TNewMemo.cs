
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TNewMemo : TMemo
    {
        /// <summary>
        /// Initializes a new <see cref="TNewMemo"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TNewMemo(TComponent AOwner) : base(AOwner) { }
    }
}

