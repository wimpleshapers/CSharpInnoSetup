
using System;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// The maximum number of bytes per disk slice
    /// </summary>
    public class DiskSliceSize
    {
        private readonly string _value;

        /// <summary>
        /// Retrieves a <see cref="DiskSliceSize"/> value that represents "max"
        /// </summary>
        public static DiskSliceSize Max { get; } = new DiskSliceSize("max");

        /// <summary>
        /// Constructs a <see cref="DiskSliceSize"/> value that represents a number of bytes
        /// </summary>
        public DiskSliceSize From(uint value)
        {
            if(value < 262144 || value > 2100000000)
            {
                throw new ArgumentOutOfRangeException(nameof(DiskSliceSize));
            }

            return new DiskSliceSize(value.ToString(CultureInfo.InvariantCulture));
        }

        private DiskSliceSize(string value)
        {
            _value = value;
        }
    }
}
