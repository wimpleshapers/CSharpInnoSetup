
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Foreground color
    /// </summary>
    public class Color
    {
        private readonly string _color;

        /// <summary>
        /// Creates a color instance based on RBG values
        /// </summary>
        /// <param name="red">The red component</param>
        /// <param name="green">The green component</param>
        /// <param name="blue">The blue component</param>
        /// <returns>A new instance of <see cref="Color"/></returns>
        public static Color From(byte red, byte green, byte blue)
        {
            return new Color($"${red:X2}{green:X2}{blue:X2}");
        }

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Black => Color.FromName(nameof(Black));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Maroon => Color.FromName(nameof(Maroon));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Green => Color.FromName(nameof(Green));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Olive => Color.FromName(nameof(Olive));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Navy => Color.FromName(nameof(Navy));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Purple => Color.FromName(nameof(Purple));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Teal => Color.FromName(nameof(Teal));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Gray => Color.FromName(nameof(Gray));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Silver => Color.FromName(nameof(Silver));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Red => Color.FromName(nameof(Red));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Lime => Color.FromName(nameof(Lime));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Yellow => Color.FromName(nameof(Yellow));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Blue => Color.FromName(nameof(Blue));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Fuchsia => Color.FromName(nameof(Fuchsia));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color Aqua => Color.FromName(nameof(Aqua));

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/topic_setup_backcolor.htm">Documentation</a>
        /// </summary>
        public static Color White => Color.FromName(nameof(White));

        /// <inheritdoc/>
        public override string ToString()
        {
            return _color;
        }

        private static Color FromName(string name)
        {
            return new Color("cl" + name);
        }

        private Color(string color)
        {
            _color = color;
        }
    }
}
