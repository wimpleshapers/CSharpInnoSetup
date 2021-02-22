
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Generates the sign tool command
    /// </summary>
    /// <param name="filename">The placeholder to use for the name of the file to be signed</param>
    /// <param name="param">The placeholder to use for sign tool parameters</param>
    /// <returns>The sign tool command line</returns>
    public delegate string SignToolCommand(string filename, string param);
}
