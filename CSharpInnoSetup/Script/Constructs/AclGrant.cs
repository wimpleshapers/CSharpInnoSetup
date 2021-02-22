
namespace CodingMuscles.CSharpInnoSetup.Script.Constructs
{
    /// <summary>
    /// The level of control to grant to an object
    /// </summary>
    public enum AclGrant
    {
        /// <summary>
        /// Grants "Full Control" permission, which is the same as modify (see below), but additionally allows the 
        /// specified user/group to take ownership of the directory and change its permissions. Use sparingly; generally, 
        /// <see cref="Modify"/> is sufficient.
        /// </summary>
        [Alias("full")]
        Full,

        /// <summary>
        /// Grants "Modify" permission, which allows the specified user/group to read, execute, create, modify, and 
        /// delete files in the directory and its subdirectories.
        /// </summary>
        [Alias("modify")]
        Modify,

        /// <summary>
        /// Grants "Read and Execute" permission, which allows the specified user/group to read and execute files in
        /// the directory and its subdirectories.
        /// </summary>
        [Alias("readexec")]
        ReadExec
    }
}
