
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// A date, time, or phrase that represents a point in time 
    /// </summary>
    public sealed class Timestamp
    {
        private readonly string _value;

        /// <summary>
        /// The current time
        /// </summary>
        public static Timestamp Current => new Timestamp("current");

        /// <summary>
        /// Used when a timestamp is not specified
        /// </summary>
        public static Timestamp None => new Timestamp("none");

        /// <summary>
        /// Creates a timestamp from a date
        /// </summary>
        /// <param name="dateTime">The date to use</param>
        /// <returns>An instance of a <see cref="Timestamp"/></returns>
        public static Timestamp From(DateTime dateTime)
        {
            return new Timestamp(string.Format("{0:yyyy-mm-dd}", dateTime));
        }

        /// <summary>
        /// Creates a timestamp from a time
        /// </summary>
        /// <param name="timeSpan">The time to use</param>
        /// <returns>An instance of a <see cref="Timestamp"/></returns>
        public static Timestamp From(TimeSpan timeSpan)
        {
            return new Timestamp(string.Format("{0:hh\\:mm\\:ss}", timeSpan));
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _value;
        }

        private Timestamp(string value)
        {
            _value = value;
        }
    }
}
