
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code
{
    /// <summary>
    /// Attribute applied to fields that are initialized from command line arguments
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class CommandLineParameterAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new <see cref="CommandLineParameterAttribute"/>
        /// </summary>
        /// <param name="switchName"><see cref="SwitchName"/></param>
        public CommandLineParameterAttribute(string switchName = null)
        {
            SwitchName = switchName;
        }

        /// <summary>
        /// The name of the command line switch or, if null, indicates the 
        /// switch name is the same as the name of the field to which this 
        /// attribute is applied
        /// </summary>
        public string SwitchName { get; }
    }
}
