
using CodingMuscles.CSharpInnoSetup.Generation;
using CodingMuscles.CSharpInnoSetup.Generation.Output;
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Directive;
using CodingMuscles.CSharpInnoSetup.Utilities;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using CodingMuscles.CSharpInnoSetup.Generation.Visitor;
using ICSharpCode.Decompiler.Metadata;
using System.Reflection.PortableExecutable;
using System.Reflection.Metadata;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.DebugInfo;

namespace CodingMuscles.CSharpInnoSetup
{
    /// <summary>
    /// Derived from to create a class that represents the contents of an Inno Setup script
    /// </summary>
    public abstract partial class Installation
    {
        /// <summary>
        /// Returns a delegate that receives a <see cref="IParameterizedEntriesBuilder"/> with
        /// which to specify all sections of the Inno Setup script with repeating entries
        /// </summary>
        public virtual Action<IParameterizedEntriesBuilder> ParameterizedEntriesBuilderHandler { get; }

        /// <summary>
        /// Saves this object as an Inno Setup formatted script
        /// </summary>
        /// <param name="textWriter"><see cref="TextWriter"/> with which script is written</param>
        public virtual void Save(TextWriter textWriter)
        {
            var thisType = typeof(Installation);
            var derivedType = GetType();

            var entriesBuilder = new ParameterizedEntriesBuilder(textWriter);

            // list of methods referenced by constants
            var constReferencedMethods = new HashSet<InstallationMethod>();
            _constantReferencedMethod = methodInfo => constReferencedMethods.Add(new InstallationMethod(methodInfo));

            try
            {
                using (new Section(textWriter, "Setup"))
                {
                    var setupProperties = thisType.GetProperties(BindingFlags.Public|BindingFlags.Instance)
                        .Where(p => p.GetCustomAttribute<SetupDirectiveAttribute>() != null)
                        .Select(p =>
                            new
                            {
                                Alias = p.GetCustomAttribute<AliasAttribute>()?.Name,
                                Property = derivedType.GetProperty(p.Name),
                                TypeConverter = p.GetCustomAttribute<TypeConverterAttribute>()
                            })
                        .Where(p => p.Property.DeclaringType != thisType)
                        .Select(p =>
                            new
                            {
                                p.Property,
                                Name = p.Alias ?? p.Property.Name,
                                p.TypeConverter
                            })
                        .OrderBy(p => p.Name)
                        .ToList();

                    WriteDirectives(textWriter, setupProperties.Select(p => (p.Name, p.Property, p.TypeConverter)));
                }

                var langOptionsProperties = thisType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                        .Where(p => p.GetCustomAttribute<LanguageDirectiveAttribute>() != null)
                    .Select(p =>
                        new
                        {
                            Alias = p.GetCustomAttribute<AliasAttribute>()?.Name,
                            Property = derivedType.GetProperty(p.Name),
                            TypeConverter = p.GetCustomAttribute<TypeConverterAttribute>()
                        })
                    .Where(p => derivedType.GetProperty(p.Property.Name).DeclaringType != thisType)
                    .Select(p =>
                        new
                        {
                            p.Property,
                            Name = p.Alias ?? p.Property.Name,
                            p.TypeConverter
                        })
                    .OrderBy(p => p.Name)
                    .ToList();

                if(langOptionsProperties.Count > 0)
                {
                    using (new Section(textWriter, "LanguageOptions"))
                    {
                        WriteDirectives(textWriter, langOptionsProperties.Select(p => (p.Name, p.Property, p.TypeConverter)));
                    }
                }

                ParameterizedEntriesBuilderHandler?.Invoke(entriesBuilder);
            }
            finally
            {
                _constantReferencedMethod = null;
            }

            using (new Section(textWriter, "Code"))
            {
                textWriter.WriteLine("const");
                textWriter.WriteLine("   MB_ICONWARNING = $30;");
                textWriter.WriteLine("   MB_ICONINFORMATION = $40;");
                textWriter.WriteLine("   MB_ICONQUESTION = $20;");
                textWriter.WriteLine("   MB_ICONERROR = $10;");
                textWriter.WriteBlankLine();

                var decompilers = new Dictionary<string, CSharpDecompiler>();

                SyntaxTree GetSyntaxTree(string assemblyLocation, int metadataToken)
                {
                    var settings = new DecompilerSettings 
                    { 
                        UseDebugSymbols = true, 
                        NamedArguments = false, 
                        SwitchExpressions = false,
                        OutVariables = false,
                        SeparateLocalVariableDeclarations = true,
                        LoadInMemory = true,
                        ShowXmlDocumentation = false,
                        Discards = false
                    };

                    var assemblyName = assemblyLocation;

                    var peFile = new PEFile(
                        assemblyName,
                        new FileStream(assemblyName, FileMode.Open, FileAccess.Read),
                        streamOptions: settings.LoadInMemory ? PEStreamOptions.PrefetchEntireImage : PEStreamOptions.Default,
                        metadataOptions: settings.ApplyWindowsRuntimeProjections ? MetadataReaderOptions.ApplyWindowsRuntimeProjections : MetadataReaderOptions.None
                    );

                    var resolver = new UniversalAssemblyResolver(assemblyName, settings.ThrowOnAssemblyResolveErrors,
                        peFile.DetectTargetFrameworkId(),
                        settings.LoadInMemory ? PEStreamOptions.PrefetchMetadata : PEStreamOptions.Default,
                        settings.ApplyWindowsRuntimeProjections ? MetadataReaderOptions.ApplyWindowsRuntimeProjections : MetadataReaderOptions.None);

                    var typeSystem = new DecompilerTypeSystem(peFile, resolver);

                    var decompiler = decompilers.Set(
                        assemblyName,
                        new CSharpDecompiler(typeSystem, settings) { DebugInfoProvider = new MetadataDebugInfoProvider(assemblyName) }
                    );
                    var method = MetadataTokenHelpers.TryAsEntityHandle(metadataToken);

                    return decompiler.Decompile(new List<EntityHandle>() { method.Value });
                }

                var eventHandlers = thisType.GetMethods(BindingFlags.Instance|BindingFlags.Public).Where(m => m.GetCustomAttribute<EventHandlerAttribute>() != null)
                    .Select(m => new
                    {
                        DerivedMethod = derivedType.GetMethod(m.Name, BindingFlags.Public | BindingFlags.Instance),
                        InterfaceMethod = m
                    })
                    .Select(m =>
                    {
                        if (m.DerivedMethod.DeclaringType != typeof(Installation))
                        {
                            return new InstallationMethod(m.DerivedMethod, m.InterfaceMethod);
                        }

                        return null;
                    })
                    .Where(m => m != null)
                    .ToList();

                var allMethods = entriesBuilder.Methods
                    .Concat(eventHandlers)
                    .Concat(constReferencedMethods)
                    .ToList();

                var aliasFactory = new Func<string, string>(name =>
                {
                    var method = allMethods.Single(m => m.Name == name);
                    return method.GetAttribute<AliasAttribute>()?.Name;
                });

                bool encounteredInitializeSetup = false;
                bool encounteredInitializeUninstall = false;
                var referencedGlobalVariables = new Dictionary<FieldInfo, string>();
                var definedMethods = new HashSet<string>();
                var declaredMembers = new HashSet<MemberInfo>();
                var namespaces = new HashSet<string>();
                using var typeDefinitions = new Snippet();

                var type = derivedType;
                while(type != null && type != typeof(Installation))
                {
                    namespaces.Add(type.Namespace);
                    type = type.BaseType;
                }

                using (var snippet = new Snippet())
                {
                    foreach (var installationMethod in allMethods)
                    {
                        switch (installationMethod.Name)
                        {
                            case nameof(Installation.InitializeSetup):
                                encounteredInitializeSetup = true;
                                break;

                            case nameof(Installation.InitializeUninstall):
                                encounteredInitializeUninstall = true;
                                break;
                        }

                        if(!definedMethods.Add(installationMethod.UniqueId))
                        {
                            // already defined, probably via recursion when one method called another
                            continue;
                        }

                        var ast = GetSyntaxTree(installationMethod.AssemblyLocation, installationMethod.MetadataToken);

                        //ast.VisitChildren(new DiagnosticVisitor(Console.Out));

                        var methodDecl = ast.Children.OfType<MethodDeclaration>().Single();

                        using (var masterWriter = new TextCodeWriter(snippet, null, true))
                        {
                            var codeWriterFactory = new NestedCodeWriterFactory(masterWriter);

                            using (var methodWriter = codeWriterFactory.New())
                            {
                                var context = new PascalScriptVisitorContext(
                                    this,
                                    methodWriter,
                                    null,
                                    namespaces,
                                    mi => GetSyntaxTree(mi.DeclaringType.Assembly.Location, mi.MetadataToken),
                                    referencedGlobalVariables,
                                    aliasFactory,
                                    new TextCodeWriter(typeDefinitions, null, false),
                                    declaredMembers,
                                    () => codeWriterFactory.New(),
                                    derivedType.BaseType,
                                    definedMethods);

                                ast.VisitChildren(new PascalScriptVisitor(context));

                                methodWriter.WriteBlankLine();
                            }
                        }
                    }

                    using(var codeWriter = new TextCodeWriter(textWriter, null, true))
                    {
                        typeDefinitions.CopyTo(codeWriter);

                        var usedSwitches = new HashSet<string>();
                        var variableInitialization = new List<(string name, string rhs)>();

                        // write global variables
                        if (referencedGlobalVariables.Count > 0)
                        {
                            codeWriter.WriteLine("var");
                            
                            using(codeWriter.Indent())
                            {
                                foreach (var globalVariable in referencedGlobalVariables)
                                {
                                    codeWriter.WriteLine($"{globalVariable.Value}: {globalVariable.Key.FieldType.ToPascal()};");

                                    var defaultValue = globalVariable.Key.GetValue(this);
                                    var formattedDefaultValue = defaultValue == null || globalVariable.Key.FieldType.IsStruct() ? null : PascalScriptVisitor.FormatPrimitive(defaultValue);
                                    var cmdLineAttr = (globalVariable.Key.GetCustomAttribute<CommandLineParameterAttribute>());

                                    if (cmdLineAttr != null)
                                    {
                                        var name = cmdLineAttr.SwitchName ?? globalVariable.Key.Name;
                                        var initialization = $"ExpandConstant('{{param:{name.ToLower()}";

                                        if (defaultValue != null)
                                        {
                                            defaultValue = defaultValue.GetType() == typeof(bool) ?
                                                ((bool)defaultValue ? "1" : "0") :
                                                formattedDefaultValue;

                                            initialization += $"|{defaultValue}";
                                        }

                                        initialization += "}')";

                                        if (globalVariable.Key.FieldType == typeof(bool))
                                        {
                                            initialization = $"({initialization} = '1')";
                                        }

                                        if (!usedSwitches.Add(name))
                                        {
                                            throw new NotSupportedException($"The command line parameter name {name} can be used only once");
                                        }

                                        variableInitialization.Add((globalVariable.Key.Name, initialization));
                                    }
                                    else if(formattedDefaultValue != null)
                                    {
                                        // FormatPrimitive() won't single quote the string
                                        if (defaultValue is string)
                                            formattedDefaultValue = $"'{formattedDefaultValue}'";

                                        variableInitialization.Add((globalVariable.Key.Name, formattedDefaultValue));
                                    }
                                }
                            }
                        }

                        codeWriter.WriteBlankLine();

                        // write body of code
                        snippet.CopyTo(codeWriter);

                        using(var globalVariableSnippet = new Snippet())
                        {
                            using(var globalVariableWriter = new TextCodeWriter(globalVariableSnippet, null, true))
                            {
                                variableInitialization.ForEach(init => globalVariableWriter.WriteLine($"{init.name} := {init.rhs};"));
                            }

                            if (encounteredInitializeSetup || variableInitialization.Count > 0)
                            {
                                // write InitializeSetup
                                codeWriter.WriteLine($"function {nameof(Installation.InitializeSetup)}: Boolean;");
                                codeWriter.WriteBegin();

                                using (codeWriter.Indent())
                                {
                                    // write variable initialization
                                    globalVariableSnippet.CopyTo(codeWriter);

                                    codeWriter.WriteBlankLine();
                                    codeWriter.WriteLine(encounteredInitializeSetup ? "Result := this_InitializeSetup();" : "Result := True;");
                                }

                                codeWriter.WriteEnd();
                            }

                            if (encounteredInitializeUninstall || variableInitialization.Count > 0)
                            {
                                // write InitializeSetup
                                codeWriter.WriteLine($"function {nameof(Installation.InitializeUninstall)}: Boolean;");
                                codeWriter.WriteBegin();

                                using (codeWriter.Indent())
                                {
                                    // write variable initialization
                                    globalVariableSnippet.CopyTo(codeWriter);

                                    codeWriter.WriteBlankLine();
                                    codeWriter.WriteLine(encounteredInitializeUninstall ? "Result := this_InitializeUninstall();" : "Result := True;");
                                }

                                codeWriter.WriteEnd();
                            }
                        }
                    }
                }
            }
        }

