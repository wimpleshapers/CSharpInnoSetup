
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Controls the speed of compression
    /// </summary>
    public class CompressionThreads
    {
        private readonly string _value;

        /// <summary>
        /// Retrieves a <see cref="CompressionThreads"/> value that represents "auto"
        /// </summary>
        public static CompressionThreads Auto { get; } = new CompressionThreads("auto");

        /// <summary>
        /// Constructs a <see cref="CompressionThreads"/> value that represents a number of threads
        /// </summary>
        public static CompressionThreads From(uint threads) => new CompressionThreads(threads.ToString(CultureInfo.InvariantCulture));

        /// <see cref="object.ToString"/>
        public override string ToString()
        {
            return _value;
        }

        private CompressionThreads(string value)
        {
            _value = value;
        }
    }
}
