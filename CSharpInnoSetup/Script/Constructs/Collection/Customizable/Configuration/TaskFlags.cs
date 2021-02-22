
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_taskssection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum TaskFlags
    {
        /// <summary>
        /// Specifies that the task can be checked when none of its children are. By default, if no Tasks parameter directly 
        /// references the task, unchecking all of the task's children will cause the task to become unchecked.
        /// </summary>
        [Alias("checkablealone")]
        CheckableAlone = 0x1,

        /// <summary>
        /// Instructs Setup that this task should be unchecked initially when Setup finds a previous version of the same application 
        /// is already installed.
        /// </summary>
        /// <remarks>
        /// If the UsePreviousTasks [Setup] section directive is no, this flag is effectively disabled.
        /// </remarks>
        [Alias("checkedonce")]
        CheckedOnce = 0x2,

        /// <summary>
        /// Specifies that the task should not automatically become checked when its parent is checked. Has no effect on top-level 
        /// tasks, and cannot be combined with the exclusive flag.
        /// </summary>
        [Alias("dontinheritcheck")]
        DoNotInheritCheck = 0x4,

        /// <summary>
        /// Instructs Setup that this task is mutually exclusive with sibling tasks that also have the exclusive flag.
        /// </summary>
        [Alias("exclusive")]
        Exclusive = 0x8,

        /// <summary>
        /// Instructs Setup to ask the user to restart the system at the end of installation if this task is selected, regardless 
        /// of whether it is necessary (for example because of [Files] section entries with the restartreplace flag). Like AlwaysRestart 
        /// but per task.
        /// </summary>
        [Alias("restart")]
        Restart = 0x10,

        /// <summary>
        /// Instructs Setup that this task should be unchecked initially.
        /// </summary>
        [Alias("unchecked")]
        Unchecked = 0x20
    }
}