        private void WriteDirectives(TextWriter textWriter, IEnumerable<(string Name, PropertyInfo Info, TypeConverterAttribute TypeConverter)> properties)
        {
            foreach (var prop in properties)
            {
                var rawValue = prop.Info.GetValue(this);
                if(rawValue == null)
                {
                    continue;
                }

                string value = null;

                if (prop.TypeConverter == null)
                {
                    value = rawValue.ToString();
                }
                else
                {
                    var converter = (TypeConverter)Activator.CreateInstance(Type.GetType(prop.TypeConverter.ConverterTypeName));
                    value = converter.ConvertTo(rawValue, typeof(string)) as string;
                }

                textWriter.WriteLine($"{prop.Name}={value}");

                var ambiguities = prop.Info.GetCustomAttributes<AmbiguousPropertyAttribute>();

                foreach (var ambiguity in ambiguities)
                {
                    // this is a single property that expands into two directives
                    var converter = (TypeConverter)Activator.CreateInstance(ambiguity.TypeConverter);
                    value = converter.ConvertTo(rawValue, typeof(string)) as string;

                    textWriter.WriteLine($"{ambiguity.Name}={value}");
                }
            }
        }
    }

    class Section : Disposable
    {
        private readonly TextWriter _textWriter;

        public Section(TextWriter textWriter, string name)
        {
            _textWriter = textWriter;

            _textWriter.Write($"[{name}]");
            _textWriter.WriteBlankLine();
        }

        protected override void OnDisposing()
        {
            _textWriter.WriteBlankLine();
        }
    }
}
