
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library
{
    /// <summary>
    /// Applied to method parameters that are of a delegate type
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class CallbackAttribute : Attribute
    {
    }
}
