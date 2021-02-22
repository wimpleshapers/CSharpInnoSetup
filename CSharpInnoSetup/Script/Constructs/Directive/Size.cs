
using System;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Value with a horizontal and vertical numerical component
    /// </summary>
    public class Size
    {
        private readonly string _size;

        /// <summary>
        /// Initializes a new <see cref="Size"/>
        /// </summary>
        /// <param name="horizontal">The horizontal component</param>
        /// <param name="vertical">The vertical component</param>
        public Size(uint horizontal, uint vertical)
        {
            _size = $"{Convert.ToString(horizontal, CultureInfo.InvariantCulture)},{Convert.ToString(vertical, CultureInfo.InvariantCulture)}";
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _size;
        }
    }
}
