
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public class THandleStream : TStream
    {
        /// <summary>
        /// Initializes a new <see cref="THandleStream"/>
        /// </summary>
        /// <param name="AHandle">The underlying handle</param>
        public THandleStream(int AHandle) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public int Handle { get; }
    }
}
