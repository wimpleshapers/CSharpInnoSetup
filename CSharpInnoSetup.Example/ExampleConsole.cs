
using System;
using System.IO;
using System.Text;

namespace CodingMuscles.CSharpInnoSetup.Example
{
    public static class ExampleConsole
    {
        public static void Run<T>(Func<T> installationFactory, FileInfo scriptFileInfo) where T : Installation
        {
            try
            {
                using (var textWriter = new DiagnosticStreamWriter(new StreamWriter(scriptFileInfo.FullName, false, Encoding.UTF8)))
                {
                    var installation = installationFactory();
                    installation.Save(textWriter);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Unable to build script:");

                while (ex != null)
                {
                    Console.Error.WriteLine(ex.Message);
                    Console.Error.WriteLine(ex.StackTrace);

                    ex = ex.InnerException;
                }

                Environment.Exit(1);
            }
        }
    }
}

