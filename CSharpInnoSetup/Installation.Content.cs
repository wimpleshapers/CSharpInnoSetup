
using CodingMuscles.CSharpInnoSetup.Converter;
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Script.Constructs;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Collection.Customizable.Configuration;
using CodingMuscles.CSharpInnoSetup.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup
{
    public partial class Installation
    {
        class ParameterizedEntriesBuilder : IParameterizedEntriesBuilder
        {
            private readonly TextWriter _textWriter;

            public HashSet<InstallationMethod> Methods { get; }

            public ParameterizedEntriesBuilder(TextWriter textWriter)
            {
                _textWriter = textWriter;
                Methods = new HashSet<InstallationMethod>();
            }

            public ILanguagesBuilder LanguagesBuilder => new LanguagesBuilder(_textWriter, Methods);
        }

        class LanguagesBuilder : ILanguagesBuilder
        {
            private readonly TextWriter _textWriter;
            private readonly HashSet<InstallationMethod> _methods;

            public LanguagesBuilder(TextWriter textWriter, HashSet<InstallationMethod> methods)
            {
                _textWriter = textWriter;
                _methods = methods;
            }

            public ILanguageDependentBuilder<TLanguages> AddLanguages<TLanguages>(Func<Func<Language.Builder>, TLanguages> languages)
            {
                var langs = languages(() => Language.Builder.Create());
                var languageCount = 0;

                using (new Section(_textWriter, "Languages"))
                {
                    foreach (var typesProperty in langs.GetType().GetProperties())
                    {
                        var entries = new NameValueCollection
                        {
                            { "Name", typesProperty.Name }
                        };

                        var setupType = typesProperty.GetValue(langs);

                        var converter = new PropertiesToNameValuePairsConverter(_propertyFormatter);
                        entries.Add(converter.ConvertTo(setupType, typeof(NameValueCollection)) as NameValueCollection);

                        _textWriter.WriteLine(entries.Format());

                        languageCount++;
                    }
                }

                return new LanguageDependentBuilder<TLanguages>(_textWriter, langs, _methods, languageCount);
            }

            class LanguageDependentBuilder<TLanguages> : ILanguageDependentBuilder<TLanguages>
            {
                private readonly TextWriter _textWriter;
                private readonly TLanguages _languages;
                private readonly HashSet<InstallationMethod> _methods;
                private readonly int _languageCount;

                public LanguageDependentBuilder(
                    TextWriter textWriter, 
                    TLanguages languages, 
                    HashSet<InstallationMethod> methods,
                    int languageCount)
                {
                    _textWriter = textWriter;
                    _languages = languages;
                    _methods = methods;
                    _languageCount = languageCount;
                }

                public IComponentsBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages> Add<TSetupTypes, TCustomMessages, TMessages>(
                    Func<Func<SetupType.Builder>, TLanguages, TSetupTypes> types,
                    Func<TLanguages, TCustomMessages> customMessagesFactory,
                    Func<TLanguages, TMessages> messagesFactory)
                {
                    var setupTypes = types(() => SetupType.Builder.Create(), _languages);

                    using (new Section(_textWriter, "Types"))
                    {
                        foreach (var typesProperty in setupTypes.GetType().GetProperties())
                        {
                            var entries = new NameValueCollection
                            {
                                { "Name", typesProperty.Name }
                            };

                            var setupType = typesProperty.GetValue(setupTypes);

                            var converter = new PropertiesToNameValuePairsConverter(_propertyFormatter);
                            entries.Add(converter.ConvertTo(setupType, typeof(NameValueCollection)) as NameValueCollection);

                            _textWriter.WriteLine(entries.Format());
                        }
                    }

                    var messages = messagesFactory(_languages);

                    using (new Section(_textWriter, "Messages"))
                    {
                        foreach (var messageProperty in messages.GetType().GetProperties())
                        {
                            if (messageProperty.GetValue(messages) is Message message)
                            {
                                var format = _languageCount > 1 && !string.IsNullOrEmpty(message.Qualifier) ? "{0}.{1}={2}" : "{1}={2}";

                                _textWriter.WriteLine(string.Format(format, message.Qualifier, messageProperty.Name, message.Text));
                            }
                            else
                            {
                                throw new NotSupportedException($"Messages of type {messageProperty.PropertyType.Name} are not supported");
                            }
                        }
                    }


                    var customMessages = customMessagesFactory(_languages);

                    using (new Section(_textWriter, "CustomMessages"))
                    {
                        var format = _languageCount > 1 ? "{0}.{1}={2}" : "{1}={2}";

                        foreach (var customMessageProperty in customMessages.GetType().GetProperties())
                        {
                            if(customMessageProperty.GetValue(customMessages) is Message customMessage)
                            {
                                _textWriter.WriteLine(string.Format(format, customMessage.Qualifier, customMessageProperty.Name, customMessage.Text));
                            }
                            else
                            {
                                throw new NotSupportedException($"Custom messages of type {customMessageProperty.PropertyType.Name} are not supported");
                            }
                        }
                    }

                    return new ComponentsBuilder<TSetupTypes, TCustomMessages, TMessages>(_textWriter, _languages, setupTypes, customMessages, messages, _methods);
                }
  
                class ComponentsBuilder<TSetupTypes, TCustomMessages, TMessages> : IComponentsBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages>
                {
                    private readonly TextWriter _textWriter;
                    private readonly TLanguages _languages;
                    private readonly TSetupTypes _setupTypes;
                    private readonly TCustomMessages _customMessages;
                    private readonly TMessages _messages;
                    private readonly HashSet<InstallationMethod> _methods;

                    public ComponentsBuilder(TextWriter textWriter, TLanguages languages, TSetupTypes setupTypes, TCustomMessages customMessages, TMessages messages, HashSet<InstallationMethod> methods)
                    {
                        _textWriter = textWriter;
                        _languages = languages;
                        _setupTypes = setupTypes;
                        _customMessages = customMessages;
                        _messages = messages;

                        _methods = methods;
                    }

                    public ITasksBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents> AddComponents<TComponents>(Func<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents> components)
                    {
                        var componentEntries = components(_languages, _setupTypes, _customMessages, _messages);

                        using (new Section(_textWriter, "Components"))
                        {
                            void TransformComponent(object components, string prefix = null)
                            {
                                prefix ??= string.Empty;

                                foreach (var typesProperty in components.GetType().GetProperties())
                                {
                                    var entries = new NameValueCollection
                                    {
                                        { "Name", Path.Combine(prefix, typesProperty.Name) }
                                    };

                                    var componentValue = typesProperty.GetValue(components);

                                    var converter = new PropertiesToNameValuePairsConverter(_propertyFormatter);
                                    entries.Add(converter.ConvertTo(componentValue, typeof(NameValueCollection)) as NameValueCollection);

                                    _textWriter.WriteLine(entries.Format());

                                    var childrenType = componentValue.GetType().GetProperty(nameof(Component<object>.Children), BindingFlags.Public | BindingFlags.Instance);
                                    var children = childrenType.GetValue(componentValue);

                                    TransformComponent(children, typesProperty.Name);
                                }
                            }

                            TransformComponent(componentEntries);
                        }

                        return new TasksBuilder<TComponents>(_textWriter, _languages, _setupTypes, _customMessages, _messages, componentEntries, _methods);
                    }

                    class TasksBuilder<TComponents> : ITasksBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents>
                    {
                        private readonly TextWriter _textWriter;
                        private readonly TLanguages _languages;
                        private readonly TSetupTypes _setupTypes;
                        private readonly TCustomMessages _customMessages;
                        private readonly TMessages _messages;
                        private readonly TComponents _components;
                        private readonly HashSet<InstallationMethod> _methods;

                        public TasksBuilder(TextWriter textWriter, TLanguages languages, TSetupTypes setupTypes, TCustomMessages customMessages, TMessages messages, TComponents components, HashSet<InstallationMethod> methods)
                        {
                            _textWriter = textWriter;
                            _languages = languages;
                            _setupTypes = setupTypes;
                            _customMessages = customMessages;
                            _messages = messages;
                            _components = components;

                            _methods = methods;
                        }

                        public IContentBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks> AddTasks<TTasks>(Func<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks> tasks)
                        {
                            var taskEntries = tasks(_languages, _setupTypes, _customMessages, _messages, _components);

                            using (new Section(_textWriter, "Tasks"))
                            {
                                void TransformTask(object tasks, string prefix = null)
                                {
                                    prefix ??= string.Empty;

                                    foreach (var taskProperty in tasks.GetType().GetProperties())
                                    {
                                        var entries = new NameValueCollection
                                        {
                                            { "Name", Path.Combine(prefix, taskProperty.Name) }
                                        };

                                        var tasksValue = taskProperty.GetValue(tasks);

                                        var converter = new PropertiesToNameValuePairsConverter(_propertyFormatter);
                                        entries.Add(converter.ConvertTo(tasksValue, typeof(NameValueCollection)) as NameValueCollection);

                                        _textWriter.WriteLine(entries.Format());

                                        var childrenType = tasksValue.GetType().GetProperty(nameof(Task<object>.Children), BindingFlags.Public | BindingFlags.Instance);
                                        var children = childrenType.GetValue(tasksValue);

                                        TransformTask(children, taskProperty.Name);
                                    }
                                }

                                TransformTask(taskEntries);
                            }


                            return new ContentBuilder<TTasks>(_textWriter, _languages, _setupTypes, _customMessages, _messages, _components, taskEntries, _methods);
                        }

                        class ContentBuilder<TTasks> : IContentBuilder<TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks>
                        {
                            private readonly TextWriter _textWriter;
                            private readonly TLanguages _languages;
                            private readonly TSetupTypes _setupTypes;
                            private readonly TCustomMessages _customMessages;
                            private readonly TMessages _messages;
                            private readonly TComponents _components;
                            private readonly TTasks _tasks;
                            private readonly HashSet<InstallationMethod> _methods;

                            public ContentBuilder(TextWriter textWriter, TLanguages languages, TSetupTypes setupTypes, TCustomMessages customMessages, TMessages messages, TComponents components, TTasks tasks, HashSet<InstallationMethod> methods)
                            {
                                _textWriter = textWriter;
                                _languages = languages;
                                _setupTypes = setupTypes;
                                _customMessages = customMessages;
                                _messages = messages;
                                _components = components;
                                _methods = methods;
                                _tasks = tasks;
                            }

                            public void AddFiles(Func<Func<FileEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<FileEntry>> builder)
                            {
                                AddEntries(
                                    "Files",
                                    () => FileEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks,
                                    e => { _methods.Add(e.AfterInstall); _methods.Add(e.BeforeInstall); }
                                    );
                            }

                            public void AddFolders(Func<Func<FolderEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<FolderEntry>> builder)
                            {
                                AddEntries(
                                    "Dirs",
                                    () => FolderEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddIcons(Func<Func<IconEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<IconEntry>> builder)
                            {
                                AddEntries(
                                    "Icons",
                                    () => IconEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddIniEntries(Func<Func<IniEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<IniEntry>> builder)
                            {
                                AddEntries(
                                    "INI",
                                    () => IniEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddInstallDeleteEntries(Func<Func<DeleteEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<DeleteEntry>> builder)
                            {
                                AddEntries(
                                    "InstallDelete",
                                    () => DeleteEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddRegistryEntries(Func<Func<RegistryEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<RegistryEntry>> builder)
                            {
                                AddEntries(
                                    "Registry",
                                    () => RegistryEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddUninstallDeleteEntries(Func<Func<DeleteEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<DeleteEntry>> builder)
                            {
                                AddEntries(
                                    "UninstallDelete",
                                    () => DeleteEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddRunEntries(Func<Func<RunEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<RunEntry>> builder)
                            {
                                AddEntries(
                                    "Run",
                                    () => RunEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            public void AddUninstallRunEntries(Func<Func<RunEntry.Builder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<RunEntry>> builder)
                            {
                                AddEntries(
                                    "UninstallRun",
                                    () => RunEntry.Builder.Create(),
                                    builder,
                                    _languages,
                                    _setupTypes,
                                    _customMessages,
                                    _messages,
                                    _components,
                                    _tasks);
                            }

                            private IList<TEntry> AddEntries<TEntry, TBuilder>(
                                string sectionName,
                                Func<TBuilder> builderFactory,
                                Func<Func<TBuilder>, TLanguages, TSetupTypes, TCustomMessages, TMessages, TComponents, TTasks, IEnumerable<TEntry>> builder,
                                TLanguages languages,
                                TSetupTypes setupTypes,
                                TCustomMessages customMessages,
                                TMessages messages,
                                TComponents components,
                                TTasks tasks,
                                Action<TEntry> newEntryHandler = null) where TEntry : ICustomizable, IPredicated
                            {
                                var entries = builder(builderFactory, languages, setupTypes, customMessages, messages, components, tasks).ToList();

                                if (entries.Count > 0)
                                {
                                    var typeConverterFactory = new Func<System.ComponentModel.TypeConverterAttribute, System.ComponentModel.TypeConverter>(attr =>
                                    {
                                        var type = typeof(DelegateExpressionToStringConverter<Func<string, bool>>);
                                        var converterType = Type.GetType(attr.ConverterTypeName);

                                        if (converterType == type)
                                        {
                                            return new DelegateExpressionToStringConverter<Func<string, bool>>(methodInfo =>
                                            {
                                                if (!_methods.Any(im => im.MetadataToken == methodInfo.MetadataToken))
                                                {
                                                    _methods.Add(new InstallationMethod(methodInfo));
                                                }
                                            });
                                        }

                                        return (System.ComponentModel.TypeConverter)Activator.CreateInstance(converterType);
                                    });

                                    using (new Section(_textWriter, sectionName))
                                    {
                                        foreach (var entry in entries)
                                        {
                                            newEntryHandler?.Invoke(entry);

                                            var converter = new PropertiesToNameValuePairsConverter(_propertyFormatter, typeConverterFactory);
                                            var pairs = converter.ConvertTo(entry, typeof(NameValueCollection)) as NameValueCollection;

                                            _textWriter.WriteLine(pairs.Format());
                                        }
                                    }
                                }

                                return entries;
                            }
                        }
                    }
                }
            }
        }

        private static char[] quotableCharacters = new char[] { ' ', ';', ':' };

        private static Func<string, PropertyInfo, string> _propertyFormatter = (s, p) =>
        {
            // escape double quotes
            s = s.Replace("\"", "\"\"");

            // double quote anything that's a constant (starts with {), or contains a space/semi/colon
            if (p.GetCustomAttribute<DoubleQuoteAttribute>() != null && (s.StartsWith('{') || s.IndexOfAny(quotableCharacters) != -1))
            {
                return $"\"{s}\"";
            }

            return s;
        };
    }

    internal static class MethodListExtensions
    {
        public static void Add(this HashSet<InstallationMethod> methods, Expression<Action<string>> expression)
        {
            if(expression == null)
            {
                return;
            }

            var method = ((MethodCallExpression)expression.Body).Method;
            methods.Add(new InstallationMethod(method));
        }

        public static void Add(this HashSet<InstallationMethod> methods, Expression<Func<bool>> expression)
        {
            if (expression == null)
            {
                return;
            }

            var method = ((MethodCallExpression)expression.Body).Method;
            methods.Add(new InstallationMethod(method));
        }
    }
}

