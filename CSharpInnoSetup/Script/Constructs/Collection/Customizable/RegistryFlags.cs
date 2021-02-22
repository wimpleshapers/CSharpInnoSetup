
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_registrysection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum RegistryFlags
    {
        /// <summary>
        /// Create the value only if a value of the same name doesn't already exist. This flag has no effect if the 
        /// data type is <see cref="RegistryDataType.None"/>, or if you specify the <see cref="DeleteKey"/> flag.
        /// </summary>
        [Alias("createvalueifdoesntexist")]
        CreateValueIfDoesNotExist = 0x1,

        /// <summary>
        /// Try deleting the entire key if it exists, including all values and subkeys in it. If <see cref="RegistryEntry.ValueType"/>
        /// is not none, it will then create a new key and value.
        /// </summary>
        /// <remarks>
        /// To prevent disasters, this flag is ignored during installation if <see cref="RegistryEntry.Subkey"/> is blank 
        /// or contains only backslashes.
        /// </remarks>
        [Alias("deletekey")]
        DeleteKey = 0x2,

        /// <summary>
        /// Try deleting the value if it exists. If <see cref="RegistryEntry.ValueType"/> is not 
        /// <see cref="RegistryDataType.None"/>, it will then create the key if it didn't already exist, and the new value.
        /// </summary>
        [Alias("deletevalue")]
        DeleteValue = 0x4,

        /// <summary>
        /// Do not attempt to create the key or any value if the key did not already exist on the user's system. No error 
        /// message is displayed if the key does not exist.
        /// </summary>
        /// <remarks>
        /// Typically this flag is used in combination with the <see cref="RegistryFlags.UninstallDeleteKey"/> flag, for 
        /// deleting keys during uninstallation but not creating them during installation.
        /// </remarks>
        [Alias("dontcreatekey")]
        DoNotCreateKey = 0x8,

        /// <summary>
        /// Don't display an error message if Setup fails to create the key or value for any reason.
        /// </summary>
        [Alias("noerror")]
        NoError = 0x10,

        /// <summary>
        /// If the value did not already exist or the existing value isn't a string type (REG_SZ or REG_EXPAND_SZ), 
        /// it will be created with the type specified by ValueType. If the value did exist and is a string type, it 
        /// will be replaced with the same value type as the pre-existing value. 
        /// </summary>
        /// <remarks>
        /// This is only applicable when the ValueType parameter is <see cref="RegistryDataType.String"/> or 
        /// <see cref="RegistryDataType.ExpandedString"/>.
        /// </remarks>
        [Alias("preservestringtype")]
        PreserveStringType = 0x20,

        /// <summary>
        /// When the program is uninstalled, set the value's data to a null string (type REG_SZ). This flag cannot 
        /// be combined with the <see cref="RegistryFlags.UninstallDeleteKey"/> flag.
        /// </summary>
        [Alias("uninsclearvalue")]
        UninstallClearValue = 0x40,

        /// <summary>
        /// When the program is uninstalled, delete the entire key, including all values and subkeys in it.  It obviously 
        /// wouldn't be a good idea to use this on a key that is used by Windows itself. You should only use this on keys 
        /// private to your application.
        /// </summary>
        /// <remarks>To prevent disasters, this flag is ignored during installation if Subkey is blank or contains only backslashes.
        /// </remarks>
        [Alias("uninsdeletekey")]
        UninstallDeleteKey = 0x80,

        /// <summary>
        /// When the program is uninstalled, delete the key if it has no values or subkeys left in it.  This flag can be 
        /// combined with <see cref="UninstallDeleteValue"/>.
        /// </summary>
        /// <remarks>
        /// To prevent disasters, this flag is ignored during installation if Subkey is blank or contains only backslashes.
        /// </remarks>
        [Alias("uninsdeletekeyifempty")]
        UninstallDeleteKeyIfEmpty = 0x100,

        /// <summary>
        /// Delete the value when the program is uninstalled.This flag can be combined with uninsdeletekeyifempty.
        /// </summary>
        /// <remarks>
        /// In Inno Setup versions prior to 1.1, you could use this flag along with the data type none and it would 
        /// function as a "delete key if empty" flag.  This technique is no longer supported.  You must now use the 
        /// <see cref="RegistryFlags.UninstallDeleteKeyIfEmpty"/> flag to accomplish this.
        /// </remarks>
        [Alias("uninsdeletevalue")]
        UninstallDeleteValue = 0x200
    }
}
