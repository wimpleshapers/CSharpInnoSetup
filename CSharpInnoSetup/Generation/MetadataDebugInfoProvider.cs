
using CodingMuscles.CSharpInnoSetup.Utilities;
using ICSharpCode.Decompiler.DebugInfo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;

namespace CodingMuscles.CSharpInnoSetup.Generation
{
    /// <summary>
    /// An <see cref="IDebugInfoProvider"/> based on the System.Reflection.Metadata package
    /// </summary>
    internal class MetadataDebugInfoProvider : Disposable, IDebugInfoProvider
    {
        private readonly PEReader _peReader;
        private readonly MetadataReaderProvider _metadataReaderProvider;
        private readonly string _pdbFileName;

        /// <summary>
        /// Initializes a new <see cref="MetadataDebugInfoProvider"/>
        /// </summary>
        /// <param name="imageName">The pathname of the image</param>
        public MetadataDebugInfoProvider(string imageName)
        {
            _peReader = new PEReader(File.OpenRead(imageName));

            if(!_peReader.TryOpenAssociatedPortablePdb(
                imageName,
                s => File.OpenRead(s),
                out _metadataReaderProvider, out _pdbFileName))
            {
                throw new ArgumentException($"Unable to load PDB for image {imageName}");
            }
        }

        /// <inheritdoc/>
        public string Description => $"Loaded from portable PDB: {_pdbFileName}";

        /// <inheritdoc/>
        public IList<ICSharpCode.Decompiler.DebugInfo.SequencePoint> GetSequencePoints(MethodDefinitionHandle method)
        {
            var metadata = _metadataReaderProvider.GetMetadataReader();
            var debugInfo = metadata.GetMethodDebugInformation(method);
            var sequencePoints = new List<ICSharpCode.Decompiler.DebugInfo.SequencePoint>();

            foreach (var point in debugInfo.GetSequencePoints())
            {
                string documentFileName;

                if (!point.Document.IsNil)
                {
                    var document = metadata.GetDocument(point.Document);
                    documentFileName = metadata.GetString(document.Name);
                }
                else
                {
                    documentFileName = "";
                }

                sequencePoints.Add(new ICSharpCode.Decompiler.DebugInfo.SequencePoint()
                {
                    Offset = point.Offset,
                    StartLine = point.StartLine,
                    StartColumn = point.StartColumn,
                    EndLine = point.EndLine,
                    EndColumn = point.EndColumn,
                    DocumentUrl = documentFileName
                });
            }

            return sequencePoints;
        }

        /// <inheritdoc/>
        public IList<Variable> GetVariables(MethodDefinitionHandle method)
        {
            var metadata = _metadataReaderProvider.GetMetadataReader();
            var variables = new List<Variable>();

            foreach (var h in metadata.GetLocalScopes(method))
            {
                var scope = metadata.GetLocalScope(h);
                foreach (var v in scope.GetLocalVariables())
                {
                    var var = metadata.GetLocalVariable(v);
                    variables.Add(new Variable(var.Index, metadata.GetString(var.Name)));
                }
            }

            return variables;
        }

        /// <inheritdoc/>
        public bool TryGetName(MethodDefinitionHandle method, int index, out string name)
        {
            var metadata = _metadataReaderProvider.GetMetadataReader();

            name = metadata.GetLocalScopes(method)
                .Select(h => metadata.GetLocalScope(h))
                .SelectMany(s => s.GetLocalVariables())
                .Select(vars => metadata.GetLocalVariable(vars))
                .Where(v => v.Index == index)
                .Select(v => metadata.GetString(v.Name))
                .FirstOrDefault();

            return name != null;
        }

        /// <inheritdoc/>
        protected override void OnDisposing()
        {
            _metadataReaderProvider.Dispose();
            _peReader.Dispose();
        }
    }
}
