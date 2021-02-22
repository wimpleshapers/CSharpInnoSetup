
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// That that can be sourced by the installer, either from the 
    /// default source location or the compiler folder
    /// </summary>
    public class SourcedFile
    {
        private readonly string _fileName;

        /// <summary>
        /// Creates a <see cref="SourcedFile"/> from a <see cref="FileInfo"/> object
        /// </summary>
        /// <param name="fileInfo">The object from which the new one is based</param>
        /// <returns>A new instance of a <see cref="SourcedFile"/></returns>
        public static SourcedFile From(FileInfo fileInfo)
        {
            return new SourcedFile(fileInfo.ToString());
        }

        /// <summary>
        /// Creates a <see cref="SourcedFile"/> from a <see cref="DirectoryInfo"/> object and string
        /// </summary>
        /// <param name="directoryInfo">The root folder</param>
        /// <param name="fileName">The name of the file</param>
        /// <returns>A new instance of a <see cref="SourcedFile"/></returns>
        public static SourcedFile From(DirectoryInfo directoryInfo, string fileName)
        {
            return new SourcedFile(Path.Combine(directoryInfo.FullName, fileName));
        }

        /// <summary>
        /// Creates a <see cref="SourcedFile"/> from a string path
        /// </summary>
        /// <param name="filePath">The full path of the source file</param>
        /// <returns>A new instance of a <see cref="SourcedFile"/></returns>
        public static SourcedFile From(string filePath)
        {
            return new SourcedFile(filePath);
        }

        /// <summary>
        /// Creates a <see cref="SourcedFile"/> that exists in the Inno compiler folder
        /// </summary>
        /// <param name="fileInfo">The full path of the source file</param>
        /// <returns></returns>
        public static SourcedFile FromCompiler(FileInfo fileInfo)
        {
            return new SourcedFile($"compiler:{fileInfo}");
        }

        /// <summary>
        /// Creates a <see cref="SourcedFile"/> that exists in the Inno compiler folder
        /// </summary>
        /// <param name="fileName">The full path of the source file</param>
        /// <returns>A new instance of a <see cref="SourcedFile"/></returns>
        public static SourcedFile FromCompiler(string fileName)
        {
            return new SourcedFile($"compiler:{fileName}");
        }

        /// <summary>
        /// Convenience operator for converting from a <see cref="string"/>
        /// </summary>
        /// <param name="source">The string from which to convert</param>
        public static implicit operator SourcedFile(string source) => From(source);

        /// <summary>
        /// Convenience operator for converting from a <see cref="FileInfo"/>
        /// </summary>
        /// <param name="source">The <see cref="FileInfo"/> from which to convert</param>
        public static implicit operator SourcedFile(FileInfo source) => From(source);

        /// <see cref="object.ToString"/>
        public override string ToString()
        {
            return _fileName;
        }

        private SourcedFile(string fileName)
        {
            _fileName = fileName;
        }
    }
}
