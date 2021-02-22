
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive
{
    /// <summary>
    /// Commpression method and level
    /// </summary>
    public class Compression
    {
        private readonly string _value;

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip = new Compression(CompressionMethod.Zip);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip1 = new Compression(CompressionMethod.Zip, 1);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip2 = new Compression(CompressionMethod.Zip, 2);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip3 = new Compression(CompressionMethod.Zip, 3);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip4 = new Compression(CompressionMethod.Zip, 4);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip5 = new Compression(CompressionMethod.Zip, 5);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip6 = new Compression(CompressionMethod.Zip, 6);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip7 = new Compression(CompressionMethod.Zip, 7);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip8 = new Compression(CompressionMethod.Zip, 8);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Zip9 = new Compression(CompressionMethod.Zip, 9);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip = new Compression(CompressionMethod.Bzip);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip1 = new Compression(CompressionMethod.Bzip, 1);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip2 = new Compression(CompressionMethod.Bzip, 2);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip3 = new Compression(CompressionMethod.Bzip, 3);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip4 = new Compression(CompressionMethod.Bzip, 4);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip5 = new Compression(CompressionMethod.Bzip, 5);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip6 = new Compression(CompressionMethod.Bzip, 6);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip7 = new Compression(CompressionMethod.Bzip, 7);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip8 = new Compression(CompressionMethod.Bzip, 8);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Bzip9 = new Compression(CompressionMethod.Bzip, 9);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma = new Compression(CompressionMethod.Lzma);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression LzmaNormal = new Compression(CompressionMethod.Lzma, CompressionLevel.Normal);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression LzmaFast = new Compression(CompressionMethod.Lzma, CompressionLevel.Fast);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression LzmaMax = new Compression(CompressionMethod.Lzma, CompressionLevel.Max);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression LzmaUltra = new Compression(CompressionMethod.Lzma, CompressionLevel.Ultra);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression LzmaUltra2 = new Compression(CompressionMethod.Lzma, CompressionLevel.Ultra2);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma2 = new Compression(CompressionMethod.Lzma);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma2Normal = new Compression(CompressionMethod.Lzma2, CompressionLevel.Normal);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma2Fast = new Compression(CompressionMethod.Lzma2, CompressionLevel.Fast);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma2Max = new Compression(CompressionMethod.Lzma2, CompressionLevel.Max);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma2Ultra = new Compression(CompressionMethod.Lzma2, CompressionLevel.Ultra);

        /// <summary>
        /// Inno <a href="https://jrsoftware.org/ishelp/index.php?topic=setup_compression">Documentation</a>
        /// </summary>
        public static Compression Lzma2Ultra2 = new Compression(CompressionMethod.Lzma2, CompressionLevel.Ultra2);

        /// <see cref="object.ToString"/>
        public override string ToString()
        {
            return _value;
        }

        private Compression(CompressionMethod method, int? level = null)
        {
            _value = method.ToString();

            if(level.HasValue)
            {
                _value += string.Format("/{0}", level);
            }
        }

        private Compression(CompressionMethod method, CompressionLevel level)
        {
            _value = method.ToString() + "/" + level.ToString();
        }
    }
}
