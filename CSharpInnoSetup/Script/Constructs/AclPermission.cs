
using CodingMuscles.CSharpInnoSetup.Converter;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// Used to express a level of rights granted to a user or group
    /// </summary>
    public sealed class AclPermission
    {
        private static EnumToStringConverter<AclGrant> _grantConverter = new EnumToStringConverter<AclGrant>();

        /// <summary>
        /// Initializes a new <see cref="AclPermission"/>
        /// </summary>
        /// <param name="identifier">The name of the user or group being granted rights</param>
        /// <param name="grant">The level of rights granted to the <paramref name="identifier"/></param>
        public AclPermission(string identifier, AclGrant grant)
        {
            Identifier = identifier;
            Grant = grant;
        }

        /// <summary>
        /// The name of the user or group being granted rights
        /// </summary>
        public string Identifier { get; private set; }

        /// <summary>
        /// The level of rights granted to the<see cref="Identifier"/>
        /// </summary>
        public AclGrant Grant { get; private set; }

        /// <see cref="object.ToString"/>
        /// <summary>
        /// Returns a string in the format of "{identifer}-{grant}"
        /// </summary>
        public override string ToString()
        {
            return $"{Identifier}-{_grantConverter.ConvertTo(Grant, typeof(string))}";
        }
    }
}
