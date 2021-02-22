
using System;
using System.Reflection;

namespace CodingMuscles.CSharpInnoSetup
{
    internal class InstallationMethod
    {
        private readonly MethodInfo _methodInfo;
        private readonly MethodInfo _attributeMethodInfo;

        public InstallationMethod(MethodInfo methodInfo, MethodInfo attributeMethodInfo = null)
        {
            _methodInfo = methodInfo;
            _attributeMethodInfo = attributeMethodInfo ?? methodInfo;
        }

        public string Name => _methodInfo.Name;

        public ParameterInfo[] Parameters => _methodInfo.GetParameters();

        public string AssemblyLocation => _methodInfo.DeclaringType.Assembly.Location;

        public string UniqueId => _methodInfo.Name;

        public int MetadataToken => _methodInfo.MetadataToken;

        public MethodBody MethodBody => _methodInfo.GetMethodBody();

        public T GetAttribute<T>() where T : Attribute
        {
            return _attributeMethodInfo.GetCustomAttribute<T>();
        }

        public override int GetHashCode()
        {
            return _methodInfo.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as InstallationMethod;
            return MetadataToken == other.MetadataToken;
        }
    }
}
