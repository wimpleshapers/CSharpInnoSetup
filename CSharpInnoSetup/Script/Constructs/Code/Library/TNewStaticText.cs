
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
    /// </summary>
    [BuiltInSymbol]
    public sealed class TNewStaticText : TWinControl
    {
        /// <summary>
        /// Initializes a new <see cref="TNewStaticText"/>
        /// </summary>
        /// <param name="AOwner">The owner component</param>
        public TNewStaticText(TComponent AOwner) : base(AOwner) { }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public int AdjustHeight() => 0;

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TAnchors Anchors { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public bool AutoSize { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public string Caption { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TColor Color { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TWinControl FocusControl { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public TFont Font { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public bool ForceLTRReading { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public bool ShowAccelChar { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public bool WordWrap { get; set; }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public event TNotifyEvent OnClick { add { } remove { } }

        /// <summary>
        /// Inno Setup <a href="https://jrsoftware.org/ishelp/index.php?topic=scriptclasses">Documentation</a>
        /// </summary>
        public event TNotifyEvent OnDblClick { add { } remove { } }
    }
}
