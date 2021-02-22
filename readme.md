CSharpInnoSetup is a .NET Standard 2.1 library that allows you to build an Inno Setup script from C# code.  The benefits are:

* Increased visibity of Inno Setup constructs and Pascal symbols via Intellisense.
* Easier to share code between installers that are separate yet share common behavior.
* Add your Inno Setup script to your solution and build it like any other project.
* Write the [Code] section in C#.

## How It Works

Transforms constructs found in a CSharpInnoSetup 'Installation' derived class into Inno Setup script.  Properties are transformed into to [Setup] directives and methods to Pascal functions and procedures.  C# branches, loops, and try/catch blocks are automatically transformed into their Pascal equivalents.  Work with C# primitive types like `int`, `string`, and `bool`, as they are automatically transformed into `Integer`, `String`, and `Boolean`.  Essentially, any C# construct that has an Inno Setup Pascal equivalent is supported.  This excludes .NET non-primitive classes, async programming, foreach loops, or custom classes, for example.  

## Get up and running in 5 minutes:

1. Create a console project in your Visual Studio solution.  Both .NET Framework and .NET Core are supported.
2. Add a reference to the Nuget package CodingMuscles.CSharpInnoSetup.
3. Add a class to the project derived from CodingMuscles.CSharpInnoSetup.Installation:

        public class MyInstallation : Installation
        {

4. Override properties and methods that should appear in the install script:

            public override Version Version => new Version(1, 0, 0, 0);
            public override string Name => "Test";
            public override DirectoryInfo InstallFolder => new DirectoryInfo("c:\\temp");

            public override bool InitializeSetup()
            {
                return true;
            }

5. In Main() of the new console project, save the script.  In this example, args[0] is the .iss file name:

        static void Main(string[] args)
        {
            using (var textWriter = new StreamWriter(args[0], false, Encoding.UTF8))
            {
                var myInstallation = new MyInstallation();
                myInstallation.Save(textWriter);
            }        
        }

6. Add a post-build step to create and compile the script:

        $(TargetDir)$(TargetName).exe "$(ProjectDir)$(IntermediateOutputPath)$(ProjectName).iss"
        "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "$(ProjectDir)$(IntermediateOutputPath)$(ProjectName).iss" /O$(TargetDir)

7.  Build the console project, and the project target folder will contain the .exe installer.  The .iss file can be found in the obj\... folder:

        [Setup] 
        AppVersion=1.0.0.0
        AppName=Test
        DefaultDirName=c:\temp
        
        [Code] 
        function InitializeSetup(): Boolean;
        begin
           Result := True;
           Exit;
        end;


Whoa, hold on - Inno Setup scripts are more complicated than that.  How do I?....

* [Add Setup Directives](#user-content-addsetupdirectives)
* [Use Constants](#user-content-useconstants)
* [Specify Languages, Types, Components, and Tasks](#user-content-configuration)
* [Add Files](#user-content-addfiles)
* [Create a Custom Method](#user-content-createcustommethod)
* [Create Custom Types](#user-content-createcustomtypes)
* [Add Messages/Custom Messages](#user-content-addmessages)
* [Add Folders](#user-content-addfolders)
* [Add Registry Entries](#user-content-addregentries)
* [Add INI Entries](#user-content-addinientries)
* [Add Icons](#user-content-addicons)
* [Add Uninstall Delete/Install Delete Entries](#user-content-uninstallinstalldelete)
* [Perform Loops](#user-content-performloops)
* [Use Global Variables](#user-content-useglobalvariables)
* [Reference an External Function](#user-content-refexternalfunction)
* [Handle Exceptions](#user-content-handleexceptions)
* [Perform Logic Operations](#user-content-performlogicoperations)
* [Handle Setup Events](#user-content-handlesetupevents)
* [Subscribe to Events](#user-content-subscribetoevents)
* [Use Built-in Types](#user-content-usebuiltintypes)
* [Call a Support Function](#user-content-callsupportfunction)
* [Access Command Line Parameters](#user-content-comandlineparameters)
* [Instantiate Objects](#user-content-instantiateobjects)
* [Specify a Check Parameter](#user-content-specifycheckparameter)
* [Specify a Components Parameter](#user-content-specifycomponentsparameter)
* [Specify a Tasks Parameter](#user-content-specifytasksparameter)
* [Share Common Installer Behavior](#user-content-sharecommonbehavior)



# Add Setup Directives
<a name="addsetupdirectives"/>

The `Installation` class declares dozens of virtual properties.  Each property represents a directive in either the [Setup] or [LanguageOptions] sections.  When a property is overridden in a derived class, its value is written to its associated directive.  For example:

        .
        .
        .
        public override string Name => "CSharpInnoSetupDemo";
        public override string Publisher => "Coding Muscles, Inc.";
        public override Uri PublisherUrl => new Uri("https://github.com/wimpleshapers/CSharpInnoSetup");
        public override Uri SupportUrl => PublisherUrl;
        public override Uri UpdatesUrl => PublisherUrl;
        public override string Copyright => $"Copyright Coding Muscles 2020";
        public override bool EnableLogging => true;
        public override string Mutex => new Guid("15039222-e1fc-4130-9efa-7b509676e803").ToString();
        public override bool DisableReadyMemo => false;
        public override DirectoryInfo InstallFolder => new DirectoryInfo(Path.Combine(__commonpf, "CodingMuscles", Name));
        .
        .
        .

Properties that are not overridden are skipped and not written to the script.  There is typically a one-to-one relationship between a property and directive.  Though, it is possible for a property to represent multiple directives.  For example, the property `Locale` represents the [LanguageOptions] directives _LanguageName_, _LanguageCodePage_, and _RightToLeft_. 

# Use Constants
<a name="useconstants"/>

The Installation class declares a member for each Inno Setup constant.  For example, {app} is represented by the field __app, and {tmp} is represented by the field __tmp.  More sophisticated constants, like {ini} and {code}, are represented by the methods __ini() and __code().  When the script is generated, these constants are are replaced with their Inno Setup equivalents.  For example:

        builder().Source("..\\temp\\blah.txt").Destination($"{__app}\\Folder")

Becomes... 

        Source: "..\\temp\\blah.txt"; DestDir: "{app}\Folder"

And is even replaced when used in a method:

        public bool InitializeSetup()
        {
            Log($"{__code(() => GetDebugMessage});
        }

Becomes...

        function InitializeSetup: Boolean;
        begin
            Log('{code:GetDebugMessage}');
        end;

Using Installation constants within interpolated strings, as demonstrated above, evokes a {} syntax similar to the one used by Inno Setup, but it is not required.  They can just as easily appear outside an interpolated string.  Also, the only significance to the double-underscore naming convention was to make the constants easier to find via Intellisense.

# Specify Languages, Types, Components, and Tasks
<a name="configuration"/>

These entries are related in that the user decides which of them are enabled at the time of installation.  Their appearance is similar to other parameterized entries, but are assigned a unique `Name`.  For example:

        [Languages]
        Name: "en"; MessagesFile: "compiler:Default.isl"
        Name: "nl"; MessagesFile: "compiler:Languages\Dutch.isl"

With CSharpInnoSetup, entries with a `Name` are defined using anonymous types.  These include languages, types/custom messages/messages, components, and tasks.  They must be defined in that order, using a sequence of builders that are chained together.  Start by overriding the property `ParameterizedEntriesBuilderHandler`, and add languages:

        public override Action<IParameterizedEntriesBuilder> ParameterizedEntriesBuilderHandler => entriesBuilder =>
        {
            var typesBuilder = entriesBuilder.LanguagesBuilder.AddLanguages(builder => new
            {
                English = builder().AddMessageFile(MessageFile.FromCompiler(new FileInfo("Default.isl"))).Build(),
                Dutch = builder().AddMessageFile(MessageFile.FromCompiler(new FileInfo("c:\\test.txt")).Build()
            });

If no languages are required, the anonymous type must still be declared, but won't contain any properties:

            var typesBuilder = entriesBuilder.LanguagesBuilder.AddLanguages(builder => new { });

The object it returns, `typesBuilder`, allows you to specify the [Types] section.  For example:

        [Types]
        Name: "full"; Description: "Full installation"
        Name: "compact"; Description: "Compact installation"
        Name: "custom"; Description: "Custom installation"; Flags: iscustom

This would be represented by the anonymous object:

            var componentsBuilder = typesBuilder.Add((builder, languages) => new
            {
                Full = builder().Description("Full Installation").Build(),
                Compact = builder().Description("Compact Installation").Build(),
                Custom = builder().Description("Custom Installation").Flags(SetupTypeFlags.IsCustom).Build()
            }, ...

Custom Messages and Messages are also defined by the `typesBuilder` as anonymous types:

            var componentsBuilder = typesBuilder.Add((builder, languages) => new
            {
                Full = builder().Description("Full Installation").Build(),
                Compact = builder().Description("Compact Installation").Build(),
                Custom = builder().Description("Custom Installation").Flags(SetupTypeFlags.IsCustom).Build()
            }, languages => new
            {
                CustomMessage1 = new Message("Hi there", () => languages.English)
            }, languages => new 
            {
                Message1 = new Message("Hi there") 
            });

Notice that entries defined here can be associated with ones defined earlier.  For example, `CustomMessage1` is associated with `English` by referencing its strong type in the expression `() => languages.English`.  A type can be associated with a language as well by using the builder method `Languages`:

                Full = builder().Description("Full Installation").Languages(() => languages.English).Build(),

The object the `typesBuilder` returns, `componentsBuilder`, allows you to specify the [Components] section.  For example:

        [Components]
        Name: "main"; Description: "Main Files"; Flags: fixed
        Name: "help"; Description: "Help Files"

This would be represented by the anonymous object:

            var tasksBuilder = componentsBuilder.AddComponents((builder, languages, types, customMessages, messages) =>
                new
                {
                    Main = builder().Description("Main Files").Flags(ComponentFlags.Fixed).Build(),
                    Help = builder().Description("Help Files").Build()
                });

Just as above, where it was shown that a type can be dependent upon a language, a component can be dependent upon a type:

                    Help = builder().Description("Help Files").Types(() => types.Full).Build(),
                    Help = builder().Description("Help Files").Types(() => new [] { types.Full }).Build(),

If no components are required, the anonymous type must still be declared, but won't contain any properties:

            var tasksBuilder = componentsBuilder.AddComponents((builder, languages, types, customMessages, messages) => new { })

The object the `componentsBuilder` returns, `tasksBuilder`, allows you to specify the [Tasks] section.  For example:

        [Tasks]
        Name: desktopicon; Description: "Create a &desktop icon"; GroupDescription: "Additional icons:"
        Name: desktopicon\common; Description: "For all users"; GroupDescription: "Additional icons:"
        Name: desktopicon\user; Description: "For the current user only"; GroupDescription: "Additional icons:"

The `Name` uniquely identifies the task, but also indicates a parent/child relationship.  In the above example, `desktopicon\common` is a child of `desktopicon`.  In `CSharpInnoSetup`, this relationship is represented with nested anonymous objects that are defined using a `TaskFactory`:

            var contentBuilder = tasksBuilder.AddTasks((languages, types, customMessages, messages, components) =>
            {
                var additionalIcons = "Additional icons:";

                return new
                {
                    DesktopIcon = TaskFactory.CreateParent(
                        builder => builder.Description("Create a &desktop icon").GroupDescription(additionalIcons).Build(),
                        new
                        {
                            Common = TaskFactory.CreateLeaf().Description("For all users").GroupDescription(additionalIcons).Build(),
                            User = TaskFactory.CreateLeaf().Description("For the current user only").GroupDescription(additionalIcons).Build()
                        }
                    )
                };
            });
   
If no tasks are required, the anonymous type must still be declared, but won't contain any properties:

            var contentBuilder = tasksBuilder.Add((builder, languages, types, customMessages, messages, components) => new { });

The returned type, `contentBuilder`, allows the remaining parameterized entries to be defined, including Files, Folders, Icons, for example.  

# Add Files
<a name="addfiles"/>

In the overridden `ParameterizedEntriesBuilderHandler`, `ITasksBuilder.AddTasks` returns an `IContentBuilder` with which files can be added.  For example:

        [Files]
        Source: "CTL3DV2.DLL"; DestDir: "{sys}"; Flags: onlyifdoesntexist uninsneveruninstall
        Source: "MYPROG.EXE"; DestDir: "{app}"

Unlike `Languages` and `Types`, for example, these entries are not named, and are added as an array of `FileEntry` objects:

        contentBuilder.AddFiles((builder, languages, types, customMessages, messages, components, tasks) =>
        {
            return new []
            {
                builder().Source("CTL3DV2.DLL").Destination(__sys).Flags(FileFlags.OnlyIfDoesNotExist|FileFlags.UninstallNeverRemove).Build(),
                builder().Source("MYPROG.EXE").Destination(__app).Build()
            }
        }

Files can be granted permissions:

            builder().Source("MYPROG.EXE").Destination(__app).Permission(new AclPermission("users", AclGrant.Modify)).Build()

Also, files can be specific to a language, type, component, or task:

            builder().Source("MYPROG.EXE").Destination(__app).Languages(() => languages.English).Build()
            builder().Source("MYPROG.EXE").Destination(__app).Types(() => types.Full).Build()
            builder().Source("MYPROG.EXE").Destination(__app).Components(() => components.Main || components.Help).Build()
            builder().Source("MYPROG.EXE").Destination(__app).Tasks(() => tasks.DesktopIcon).Build()

To have code called before/after the file is installed, specify a handler using `BeforeInstall` or `AfterInstall`, respectively:

            builder().Source("MYPROG.EXE").Destination(__app).BeforeInstall(filename => PrepareFolder(__app)).Build()
            builder().Source("MYPROG.EXE").Destination(__app).AfterInstall(filename => Unpack($"{__app}\Templates")).Build()

Note that, due to Inno Setup limitations, the example methods `PrepareFolder` and `Unpack` may only be passed arguments that are constants or calls to `ExpandConstant`.

# Add Messages/Custom Messages
<a name="addmessages"/>

Under construction.


# Add Folders
<a name="addfolders"/>

Under construction.


# Add Registry Entries
<a name="addregentries"/>

Under construction.


# Add INI Entries
<a name="addinientries"/>

Under construction.


# Add Icons
<a name="addicons"/>

Under construction.


# Add Uninstall/Install Delete Entries
<a name="uninstallinstalldelete"/>

Under construction.


# Create a Custom Method
<a name="createcustommethod"/>

Under construction.


# Use Built-in Types
<a name="usebuiltintypes"/>

Under construction.


# Create Custom Types
<a name="createcustomtypes"/>

Under construction.


# Perform Loops
<a name="performloops"/>

The C# `for`, `while` and `do/while` loops are supported and transformed into `while/do`, `while/do` and `repeat/until`, respectively.  The transformations for `while` and `do/while` are direct.  For a `for` loop, the initializer is moved outside the loop, and the iterator inside the loop.  For example:

        for(var i = 0; i < 2; i++) { ... }

Is transformed into:

        i := 0;
        while i < 2 do
        begin
            // ...
            i := i + 1;
        end;

And a do/while loop:

        var v = 0;
        do
        {
            // ...
            v++;
        } while (v < 2);

Is transformed into:

        v := 0;
        repeat
            // ...
            v := v + 1;
        until not (v < 2);

One iteration is performed before the condition is tested, but because `until` breaks on true, and `while` on false, a `not (...)` is automatically applied to the loop condition during transformation.  Note the C# `foreach` loop is not supported as Inno Setup does not support enumerators.

# Use Global Variables
<a name="useglobalvariables"/>

A field declared as a member of a class derived from `Installation` is available to all its member methods.  Therefore, it follows that when a field is transformed it becomes a global variable, as global variables are accessible to all functions/procedures.  For example:

        class MyInstallation : Installation
        {
            private string ServerName;

This field is transformed into a global variable:

        var
            ServerName: String;

Note that this field must be referenced/used, otherwise it will be omitted from the final transformation.


# Reference an External Function
<a name="refexternalfunction"/>

To reference an external function from an Inno Setup script it needs to be declared "external".  In C#, this is done with the [DllImport] attribute:

        [DllImport("ole32.dll", CallingConvention = CallingConvention.StdCall)] 
        private static extern int CoCreateGuid(out TGUID guid);

This is transformed into:

        function CoCreateGuid(TGUID): Integer;
           external 'CoCreateGuid@ole32.dll stdcall';

For those calling conventions not supported by [DllImport], add the attribute [ExternalSymbolOptions]:

        [ExternalSymbolOptions(ExternalSymbolOption.DelayLoad|ExternalSymbolOption.SetupOnly)]

This will allow you to make calls, in C# code, to, in this example, `CoCreateGuid`.  This will be transformed into calls to the external function.

# Handle Exceptions
<a name="handleexceptions"/>

An exception can be thrown, and a `try/catch/finally` may be place anywhere in a method.  The only restrictions are that 1) only exceptions of type
`System.Exception` may be thrown and its string constructor must be used, and 2) the catch block can not specify a type.  For example:

        try
        {
            if(i < 1)
            {
                throw new Exception("An error occurred");
            }
        }
        catch
        {
            HandleError();
        }

This gets transformed into:

        try
            if i < 1 then
            begin
                RaiseException('An error occurred');
            end;
        except
            HandleError();
        end;

Retrieving the exception text is still performed with `GetExceptionMessage()`.

# Perform Logic Operations
<a name="performlogicoperations"/>

Under construction.

# Handle Setup Events
<a name="handlesetupevents"/>

An Inno Setup script can declare functions/procedures which, if they use a specific name and prototype, are called when an event of that kind occurs during installation.  For example:

        function InitializeSetup: Boolean;

This will be called once immediately after the installer starts.  In CSharpInnoSetup's `Installation` class, this is represented by the virtual method:

        public virtual bool InitializeSetup();

When overridden in a derived class, the override and its contents are included in the transformation.  The method `InitializeSetup`, along with all other event handler methods, are declared in the class `IEventHandlers`.
  

# Subscribe to Events
<a name="subscribetoevents"/>

Many of the built-in Pascal types are capable of raising events.  Subscribe to those events just as you normally would in .NET.  For example,

        void Handler(TObject sender)
        {
            // ...
        }

        void InitializeWizard()
        {
            WizardForm.Hide += Handler;
        }
        
This gets transformed into:

        procedure Handler(TObject sender);
        begin
            // ...
        end;

        procedure InitializeWizard();
        begin
            WizardForm.Hide := @Handler;
        end;

# Call a Support Function
<a name="callsupportfunction"/>

Support functions in Inno Setup are built-in functions/procedures that can be called during installation for performing string manipulation or accessing the system, for example.  In C#, these functions are declared in the `ISupportMethods` interface, and implemented by the `Installation` class.  Use them just as you would in an Inno Setup script:

        public override bool InitializeSetup()
        {
            Log("InitializeSetup was called");
            var systemDir = GetSystemDir();
            // ...
        }

This example, in which the support methods `Log` and `GetSystemDir` are called, is transformed into:

        function InitializeSetup(): Boolean;
        var
            systemDir: String;
        begin
            Log('InitializeSetup was called');
            systemDir := GetSystemDir();
        end;
             

# Access Command Line Parameters
<a name="comandlineparameters"/>

Parameters can be passed to the installer and read using the `param` constant.  For example:

        ConfigureSecurity := ExpandConstant('{param:security|0}) == '1';

This same capability exists in CSharpInnoSetup via the __param() function.  Simpler though is to use the [CommandLineParameter] attribute on a member field declared within the derived `Installation` class:

        [CommandLineParameter("security")]
        private bool ConfigureSecurity = false;

The transformation process will automatically include the initialization of this field.  Note that any value assigned to the field is used as its default value in the `param` constant.  Also, because it is declared as a class member, `ConfigureSecurity` is transformed into a global variable in the resulting Inno Setup script.

# Instantiate Objects
<a name="instantiateobjects"/>

In C#, the compiler will complain if a variable is used before it is initialized.  This means if you were to declare a `TGUID` or `TStringList`, for example, they'd have to be initialized first:

        TGUID g = new TGUID();
        TStringList list = new TStringList();

However, there is no `new` operator in Inno Setup.  To account for this, CSharpInnoSetup recognizes that `TGUID` is a record type that requires no initialization, and that `TStringList` is derived from `TObject`, and is instantiated with the `Create` function.  The above object creation is transformed into:

        var
            g: TGUID;
            list: TStringList;
        begin
            list := TStringList.Create; 

Note that the instantiation of `g` is simply omitted.

# Specify a Check Parameter
<a name="specifycheckparameter"/>

A `Check` parameter is an optional Boolean expression associated with parameterized entries, like Tasks, Components, Files, and Registry entries, for example.  Should it evaluate to `False`, the entry is omitted from the installation.  For example:

        [Files]
        Source: "MYPROG.EXE"; DestDir: "{app}"; Check: MyProgCheck

In this example, "MYPROG.EXE" will be omitted if `MyProgCheck` evaluates to `False`.  Builders for all parameterized entries allow a check parameter to be specified:

        builder().Source("MYPROG.EXE").Destination(__app).Check(filename => MyProgCheck())

That `filename` argument is designed to represent the value of Inno Setup's `CurrentFilename` function.  However, this argument is not currently supported, but is reserved for future use.  

Check parameters may also contain Boolean operators like &&, ||, and !:

        builder().Source("MYPROG.EXE").Destination(__app).Check(filename => MyProgCheck() && AdditionalCheck(ExpandConstant(__app)))

Arguments passed to any method within the expression are limited to constants or to calls to the method `ExpandConstant`.

# Specify a Components Parameter
<a name="specifycomponentsparameter"/>

A `Components` parameter is an optional Boolean expression associated with parameterized entries, like Tasks, Files, and Registry entries, for example.  Should it evaluate to `False`, the entry is omitted from the installation.  For example:

        [Files]
        Source: "MYPROG.EXE"; DestDir: "{app}"; Components: Main

In this example, "MYPROG.EXE" will be omitted if the `Main` component is disabled by the user.  Builders for most parameterized entries allow a component parameter to be specified:

        builder().Source("MYPROG.EXE").Destination(__app).Components(() => components.Main)

Component parameters may also contain Boolean operators like &&, ||, and !:

        builder().Source("MYPROG.EXE").Destination(__app).Check(() => components.Main || components.Help))

In this example, the file is installed if either the `Main` or `Help` component was enabled.  As with the `Check` parameter, arguments passed to any method within the expression are limited to constants or to calls to the method `ExpandConstant`.

# Specify a Tasks Parameter
<a name="specifytasksparameter"/>

A `Tasks` parameter is an optional expression associated with parameterized entries, like Files, Dirs, and Registry entries, for example.  It indicates to which Tasks the user must select for an entry to be processed.  Otherwise, it is omitted.  For example:

        [Files]
        Source: "MYPROG.EXE"; DestDir: "{app}"; Tasks: startmenu

In this example, "MYPROG.EXE" will be omitted if the `startmenu` task isn't selected by the user.  Builders for most parameterized entries allow a task (or tasks) parameter to be specified:

        builder().Source("MYPROG.EXE").Destination(__app).Tasks(() => tasks.DesktopIcon)
        builder().Source("MYPROG.EXE").Destination(__app).Tasks(() => new { tasks.DesktopIcon, tasks.DesktopIcon.Children.Common } )

Component parameters may also contain Boolean operators like &&, ||, and !:

        builder().Source("MYPROG.EXE").Destination(__app).Components(() => components.Main || components.Help))

In this example, the file is installed if either the `Main` or `Help` component was enabled.  As with the `Check` parameter, arguments passed to any method within the expression are limited to constants or to calls to the method `ExpandConstant`.

# Share Common Installer Behavior
<a name="sharecommonbehavior"/>

Under construction.

