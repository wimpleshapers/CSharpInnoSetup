
using System;

namespace CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration
{
    /// <summary>
    /// Inno Setup <a href="https://jrsoftware.org/ishelp/topic_componentssection.htm">Documentation</a>
    /// </summary>
    [Flags]
    public enum ComponentFlags
    {
        /// <summary>
        /// Specifies that the component can be checked when none of its children are. By default, if no Components parameter directly 
        /// references the component, unchecking all of the component's children will cause the component to become unchecked.
        /// </summary>
        [Alias("checkablealone")]
        CheckableAlone = 0x1,

        /// <summary>
        /// Specifies that the component should not automatically become checked when its parent is checked. Has no effect on top-level 
        /// components, and cannot be combined with the exclusive flag.
        /// </summary>
        [Alias("dontinheritcheck")]
        DoNotInheritCheck = 0x2,

        /// <summary>
        /// Instructs Setup that this component is mutually exclusive with sibling components that also have the exclusive flag.
        /// </summary>
        [Alias("exclusive")]
        Exclusive = 0x4,

        /// <summary>
        /// Instructs Setup that this component can not be manually selected or unselected by the end user during installation.
        /// </summary>
        [Alias("fixed")]
        Fixed = 0x8,

        /// <summary>
        /// Instructs Setup to ask the user to restart the system if this component is installed, regardless of whether this is necessary 
        /// (for example because of <see cref="FileEntry"/> entries with the restartreplace flag). Like AlwaysRestart but per component.
        /// </summary>
        [Alias("restart")]
        Restart = 0x10,

        /// <summary>
        /// Instructs Setup not to warn the user that this component will not be uninstalled after he/she deselected this component when 
        /// it's already installed on his/her machine.  Depending on the complexity of your components, you can try to use the [InstallDelete] 
        /// section and this flag to automatically 'uninstall' deselected components.
        /// </summary>
        [Alias("disablenouninstallwarning")]
        DisableNounInstallWarning = 0x20
    }
}
