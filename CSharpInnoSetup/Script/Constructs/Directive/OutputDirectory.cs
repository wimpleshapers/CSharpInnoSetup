
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Specifies an output folder
    /// </summary>
    public class OutputDirectory
    {
        private readonly string _value;

        /// <summary>
        /// Creates an output folder from a <see cref="DirectoryInfo"/> object
        /// </summary>
        /// <param name="directoryInfo">The directory</param>
        /// <returns>A new instance of a <see cref="OutputDirectory"/></returns>
        public static OutputDirectory From(DirectoryInfo directoryInfo)
        {
            return new OutputDirectory(directoryInfo.ToString());
        }

        /// <summary>
        /// Creates an output folder from a subfolder off the "userdocs" folder
        /// </summary>
        /// <param name="subfolder">The subfolder</param>
        /// <returns>A new instance of a <see cref="OutputDirectory"/></returns>
        public static OutputDirectory UserDocs(string subfolder)
        {
            return new OutputDirectory($"userdocs:{subfolder}");
        }

        /// <see cref="object.ToString"/>
        public override string ToString()
        {
            return _value;
        }

        private OutputDirectory(string value)
        {
            _value = value;
        }
    }
}
