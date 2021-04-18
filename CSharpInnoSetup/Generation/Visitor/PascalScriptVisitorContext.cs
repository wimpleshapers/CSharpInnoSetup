
using CodingMuscles.CSharpInnoSetup.Generation.Output;
using CodingMuscles.CSharpInnoSetup.Utilities;
using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    /// <summary>
    /// Saves state relevant to the node currently being visited
    /// </summary>
    internal class PascalScriptVisitorContext : Disposable, ICodeWriter
    {
        private readonly Installation _installation;
        private readonly ICodeWriter _codeWriter;
        private readonly Func<MethodInfo, SyntaxTree> _methodSyntaxTreeFactory;
        private readonly Func<string, string> _aliasFactory;
        private readonly Dictionary<FieldInfo, string> _referencedGlobalVariables;
        private readonly HashSet<MemberInfo> _declaredMembers;
        private readonly Func<ICodeWriter> _methodDeclWriterFactory;
        private readonly Type _baseInstallationType;
        private readonly HashSet<string> _definedMethods;

        /// <summary>
        /// Initializes a new <see cref="PascalScriptVisitorContext"/>
        /// </summary>
        /// <param name="installation">Instance of the class containing the code being visited</param>
        /// <param name="codeWriter">Reference to a <see cref="ICodeWriter"/> used to generate code</param>
        /// <param name="localVariables">A collection of local variables, keyed by the variable name</param>
        /// <param name="namespaces">A list of namespaces visible to the current node</param>
        /// <param name="methodSyntaxTreeFactory">Factory for returning a <see cref="SyntaxTree"/> from a <see cref="MethodInfo"/></param>
        /// <param name="referencedGlobalVariables">Collection of global variables that are referenced at least once</param>
        /// <param name="aliasFactory">Factory for generating aliases for a method name</param>
        /// <param name="typeWriter">An <see cref="ICodeWriter"/> used for declaring types</param>
        /// <param name="declaredMembers">A list of members that have been scripted</param>
        /// <param name="methodDeclWriterFactory">Factory for creating <see cref="ICodeWriter"/> when scripting a method</param>
        /// <param name="baseInstallationType">The class type from which <paramref name="installation"/> is derived</param>
        /// <param name="definedMethods">A list of method names that have been scripted</param>
        public PascalScriptVisitorContext(
            Installation installation,
            ICodeWriter codeWriter,
            IDictionary<string, LoadedType> localVariables,
            HashSet<string> namespaces,
            Func<MethodInfo, SyntaxTree> methodSyntaxTreeFactory,
            Dictionary<FieldInfo, string> referencedGlobalVariables,
            Func<string, string> aliasFactory,
            ICodeWriter typeWriter,
            HashSet<MemberInfo> declaredMembers,
            Func<ICodeWriter> methodDeclWriterFactory,
            Type baseInstallationType,
            HashSet<string> definedMethods)
        {
            _installation = installation;
            _codeWriter = codeWriter;
            LocalVariables = localVariables ?? new Dictionary<string, LoadedType>();
            Namespaces = namespaces ?? new HashSet<string>();
            _methodSyntaxTreeFactory = methodSyntaxTreeFactory;
            _referencedGlobalVariables = referencedGlobalVariables ?? new Dictionary<FieldInfo, string>();
            _aliasFactory = aliasFactory;
            TypeWriter = typeWriter;
            _declaredMembers = declaredMembers;
            _methodDeclWriterFactory = methodDeclWriterFactory;
            _baseInstallationType = baseInstallationType;
            _definedMethods = definedMethods;
        }

        /// <summary>
        /// Initializes a new <see cref="PascalScriptVisitorContext"/>, inheriting values from the supplied
        /// context <paramref name="inherited"/> when not explicitly supplied to the constructor
        /// </summary>
        /// <param name="inherited">A context that this context should mirror</param>
        /// <param name="installation">Instance of the class containing the code being visited</param>
        /// <param name="codeWriter">Reference to a <see cref="ICodeWriter"/> used to generate code</param>
        /// <param name="localVariables">A collection of local variables, keyed by the variable name</param>
        /// <param name="namespaces">A list of namespaces visible to the current node</param>
        /// <param name="methodSyntaxTreeFactory">Factory for returning a <see cref="SyntaxTree"/> from a <see cref="MethodInfo"/></param>
        /// <param name="aliasFactory">Factory for generating aliases for a method name</param>
        /// <param name="typeWriter">An <see cref="ICodeWriter"/> used for declaring types</param>
        /// <param name="declaredMembers">A list of members that have been scripted</param>
        /// <param name="methodDeclWriterFactory">Factory for creating <see cref="ICodeWriter"/> when scripting a method</param>
        /// <param name="baseInstallationType">The class type from which <paramref name="installation"/> is derived</param>
        /// <param name="definedMethods">A list of method names that have been scripted</param>
        public PascalScriptVisitorContext(
            PascalScriptVisitorContext inherited,
            ICodeWriter codeWriter = null,
            Installation installation = null,
            IDictionary<string, LoadedType> localVariables = null,
            HashSet<string> namespaces = null,
            Func<MethodInfo, SyntaxTree> methodSyntaxTreeFactory = null,
            Func<string, string> aliasFactory = null,
            ICodeWriter typeWriter = null,
            HashSet<MemberInfo> declaredMembers = null,
            Func<ICodeWriter> methodDeclWriterFactory = null,
            Type baseInstallationType = null,
            HashSet<string> definedMethods = null) : 
            this(
                installation ?? inherited._installation,
                codeWriter ?? inherited._codeWriter,
                localVariables ?? inherited.LocalVariables,
                namespaces ?? inherited.Namespaces,
                methodSyntaxTreeFactory ?? inherited._methodSyntaxTreeFactory,
                inherited._referencedGlobalVariables,
                aliasFactory ?? inherited._aliasFactory,
                typeWriter ?? inherited.TypeWriter,
                declaredMembers ?? inherited._declaredMembers,
                methodDeclWriterFactory ?? inherited._methodDeclWriterFactory,
                baseInstallationType ?? inherited._baseInstallationType,
                definedMethods ?? inherited._definedMethods)
        {
        }

        /// <summary>
        /// Retrieves the alias for a given symbol
        /// </summary>
        /// <param name="symbol">The symbol name with an alias</param>
        /// <returns>The alias, or null if there is none</returns>
        public string GetAlias(string symbol) => _aliasFactory(symbol);

        /// <summary>
        /// Retrieves a method node from its info
        /// </summary>
        /// <param name="methodInfo">The method info</param>
        /// <returns>The method <see cref="AstNode"/></returns>
        public SyntaxTree GetMethodSyntaxTree(MethodInfo methodInfo) => _methodSyntaxTreeFactory(methodInfo);

        public ICodeWriter NewMethodDeclWriter() => _methodDeclWriterFactory();

        /// <inheritdoc/>
        public IDisposable Indent() => _codeWriter.Indent();

        /// <inheritdoc/>
        public void Indent(Indentation indentation)
        {
            _codeWriter.Indent(indentation);
        }

        /// <inheritdoc/>
        public void Write(string code, Indentation indentation = Indentation.Current)
        {
            _codeWriter.Write(code, indentation);
        }

        /// <inheritdoc/>
        public void WriteLine(string code, Indentation indentation = Indentation.Current)
        {
            _codeWriter.WriteLine(code, indentation);
        }

        /// <summary>
        /// Used for writing type declarations
        /// </summary>
        public ICodeWriter TypeWriter { get; }

        /// <summary>
        /// Retrieves information about a field
        /// </summary>
        /// <param name="name">The name of the field</param>
        /// <param name="bindingAttr">The <see cref="BindingFlags"/> to use</param>
        /// <returns>The <see cref="FieldInfo"/>, or null if it can't be found</returns>
        public FieldInfo GetField(string name, BindingFlags bindingAttr)
        {
            return _installation.GetType().GetField(name, bindingAttr);
        }

        /// <summary>
        /// Retrieves information about a field in the base type
        /// </summary>
        /// <param name="name">The name of the field</param>
        /// <param name="bindingAttr">The <see cref="BindingFlags"/> to use</param>
        /// <returns>The <see cref="FieldInfo"/>, or null if it can't be found</returns>
        public FieldInfo GetBaseField(string name, BindingFlags bindingAttr)
        {
            return _baseInstallationType.GetType().GetField(name, bindingAttr);
        }

        /// <summary>
        /// Retrieves information about a property
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="bindingAttr">The <see cref="BindingFlags"/> to use</param>
        /// <returns>The <see cref="PropertyInfo"/>, or null if it can't be found</returns>
        public PropertyInfo GetProperty(string name, BindingFlags bindingAttr)
        {
            return _installation.GetType().GetProperty(name, bindingAttr);
        }

        /// <summary>
        /// Retrieves information about a property in the base type
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="bindingAttr">The <see cref="BindingFlags"/> to use</param>
        /// <returns>The <see cref="PropertyInfo"/>, or null if it can't be found</returns>
        public PropertyInfo GetBaseProperty(string name, BindingFlags bindingAttr)
        {
            return _baseInstallationType.GetType().GetProperty(name, bindingAttr);
        }

        /// <summary>
        /// Retrieves the value for a given field
        /// </summary>
        /// <param name="fieldInfo">The <see cref="FieldInfo"/></param>
        /// <returns>The value of the field</returns>
        public object GetValue(FieldInfo fieldInfo)
        {
            return fieldInfo.GetValue(_installation);
        }

        /// <summary>
        /// Retrieves the value for a given property
        /// </summary>
        /// <param name="propertyInfo">The <see cref="PropertyInfo"/></param>
        /// <returns>The value of the property</returns>
        public object GetValue(PropertyInfo propertyInfo)
        {
            return propertyInfo.GetValue(_installation);
        }

        /// <summary>
        /// Retrieves information about a method
        /// </summary>
        /// <param name="name">The method name</param>
        /// <param name="bindingAttr">The <see cref="BindingFlags"/> to use</param>
        /// <returns>The <see cref="MethodInfo"/>, or null if it doesn't exist</returns>
        public MethodInfo GetMethod(string name, BindingFlags bindingAttr)
        {
            return _installation.GetType().GetMethod(name, bindingAttr);
        }

        public MethodInfo GetBaseMethod(string name, BindingFlags bindingFlags)
        {
            return _baseInstallationType?.GetMethod(name, bindingFlags);
        }

        /// <summary>
        /// Invokes a given method
        /// </summary>
        /// <param name="methodInfo">The method's <see cref="MethodInfo"/></param>
        /// <param name="parameters">Parameters to pass to the invocation</param>
        /// <returns>The value returned by the method</returns>
        public object Invoke(MethodInfo methodInfo, object[] parameters)
        {
            return methodInfo.Invoke(_installation, parameters);
        }

        /// <summary>
        /// Retrieves methods with a given <see cref="BindingFlags"/>
        /// </summary>
        /// <param name="bindingAttr">The method binding</param>
        /// <returns>An array of methods discovered, or an empty array if none are found</returns>
        public MethodInfo[] GetMethods(BindingFlags bindingAttr)
        {
            return _installation.GetType().GetMethods(bindingAttr);
        }

        /// <summary>
        /// Retrieves the underlying <see cref="Installation"/> reference as a constant
        /// </summary>
        /// <returns>The underlying <see cref="Installation"/> as an <see cref="System.Linq.Expressions.Expression"/></returns>
        public System.Linq.Expressions.Expression GetConstant()
        {
            return System.Linq.Expressions.Expression.Constant(_installation);
        }

        /// <summary>
        /// Registers that a field was encountered
        /// </summary>
        /// <param name="fieldInfo">The <see cref="FieldInfo"/> of the field</param>
        /// <returns>The field name, or an aliased name if not unique</returns>
        public string RegisterGlobalVariable(FieldInfo fieldInfo)
        {
            if(!_referencedGlobalVariables.TryGetValue(fieldInfo, out string alias))
            {
                alias = fieldInfo.Name;
                if (_referencedGlobalVariables.Values.Any(name => name == alias))
                {
                    // not unique, must produce alias
                    alias = $"{alias}_{fieldInfo.DeclaringType.Name}";
                }

                _referencedGlobalVariables.Add(fieldInfo, alias);
            }

            return alias;
        }

        /// <summary>
        /// Tests if a variable name is declared locally or globally
        /// </summary>
        /// <param name="variableName">The name of the variable</param>
        /// <returns>True if the variable is declared, otherwise false</returns>
        public bool IsVariable(string variableName)
        {
            return LocalVariables.ContainsKey(variableName) || 
                    _referencedGlobalVariables.Any(f => f.Key.Name == variableName) ||
                    typeof(Installation).GetProperty(variableName) != null;
        }

        public bool IsString(string variableName)
        {
            if (LocalVariables.TryGetValue(variableName, out var value))
            {
                return value.CSharpType == typeof(string);
            }

            var globalVar = _referencedGlobalVariables.Where(f => f.Key.Name == variableName).Select(f => f.Key).FirstOrDefault();
            return globalVar?.FieldType == typeof(string);
        }

        /// <summary>
        /// Declares a type as having been visited
        /// </summary>
        /// <param name="memberInfo">The member visited</param>
        /// <returns>True if the type was declared, or false if previously declared</returns>
        public bool DeclareMember(MemberInfo memberInfo)
        {
            return _declaredMembers.Add(memberInfo);
        }

        /// <summary>
        /// Indicates a method has been defined
        /// </summary>
        /// <param name="methodInfo">The method's <see cref="MethodInfo"/></param>
        /// <returns>True if the method was declared, or false if previously declared</returns>
        public bool DefinedMethod(MethodInfo methodInfo)
        {
            return _definedMethods.Add(methodInfo.DeclaringType.Name + "." + methodInfo.Name);
        }

        /// <summary>
        /// Retrieves a type, given a name
        /// </summary>
        /// <param name="name">The string name of the type</param>
        /// <returns>The resolved <see cref="Type"/>, or null if the type was not found</returns>
        public Type GetType(string name)
        {
            return GetFullyQualifiedNames(name)
                .SelectMany(fq => Namespaces.Select(ns => $"{ns}.{fq}"))
                .Select(t => Type.GetType(t))
                .FirstOrDefault(t => t != null);
        }

        /// <summary>
        /// Collection of local variables, keyed by name, where the value is the pascal type
        /// </summary>
        public IDictionary<string, LoadedType> LocalVariables { get; }

        /// <summary>
        /// Collection of namespaces visible to the current node
        /// </summary>
        public HashSet<string> Namespaces { get; }

        /// <inheritdoc/>
        protected override void OnDisposing()
        {
            // disposal is taken care of elsewhere
        }

        private IEnumerable<string> GetFullyQualifiedNames(string typeName)
        {
            yield return typeName;

            var executingAssembly = Assembly.GetEntryAssembly();
            yield return $"{typeName}, {executingAssembly.FullName}";

            foreach (var fmt in executingAssembly.GetReferencedAssemblies().Select(assm => $"{typeName}, {assm.FullName}"))
                yield return fmt;
        }
    }
}
