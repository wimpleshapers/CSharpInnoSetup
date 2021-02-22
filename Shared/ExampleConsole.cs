
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CodingMuscles.CSharpInnoSetup.Example
{
    public static class ExampleConsole
    {
        public static int Run<T>(Func<T> installationFactory, FileInfo scriptFileInfo, int usedArgCount=2) where T : Installation
        {
            var pause = Environment.GetCommandLineArgs().Skip(usedArgCount).Contains("/pause");

            try
            {
                using (var textWriter = new DiagnosticStreamWriter(new StreamWriter(scriptFileInfo.FullName, false, Encoding.UTF8)))
                {
                    var installation = installationFactory();
                    installation.Save(textWriter);
                }

                if (pause)
                    Console.ReadLine();
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

                if (pause)
                    Console.ReadLine();

                return 1;
            }

            return 0;
        }
    }
}

