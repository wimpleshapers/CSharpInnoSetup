
using System;
using System.Globalization;
using System.IO;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Indicates a file containing an icon
    /// </summary>
    public class IconFile
    {
        private readonly string _iconFilename;

        /// <summary>
        /// Initialzies a new <see cref="IconFile"/>
        /// </summary>
        /// <param name="fileInfo">The file containing the icon</param>
        /// <param name="iconIndex">If the file contains multiple icons, the index</param>
        public IconFile(FileInfo fileInfo, int? iconIndex = null)
        {
            _iconFilename = fileInfo.ToString();

            if(iconIndex.HasValue)
            {
                _iconFilename += $",{Convert.ToString(iconIndex.Value, CultureInfo.InvariantCulture)}";
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return _iconFilename;
        }
    }
}
