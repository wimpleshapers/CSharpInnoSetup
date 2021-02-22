
using CodingMuscles.CSharpInnoSetup.Generation.Output;
using CodingMuscles.CSharpInnoSetup.Utilities;
using NSubstitute;
using System.IO;
using System.Linq;
using Xunit;

namespace CodingMuscles.CSharpInnoSetup.Test.Generation.Output
{
    public class SnippetTests
    {
        [Theory]
        [InlineData("one", "one")]
        [InlineData("one\r\ntwo", "one", "two")]
        [InlineData("one\r\ntwo\r\nthree", "one", "two", "three")]
        [InlineData("one\r\ntwo\r\n\r\nthree", "one", "two", "", "three")]
        [InlineData("one\r\ntwo\r\nthree\r\n", "one", "two", "three")]
        public void TestWriteLines(string input, params string[] expectedLines)
        {
            using(var snippet = new Snippet())
            {
                var writer = (TextWriter)snippet;
                writer.Write(input);

                var actualLines = snippet.Lines.ToArray();
                Assert.Equal(expectedLines.Length, actualLines.Length);
                Assert.True(Enumerable.SequenceEqual(expectedLines, actualLines));
            }
        }

        [Theory]
        [InlineData(1, "")]
        [InlineData(2, "one", "two")]
        [InlineData(3, "one", "", "two")]
        [InlineData(4, "one", "", "two", "")]
        public void TestCopyTo(int lineCount, params string[] lines)
        {
            using (var snippet = new Snippet())
            {
                var writer = (TextWriter)snippet;
                lines.ForEach(l => writer.WriteLine(l));

                var codeWriter = Substitute.For<ICodeWriter>();
                snippet.CopyTo(codeWriter);

                codeWriter.Received(lineCount).WriteLine(Arg.Any<string>(), Arg.Any<Indentation>());
            }
        }
    }
}
