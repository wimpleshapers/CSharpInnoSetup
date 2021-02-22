
using System;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Attribute applied to methods that map to Inno Setup event handlers
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    internal class EventHandlerAttribute : Attribute
    {
    }
}
