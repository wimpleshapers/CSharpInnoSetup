
using CodingMuscles.CSharpInnoSetup.Script;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using CodingMuscles.CSharpInnoSetup.Utilities;
using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Linq;
using System.Reflection;
using CodingMuscles.CSharpInnoSetup.Generation.Output;
using ICSharpCode.Decompiler.TypeSystem;
using System.Runtime.InteropServices;
using CodingMuscles.CSharpInnoSetup.Converter;
using System.Collections.Generic;
using System.Dynamic;
using System.Text.RegularExpressions;
using ICSharpCode.Decompiler.Semantics;
using System.Globalization;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    internal class PascalScriptVisitor : AbstractVisitor
    {
        private const string _thisKeyword = "this";
        private const string _baseKeyword = "base";
        protected readonly PascalScriptVisitorContext _context;
        private bool _ignoreSeparator;
        /// <summary>
        /// Default visitor behavior is to strip the "base." or "this." from a 
        /// member reference - setting this to true preserves them when they're
        /// required to resolve an invocation, for example
        /// </summary>
        private bool _preserveReferences;

        public PascalScriptVisitor(PascalScriptVisitorContext context, bool preserveReferences = false)
        {
            _context = context;
            _preserveReferences = preserveReferences;
        }

        public override void VisitAssignmentExpression(AssignmentExpression syntax)
        {
            string VisitSide(Expression side)
            {
                using (var snippet = new Snippet())
                {
                    using (var codeWriter = new TextCodeWriter(snippet, null, true))
                    {
                        var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter));
                        side.Visit(visitor);
                    }

                    return snippet.Lines.Single();
                }
            }

            // identify the variable/type being assigned
            var variable = VisitSide(syntax.Left);
            var conditional = syntax.Right.Descendants.OfType<ConditionalExpression>().FirstOrDefault();

            if (conditional != null)
            {
                Write("if ");
                conditional.Condition.Visit(this);
                WriteLine(" then");

                using(WriteIndent())
                {
                    Write($"{variable} := ");
                    conditional.TrueExpression.Visit(this);
                }

                WriteBlankLine();
                WriteLine("else");

                using (WriteIndent())
                {
                    Write($"{variable} := ");
                    conditional.FalseExpression.Visit(this);
                }

                return;
            }

            var rhs = VisitSide(syntax.Right);

            string format = "{0} {3} {0} {1} {2}";

            if (syntax.Operator == AssignmentOperatorType.Assign)
            {
                var methodInfo = BindingSearch.Flags.Select(f => _context.GetMethod(rhs, f)).FirstOrDefault(m => m != null);
                if(methodInfo != null)
                {
                    rhs = $"@{rhs}";

                    if (_context.DefinedMethod(methodInfo))
                    {
                        var syntaxTree = _context.GetMethodSyntaxTree(methodInfo);

                        using (var methodDeclCodeWriter = _context.NewMethodDeclWriter())
                        {
                            var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(
                                _context,
                                codeWriter: methodDeclCodeWriter,
                                aliasFactory: a => a));

                            syntaxTree.VisitChildren(visitor);
                            methodDeclCodeWriter.WriteBlankLine();
                        }
                    }
                }

                format = "{0} {1} {2}";
            }
            else
            {
                if(syntax.Operator == AssignmentOperatorType.Add)
                {
                    var methodInfo = BindingSearch.Flags.Select(f => _context.GetMethod(rhs, f)).FirstOrDefault(m => m != null);
                    var isEvent = false;

                    if(methodInfo != null)
                    {
                        // we have to assume this is a reference to a method and requires an '@'
                        rhs = "@" + rhs;
                        isEvent = true;

                        if (_context.DefinedMethod(methodInfo))
                        {
                            var syntaxTree = _context.GetMethodSyntaxTree(methodInfo);

                            using (var methodDeclCodeWriter = _context.NewMethodDeclWriter())
                            {
                                var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(
                                    _context,
                                    codeWriter: methodDeclCodeWriter,
                                    aliasFactory: a => a));

                                syntaxTree.VisitChildren(visitor);
                                methodDeclCodeWriter.WriteBlankLine();
                            }
                        }
                    }
                    else if(_context.LocalVariables.TryGetValue(rhs, out var loadedType))
                    {
                        isEvent = typeof(Delegate).IsAssignableFrom(loadedType.CSharpType);
                    }

                    if (isEvent)
                    {
                        format = "{0} {3} {2}";
                    }
                }
            }

            Write(string.Format(format, variable, syntax.Operator.ToPascal(), rhs, AssignmentOperatorType.Assign.ToPascal()));
        }

        public override void VisitBinaryOperatorExpression(BinaryOperatorExpression syntax)
        {
            if (syntax.Operator == BinaryOperatorType.NullCoalescing &&
                syntax.Right is PrimitiveExpression primitiveExpression &&
                primitiveExpression.Value is string str &&
                str == string.Empty)
            {
                // This can happen for simple string interpolation, e.g. $"{__app}", so just drop 
                // the rhs in that case since pascal doesn't have null coalescing syntax support.
                // Otherwise it is assumed the null coalescing operator was intentional in which
                // case we'll drop down below and throw an exception.
                syntax.Left.Visit(this);
                return;
            }

            WriteLParen();

            syntax.Left.Visit(this);

            WriteSpace();
            Write(syntax.Operator.ToPascal());
            WriteSpace();

            syntax.Right.Visit(this);

            WriteRParen();
        }

        public override void VisitBlockStatement(BlockStatement syntax)
        {
            syntax.VisitChildren(this);                  
        }

        public override void VisitExpressionStatement(ExpressionStatement syntax)
        {
            // nop default/null assignments, as they have no translation in pascal
            if(syntax.FirstChild is AssignmentExpression assignmentExpression)
            {
                if(assignmentExpression.Right is DefaultValueExpression || assignmentExpression.Right is NullReferenceExpression)
                {
                    return;
                }
            }

            syntax.Expression.Visit(this);
            WriteEndOfStatement();
        }

        public override void VisitIdentifier(Identifier syntax)
        {
            if (_context.LocalVariables.ContainsKey(syntax.Name))
            {
                Write(syntax.Name);
            }
            else
            {
                var name = syntax.Name;

                // ensure this is not a method chain, because those don't get evaluated
                if (!(syntax.Parent is MemberReferenceExpression mreParent) || syntax.PrevSibling.Annotations.Any(a => a is ThisResolveResult))
                {
                    var field = BindingSearch.Flags.Select(f => _context.GetField(name, f)).FirstOrDefault(f => f != null);

                    if (field == null)
                    {
                        var property = BindingSearch.Flags.Select(f => _context.GetProperty(name, f)).FirstOrDefault(p => p != null);

                        if (property != null && property.GetCustomAttribute<BuiltInSymbolAttribute>() == null)
                        {
                            var value = _context.GetValue(property) as string;
                            Write($"'{value}'");
                            return;
                        }
                    }
                    else
                    {
                        if (field.DeclaringType == typeof(Installation))
                        {
                            var value = _context.GetValue(field) as string;
                            Write($"'{value}'");
                            return;
                        }

                        LoadType(field.FieldType);

                        name = _context.RegisterGlobalVariable(field);
                    }
                }

                Write(name);
            }
        }

        public override void VisitIdentifierExpression(IdentifierExpression syntax)
        {
            syntax.IdentifierToken.Visit(this);
        }

        public override void VisitIfElseStatement(IfElseStatement syntax)
        {
            WriteSeparatorLine();

            Write("if ");
            syntax.Condition.Visit(this);
            WriteLine(" then");

            WriteBegin();

            using (WriteIndent())
            {
                syntax.TrueStatement.Visit(this);
            }

            var writeEnd = true;

            if(!syntax.FalseStatement.IsNull)
            {
                WriteLine("end");

                if (syntax.FalseStatement is IfElseStatement)
                {
                    Write("else ");
                    syntax.FalseStatement.Visit(this);
                    writeEnd = false;
                }
                else
                {
                    WriteLine("else");
                    WriteBegin();

                    using(WriteIndent())
                    {
                        syntax.FalseStatement.Visit(this);
                    }
                }
            }

            if (writeEnd)
            {
                WriteEnd();
            }
        }

        public override void VisitInvocationExpression(InvocationExpression syntax)
        {
            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter), preserveReferences: true);
                    syntax.Target.Visit(visitor);
                }

                var target = snippet.Lines.Single();
                var targetParts = target.Split('.');
                var objectName = targetParts.Length > 1 ? targetParts[0] : null;
                var methodName = targetParts[targetParts.Length - 1];

                string methodCallFormat = "{2}";
                MethodInfo methodInfo = null;
                Func<string> declareMethodHandler = null;

                // The "this" reference doesn't add any more information.  By default, when 
                // objectName is null, the assumption is already made that the call is in the 
                // context of "this".  Drop it - we'll fall through to a part of the code 
                // already capable of dealing with it.
                objectName = (objectName == _thisKeyword) ? null : objectName;

                if (objectName == null)
                {
                    methodCallFormat = "{1}";

                    // see if method is built-in
                    methodInfo = typeof(Installation)
                        .GetMethods(BindingFlags.Public|BindingFlags.Instance)
                        .Where(m => m.GetCustomAttribute<BuiltInSymbolAttribute>() != null)
                        .FirstOrDefault(m => m.Name == methodName);

                    if (methodInfo == null)
                    {
                        methodInfo = BindingSearch.Flags.Select(f => _context.GetMethod(methodName, f)).FirstOrDefault(m => m != null);
                    }
                }
                else if (objectName == _baseKeyword)
                {
                    methodInfo = BindingSearch.Flags.Select(f => _context.GetBaseMethod(methodName, f)).FirstOrDefault(m => m != null);

                    if (methodInfo != null)
                    {
                        methodCallFormat = "{1}";

                        declareMethodHandler = () =>
                        {
                            var methodPrefix = $"{methodInfo.DeclaringType.Name}_";
                            var syntaxTree = _context.GetMethodSyntaxTree(methodInfo);

                            using (var methodDeclCodeWriter = _context.NewMethodDeclWriter())
                            {
                                var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(
                                    _context,
                                    codeWriter: methodDeclCodeWriter,
                                    aliasFactory: a => $"{methodPrefix}{a}",
                                    baseInstallationType: methodInfo.DeclaringType.BaseType));

                                syntaxTree.VisitChildren(visitor);
                                methodDeclCodeWriter.WriteBlankLine();
                            }

                            return $"{methodPrefix}{methodName}";
                        };
                    }
                }
                else if (!_context.IsVariable(objectName))
                {
                    var visitedMethods = new List<MethodInfo>();
                    var visitor = new InvocationExpressionEvaluator(_context, visitedMethods, t => typeof(Installation) == t);

                    if (visitor.TryVisit(syntax))
                    {
                        // the result is assumed to be a string
                        Write($"'{visitor.Result}'");
                        return;
                    }
                    else
                    {
                        methodInfo = BindingSearch.Flags.Select(f => _context.GetMethod(methodName, f)).FirstOrDefault(m => m != null);
                        methodCallFormat = "{1}";
                    }
                }

                if (methodInfo != null && methodInfo.GetCustomAttribute<BuiltInSymbolAttribute>() == null)
                {
                    if (methodInfo.GetCustomAttribute<DllImportAttribute>() is DllImportAttribute dllImport)
                    {
                        if (_context.DeclareMember(methodInfo))
                        {
                            DeclareMethod(methodInfo, _context.TypeWriter);

                            using (_context.TypeWriter.Indent())
                            {
                                var callingConvention = dllImport.CallingConvention switch
                                {
                                    CallingConvention.StdCall => "stdcall",
                                    CallingConvention.Cdecl => "cdecl",
                                    _ => throw new NotSupportedException($"The calling convention {dllImport.CallingConvention} is not supported")
                                };

                                _context.TypeWriter.Write($"external '{dllImport.EntryPoint ?? methodInfo.Name}@{dllImport.Value} {callingConvention}");

                                if (methodInfo.GetCustomAttribute<ExternalSymbolOptionsAttribute>() is ExternalSymbolOptionsAttribute optionsAttribute)
                                {
                                    var converter = new EnumToStringConverter<ExternalSymbolOption>();
                                    var options = converter.ConvertTo(optionsAttribute.Options, typeof(string)) as string;

                                    _context.TypeWriter.Write($" {options}");
                                }

                                _context.TypeWriter.WriteLine("';");
                                _context.TypeWriter.WriteBlankLine();
                            }
                        }
                    }
                    else if (_context.DefinedMethod(methodInfo))
                    {
                        if (declareMethodHandler == null)
                        {
                            var syntaxTree = _context.GetMethodSyntaxTree(methodInfo);

                            using (var methodDeclCodeWriter = _context.NewMethodDeclWriter())
                            {
                                var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(
                                    _context,
                                    codeWriter: methodDeclCodeWriter,
                                    aliasFactory: a => a));

                                syntaxTree.VisitChildren(visitor);
                                methodDeclCodeWriter.WriteBlankLine();
                            }
                        }
                        else
                        {
                            methodName = declareMethodHandler();
                        }
                    }
                }

                Write(string.Format(methodCallFormat, objectName, methodName, target));
                WriteLParen();

                var containsVariableArgList = false;
                ParameterInfo parameter = null;

                syntax.Arguments.ForEach((arg, index) =>
                {
                    if (index > 0)
                    {
                        WriteComma();
                    }

                    if (!containsVariableArgList)
                    {
                        // use parameter from the last time it was initialized
                        // as the variable argument list is always last
                        parameter = methodInfo?.GetParameters()[index];

                        if (parameter?.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0)
                        {
                            Write("[");
                            containsVariableArgList = true;
                        }
                    }

                    var argMethodName = string.Empty;

                    if (parameter?.GetCustomAttribute<CallbackAttribute>() != null)
                    {
                        if (arg is PrimitiveExpression primitive && primitive.Value is string name)
                        {
                            if (BindingSearch.Flags.All(f => _context.GetMethod(name, f) == null))
                            {
                                throw new NotSupportedException($"The argument name {name} must refer to a method");
                            }

                            argMethodName = name;
                            Write($"@{name}");
                        }
                        else
                        {
                            throw new NotSupportedException($"Argument callback expression \"{arg}\" must be a primitive");
                        }
                    }
                    else if (parameter != null && TryGetMethodReference(parameter, arg, out argMethodName))
                    {
                        Write($"@{argMethodName}");
                    }
                    else
                    {
                        arg.Visit(this);
                    }

                    if (argMethodName != string.Empty)
                    {
                        var argMethod = BindingSearch.Flags.Select(f => _context.GetMethod(argMethodName, f)).FirstOrDefault(m => m != null);

                        if (argMethod != null && _context.DefinedMethod(argMethod))
                        {
                            var syntaxTree = _context.GetMethodSyntaxTree(argMethod);

                            using (var methodDeclCodeWriter = _context.NewMethodDeclWriter())
                            {
                                var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(
                                    _context,
                                    aliasFactory: a => a,
                                    codeWriter: methodDeclCodeWriter));

                                syntaxTree.VisitChildren(visitor);
                                methodDeclCodeWriter.WriteBlankLine();
                            }
                        }
                    }
                });

                if(containsVariableArgList)
                {
                    Write("]");
                }

                WriteRParen();
            }
        }

        public override void VisitMemberReferenceExpression(MemberReferenceExpression syntax)
        {
            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    syntax.Target.Visit(new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter)));
                }

                var target = snippet.Lines.Single();

                // the decomipler will convert 0xff, for example, into byte.MaxValue, so we must account for type references

                if(_typeAliases.TryGetValue(target, out var typeValue))
                {
                    // we can't get type information from System.byte, for example - only System.Byte, so get the actual type
                    target = typeValue.Name;
                }

                FieldInfo field;
                // when referencing an enum, etc, we want to drop the type qualification since
                // everything in pascal is in the global namespace
                var type = GetTypeHarmless(target);

                if(type != null)
                {
                    if (type.GetCustomAttribute<GlobalNamespaceAttribute>() != null)
                    {
                        field = type.GetField(syntax.MemberName);
                        var alias = field?.GetCustomAttribute<AliasAttribute>()?.Name;

                        // strip dot-notation
                        Write(alias ?? syntax.MemberName);
                        return;
                    }

                    field = type.GetField(syntax.MemberName, BindingFlags.Public|BindingFlags.Static);
                    if (field != null)
                    {
                        var value = field.GetValue(null);
                        if (value != null)
                        {
                            Write(FormatPrimitive(value));
                            return;
                        }
                    }
                }

                field = BindingSearch.Flags.Select(f => _context.GetField(syntax.MemberName, f)).FirstOrDefault(f => f != null);

                if (field?.DeclaringType == typeof(Installation))
                {
                    if (field.GetCustomAttribute<MacroAttribute>() == null)
                    {
                        // this is meant to be evaluated
                        var value = _context.GetValue(field) as string;
                        Write($"'{value}'");
                    }
                    else
                    {
                        // don't write the value, but the name
                        Write(field.Name);
                    }
                }
                else if((target == _baseKeyword || target == _thisKeyword) && !_preserveReferences)
                {
                    syntax.MemberNameToken.Visit(this);
                }
                else
                {
                    Write($"{target}.");
                    syntax.MemberNameToken.Visit(this);
                }
            }
        }

        public override void VisitMethodDeclaration(MethodDeclaration syntax)
        {
            var returnType = LoadType(syntax.ReturnType);
            var innoName = _context.GetAlias(syntax.Name) ?? syntax.Name;

            var parameters = syntax.Parameters.ToDictionary(
                p => p.Name,
                p =>
                {
                    var Mod = p.ParameterModifier switch
                    {
                        ICSharpCode.Decompiler.CSharp.Syntax.ParameterModifier.Ref => "var ",
                        ICSharpCode.Decompiler.CSharp.Syntax.ParameterModifier.Out => "out ",
                        _ => ""
                    };
                    
                    return (Mod, LoadType(p.Type));
                });

            var arguments = string.Join("; ", parameters.Select(v => $"{v.Value.Mod}{v.Key}: {v.Value.Item2.PascalTypeName}"));
            var variables = parameters.ToDictionary(e => e.Key, e => e.Value.Item2);
            var variablesToSkip = variables.Count;

            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    if (returnType.CSharpType == typeof(void))
                    {
                        // procedure
                        codeWriter.WriteLine($"procedure {innoName}({arguments});");
                    }
                    else
                    {
                        // function
                        codeWriter.WriteLine($"function {innoName}({arguments}): {returnType.PascalTypeName};");
                    }

                    using (var bodySnippet = new Snippet())
                    {
                        using (var bodyCodeWriter = new TextCodeWriter(bodySnippet, null, true))
                        {
                            var visitor = new PascalScriptVisitor(new PascalScriptVisitorContext(
                                _context, 
                                bodyCodeWriter, 
                                localVariables: variables));
                            syntax.VisitChildren(visitor, children => children.OfType<BlockStatement>());
                        }

                        if (variables.Count - variablesToSkip > 0)
                        {
                            codeWriter.WriteVar();

                            using (codeWriter.Indent())
                            {
                                variables.Skip(variablesToSkip).ForEach(v => codeWriter.WriteLine($"{v.Key}: {v.Value.PascalTypeName};"));
                            }
                        }

                        codeWriter.WriteBegin();

                        using (codeWriter.Indent())
                        {
                            bodySnippet.CopyTo(codeWriter);
                        }

                        codeWriter.WriteEnd();
                    }
                }

                snippet.CopyTo(_context);
            }
        }

        public override void VisitObjectCreateExpression(ObjectCreateExpression syntax)
        {
            if (syntax.Type is SimpleType simpleType)
            {
                var type = LoadType(simpleType);

                if(type.CSharpType == null)
                {
                    throw new NotSupportedException($"Unable to instantiate type {simpleType.Identifier}");
                }

                if(type.CSharpType.GetCustomAttribute<BuiltInSymbolAttribute>() == null)
                {
                    throw new NotSupportedException($"Unable to instantiate type {simpleType.Identifier}");
                }

                var baseType = type.CSharpType;

                while(baseType != null)
                {
                    if(baseType == typeof(TObject))
                    {
                        // all types derived from TObject have use a Create constructor
                        Write($"{simpleType.Identifier}.Create");

                        if(syntax.Arguments?.Count > 0)
                        {
                            WriteLParen();

                            syntax.Arguments.ForEach((element, index) =>
                            {
                                if (index > 0)
                                {
                                    WriteComma();
                                }

                                element.Visit(this);
                            });

                            WriteRParen();
                        }

                        break;
                    }

                    baseType = baseType.BaseType;
                }

                return;
            }

            throw new NotSupportedException($"Non-Pascal compliant syntax: {syntax}");
        }

        public override void VisitPrimitiveExpression(PrimitiveExpression syntax)
        {
            var formattedValue = FormatPrimitive(syntax.Value);
            if (syntax.Value is string)
                formattedValue = $"'{formattedValue}'";

            Write(formattedValue);
        }

        public override void VisitPrimitiveType(PrimitiveType syntax)
        {
            Write(syntax.Keyword);
        }

        private static string MatchEvaluator(Match match)
        {
            var replacements = new[]
            {
                ("\r", "#13"),
                ("\n", "#10"),
                ("\t", "#9"),
                ("\v", "#11"),
                ("\b", "#8"),
                ("\a", "#7"),
                ("\f", "#12")
            };

            var value = match.Value;

            replacements.ForEach(r => value = value.Replace(r.Item1, r.Item2));

            return $"'{value}'";
        }

        public static string FormatPrimitive(object value)
        {
            return value switch
            {
                bool b => b ? "True" : "False",
                string s => Regex.Replace(s.Replace("'", "''"), "[\r\n\t\v\b\a\f]+", MatchEvaluator),
                char c => $"#{Convert.ToByte(c):d}",
                Enum e => FormatEnum(e),
                _ => Convert.ToString(value, CultureInfo.InvariantCulture)
            };
        }

        public static string FormatEnum(Enum e)
        {
            var name = e.ToString();
            return e.GetType().GetField(name).GetCustomAttribute<AliasAttribute>()?.Name ?? name;
        }

        public override void VisitReturnStatement(ReturnStatement syntax)
        {
            WriteSeparatorLine();

            if (!syntax.Expression.IsNull)
            {
                Write($"Result {AssignmentOperatorType.Assign.ToPascal()} ");
                syntax.Expression.Visit(this);
                WriteEndOfStatement();
            }

            Write("exit");
            WriteEndOfStatement();
        }

        public override void VisitSimpleType(SimpleType syntax)
        {
            Write(syntax.Identifier);
        }

        public override void VisitThrowStatement(ThrowStatement syntax)
        {
            WriteSeparatorLine();
            Write("RaiseException");

            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    syntax.Expression.Visit(new ExceptionVisitor(new PascalScriptVisitorContext(_context, codeWriter)));
                }

                Write(snippet.Lines.Single());
            }

            WriteEndOfStatement();
        }

        public override void VisitTryCatchStatement(TryCatchStatement syntax)
        {
            WriteSeparatorLine();
            WriteLine("try");

            using(WriteIndent())
            {
                syntax.TryBlock.Visit(this);
            }

            if(syntax.CatchClauses.Count == 1)
            {
                var clause = syntax.CatchClauses.First();
                if(!clause.Type.IsNull)
                {
                    throw new NotSupportedException("Catch clause cannot specify a pattern");
                }

                WriteLine("except");

                using (WriteIndent())
                {
                    clause.Visit(this);
                }
            }
            else if(syntax.CatchClauses.Count > 1)
            {
                throw new NotSupportedException("Limited to a single catch clause");
            }

            if(!syntax.FinallyBlock.IsNull)
            {
                WriteLine("finally");

                using (WriteIndent())
                {
                    syntax.FinallyBlock.Visit(this);
                }
            }

            WriteEnd();
        }

        public override void VisitTypeReferenceExpression(TypeReferenceExpression syntax)
        {
            syntax.Type.Visit(this);
        }

        public override void VisitUnaryOperatorExpression(UnaryOperatorExpression syntax)
        {
            using(var snippet = new Snippet())
            {
                using(var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    syntax.Expression.Visit(new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter)));
                }

                var expression = snippet.Lines.Single();

                switch (syntax.Operator)
                {
                    // Logical not (!a)
                    case UnaryOperatorType.Not:
                        expression = $"(not ({expression}))";
                        break;
                    // Unary minus (-a)
                    case UnaryOperatorType.Minus:
                        expression = $"-({expression})";
                        break;
                    // Unary plus (+a)
                    case UnaryOperatorType.Plus:
                        expression = $"+({expression})";
                        break;
                    // Post increment (a++)
                    case UnaryOperatorType.PostIncrement:
                        expression = $"{expression} := {expression} + 1";
                        break;
                    // Post decrement (a--)
                    case UnaryOperatorType.PostDecrement:
                        expression = $"{expression} := {expression} - 1";
                        break;
                    // Implicit true operator...just a pass thru
                    case UnaryOperatorType.IsTrue:
                        break;
                    // Implicit * operator...just a pass thru
                    case UnaryOperatorType.Dereference:
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported operator {syntax.Operator}");
                }

                Write(expression);
            }
        }

        public override void VisitCatchClause(CatchClause syntax)
        {
            syntax.Body.Visit(this);
        }

        public override void VisitUsingDeclaration(UsingDeclaration syntax)
        {
            _context.Namespaces.Add(syntax.Namespace);
        }

        public override void VisitUsingStatement(UsingStatement syntax)
        {
            // safe to ignore
        }

        public override void VisitBaseReferenceExpression(BaseReferenceExpression syntax)
        {
            Write(_baseKeyword);
        }

        public override void VisitVariableDeclarationStatement(VariableDeclarationStatement syntax)
        {
            var variables = syntax.Variables.ToList();
            if(variables.Count > 1)
            {
                throw new NotSupportedException("Variable initializers are limited to one per line");
            }

            var variable = variables.Single();
            var type = LoadType(syntax.Type);

            _context.LocalVariables.Add(variable.Name, type);

            if(variable.Initializer.IsNull ||
               (type.CSharpType?.IsStruct() == true && 
               variable.FirstChild?.NextSibling.GetType() == typeof(ObjectCreateExpression)))
            {
                // structs must be initialized in C#, but they don't get initialized in pascal
                return;
            }

            variable.Visit(this);
            WriteEndOfStatement();
        }

        public override void VisitVariableInitializer(VariableInitializer syntax)
        {
            syntax.NameToken.Visit(this);

            if(!(syntax.Initializer is DefaultValueExpression))
            {
                WriteAssign();
                syntax.Initializer.Visit(this);
            }
        }

        public override void VisitWhileStatement(WhileStatement syntax)
        {
            Write("while ");
            syntax.Condition.Visit(this);
            WriteLine(" do");

            WriteBegin();

            using(WriteIndent())
            {
                syntax.EmbeddedStatement.Visit(this);
            }

            WriteEnd();
        }

        public override void VisitForStatement(ForStatement syntax)
        {
            // turn this into a while, as there's no way to easily handle increments by anything other than 1
            syntax.Initializers.ForEach(i => i.Visit(this));

            Write("while ");
            syntax.Condition.Visit(this);
            WriteLine(" do");

            WriteBegin();

            using (WriteIndent())
            {
                syntax.EmbeddedStatement.Visit(this);

                syntax.Iterators.ForEach(i => i.Visit(this));
            }

            WriteEnd();
        }

        public override void VisitDoWhileStatement(DoWhileStatement syntax)
        {
            WriteLine("repeat");

            using(WriteIndent())
            {
                syntax.EmbeddedStatement.Visit(this);
            }

            Write("until not (");

            syntax.Condition.Visit(this);

            Write(")");
            WriteEndOfStatement();
        }

        public override void VisitBreakStatement(BreakStatement syntax)
        {
            WriteLine("break;");
        }

        public override void VisitContinueStatement(ContinueStatement syntax)
        {
            WriteLine("continue;");
        }

        public override void VisitDirectionExpression(DirectionExpression syntax)
        {
            switch(syntax.FieldDirection)
            {
                case FieldDirection.Ref:
                case FieldDirection.Out:
                    syntax.Expression.Visit(this);
                    break;

                default:
                    throw new NotSupportedException($"Unsupported field direction {syntax.FieldDirection}");
            }
        }

        public override void VisitInterpolatedStringExpression(InterpolatedStringExpression syntax)
        {
            syntax.Content.ForEach((c, i) =>
            {
                if (i > 0)
                {
                    Write(" + ");
                }

                c.Visit(this);
            });
        }

        public override void VisitInterpolation(Interpolation syntax)
        {
            syntax.Expression.Visit(this);
        }

        public override void VisitInterpolatedStringText(InterpolatedStringText syntax)
        {
            Write($"'{syntax.Text}'");
        }

        public override void VisitNullReferenceExpression(NullReferenceExpression syntax)
        {
            Write("Null");
        }

        public override void VisitThisReferenceExpression(ThisReferenceExpression syntax)
        {
            Write(_thisKeyword);   
        }

        public override void VisitCastExpression(CastExpression syntax)
        {
            if(syntax.Type is SimpleType simpleType)
            {
                var typeResult = simpleType.Annotations.OfType<TypeResolveResult>().FirstOrDefault(t => t != null);
                var typeName = typeResult == null ? simpleType.Identifier : typeResult.Type.ReflectionName.Substring(typeResult.Type.ReflectionName.LastIndexOf('.') + 1);
                var type = _context.GetType(typeName);

                if(type != null && (type.IsInterface || typeof(TObject).IsAssignableFrom(type)))
                {
                    var loadedType = LoadType(type);

                    Write($"{loadedType.PascalTypeName}(");
                    syntax.Expression.Visit(this);
                    Write($")");
                    
                    return;
                }
            }

            // omit the cast
            syntax.Expression.Visit(this);
        }

        public override void VisitCaseLabel(CaseLabel syntax)
        {
            syntax.Expression.Visit(this);
        }

        public override void VisitNullNode(AstNode syntax)
        {
            
        }

        public override void VisitSizeOfExpression(SizeOfExpression syntax)
        {
            Write("sizeof");
            WriteLParen();

            syntax.Type.Visit(this);

            WriteRParen();
        }

        protected override void VisitNode(AstNode syntax)
        {
            throw new NotSupportedException($"Unsupported syntax: {syntax}");
        }

        protected string VisitSingleLineExpression(Expression expression)
        {
            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    expression.Visit(new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter)));
                }

                return snippet.Lines.Single();
            }
        }

        public override void VisitArrayCreateExpression(ArrayCreateExpression syntax)
        {
            Write("[ ");

            syntax.Initializer.Elements.ForEach((element, index) =>
            {
                if(index > 0)
                {
                    WriteComma();
                }

                element.Visit(this);
            });

            Write(" ]");
        }

        public override void VisitIndexerExpression(IndexerExpression syntax)
        {
            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    syntax.Target.Visit(new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter)));
                }

                var arrayName = snippet.Lines.Single();

                Write($"{arrayName}[");

                syntax.Arguments.ForEach((arg, index) =>
                {
                    if (index > 0)
                    {
                        WriteComma();
                    }

                    arg.Visit(this);
                });

                Write("]");
            }
        }

        public override void VisitSwitchStatement(SwitchStatement syntax)
        {
            Write("case ");
            syntax.Expression.Visit(this);
            WriteLine(" of");

            AstNodeCollection<Statement> defaultStatements = null;

            using (WriteIndent())
            {
                syntax.SwitchSections.ForEach(section =>
                {
                    var defaultLabel = false;

                    section.CaseLabels.ForEach((label, index) =>
                    {
                        if(label.Expression.IsNull)
                        {
                            defaultLabel = true;
                        }
                        else 
                        {
                            if (defaultLabel)
                                throw new NotSupportedException("A default case label cannot be combined with others");

                            if (index > 0)
                            {
                                WriteComma();
                            }

                            label.Visit(this);
                        }
                    });

                    if (defaultLabel)
                    {
                        defaultStatements = section.Statements;
                    }
                    else
                    {
                        var lines = GetCaseLines(section.Statements);

                        if (lines.Count == 1)
                        {
                            Write(": ");
                            Write(lines[0]);
                        }
                        else
                        {
                            WriteLine(": ");
                            using (WriteIndent())
                            {
                                WriteBegin();

                                using (WriteIndent())
                                {
                                    lines.ForEach(l => WriteLine(l));
                                }

                                WriteEnd();
                            }
                        }
                    }
                });
            }

            if(defaultStatements != null)
            {
                WriteLine("else");

                using (WriteIndent())
                {
                    GetCaseLines(defaultStatements).ForEach(s => WriteLine(s));
                }
            }

            WriteEnd();
        }

        private List<string> GetCaseLines(AstNodeCollection<Statement> statements)
        {
            using (var snippet = new Snippet())
            {
                using (var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    statements.ForEach(s => s.Visit(new PascalScriptVisitor(new PascalScriptVisitorContext(_context, codeWriter))));
                }

                return snippet.Lines.Where(s => s != "break;").ToList();
            }
        }


        public override void VisitParenthesizedExpression(ParenthesizedExpression syntax)
        {
            WriteLParen();

            syntax.Expression.Visit(this);

            WriteRParen();
        }

        public override void VisitDefaultValueExpression(DefaultValueExpression syntax)
        {
            var type = LoadType(syntax.Type);
            
            Write(FormatPrimitive(Activator.CreateInstance(type.CSharpType)));
        }

        private LoadedType LoadType(AstType node)
        {
            Type type = null;

            switch (node)
            {
                case PrimitiveType primitiveType:
                    {
                        if (primitiveType.Keyword == "dynamic")
                        {
                            return new LoadedType("Variant", typeof(DynamicObject));
                        }
                        else
                        {
                            type = ToType(primitiveType.KnownTypeCode);
                        }
                    }
                    break;

                case ComposedType composedType:
                    {
                        var typeResult = composedType.Annotations.OfType<TypeResolveResult>().FirstOrDefault();
                        var typeName = typeResult.Type.ReflectionName.Substring(typeResult.Type.ReflectionName.LastIndexOf('.') + 1);
                        type = _context.GetType(typeName) ?? throw new NotSupportedException($"Encountered unknown type {composedType}");
                    }
                    break;

                case SimpleType simpleType:
                    {
                        var typeResult = simpleType.Annotations.OfType<TypeResolveResult>().FirstOrDefault();
                        var typeName = typeResult == null ? simpleType.Identifier : typeResult.Type.ReflectionName.Substring(typeResult.Type.ReflectionName.LastIndexOf('.') + 1);
                        var typeArguments = simpleType.TypeArguments.ToList();

                        if (typeArguments.Count > 0)
                        {
                            var args = string.Join(",", typeArguments.Select(arg => $"[{LoadType(arg).CSharpType.FullName}]"));
                            typeName += $"`{typeArguments.Count}[{args}]";
                        }

                        type = _context.GetType(typeName) ?? throw new NotSupportedException($"Encountered unknown type {simpleType.Identifier}");
                    }
                    break;
            }

            return LoadType(type);
        }

        private LoadedType LoadType(Type type)
        {
            if (type.HasElementType)
            {
                var loadedType = LoadType(type.GetElementType());
                return new LoadedType($"array of {loadedType.PascalTypeName}", type);
            }

            if (type == typeof(int))
            {
                return new LoadedType("Integer", type);
            }

            if (type == typeof(string))
            {
                return new LoadedType("String", type);
            }
            
            if (type == typeof(long))
            {
                return new LoadedType("longint", type);
            }

            if (type == typeof(void))
            {
                return new LoadedType(string.Empty, type);
            }

            if (type == typeof(bool))
            {
                return new LoadedType("Boolean", type);
            }

            if (type == typeof(uint))
            {
                return new LoadedType("Longword", type);
            }

            if(type == typeof(byte))
            {
                return new LoadedType("Byte", type);
            }

            if (type.GetCustomAttribute<BuiltInSymbolAttribute>() == null)
            {
                // if not then it must be custom and we have to declare it
                DeclareType(type);
            }
            else
            {
                var declaredAs = type.GetCustomAttribute<DeclaredAsAttribute>();
                if(declaredAs != null)
                {
                    return new LoadedType(LoadType(declaredAs.DeclaredType).PascalTypeName, type);
                }
            }

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ArrayOf<>))
            {
                var alias = type.GetCustomAttribute<AliasAttribute>()?.Name;
                var genericArgs = type.GenericTypeArguments.Select(arg => LoadType(arg).PascalTypeName).ToArray();

                return new LoadedType(string.Format(alias, genericArgs), type);
            }

            return new LoadedType(type.Name, type);
        }

        private void DeclareType(Type type)
        {
            if(!_context.DeclareMember(type))
            {
                // already declared
                return;
            }

            using(var snippet = new Snippet())
            {
                using(var codeWriter = new TextCodeWriter(snippet, null, true))
                {
                    if (type?.BaseType == typeof(MulticastDelegate))
                    {
                        var invokeMethod = type.GetMethod("Invoke");
                        codeWriter.Write($"type {type.Name} = ");
                        DeclareMethod(invokeMethod, codeWriter, string.Empty);
                    }
                    else if (type.IsEnum)
                    {
                        var members = type.GetFields().Where(f => f.FieldType == type).Select(f =>
                        {
                            var alias = f.GetCustomAttribute<AliasAttribute>();
                            return alias?.Name ?? f.Name;
                        }).ToList();

                        codeWriter.WriteLine($"type {type.Name} = ({string.Join(", ", members)});");
                    }
                    else if (type.IsStruct())
                    {
                        codeWriter.WriteLine($"type {type.Name} = record");

                        using (codeWriter.Indent())
                        {
                            type.GetFields(BindingFlags.Public | BindingFlags.Instance).ForEach(f => 
                            {
                                var fieldType = LoadType(f.FieldType);
                                codeWriter.WriteLine($"{f.Name}: {fieldType.PascalTypeName};");
                            });
                        }

                        codeWriter.WriteEnd();
                    }
                    else if(type.IsInterface)
                    {
                        codeWriter.WriteLine("type");

                        using (codeWriter.Indent())
                        {
                            var baseType = LoadType(type.GetInterfaces().First());
                            codeWriter.WriteLine($"{type.Name} = interface({baseType.PascalTypeName})");
                         
                            using (codeWriter.Indent())
                            {
                                var guid = type.GetCustomAttribute<GuidAttribute>();
                                if (guid != null)
                                {
                                    codeWriter.WriteLine($"'{{{guid.Value}}}'");
                                }

                                // write procs/functions
                                type.GetMethods(BindingFlags.Public | BindingFlags.Instance).ForEach(m =>
                                {
                                    var returnType = LoadType(m.ReturnType);
                                    var format = returnType.CSharpType == typeof(void) ?
                                        "procedure {0}({1});" :
                                        "function {0}({1}): {2};";

                                    var args = string.Join("; ", m.GetParameters().Select(p =>
                                    {
                                        var prefix = "";
                                        var parameterType = p.ParameterType;

                                        if(p.IsOut)
                                        {
                                            parameterType = p.ParameterType.GetElementType();
                                            prefix = "out ";
                                        }
                                        else if(p.ParameterType.IsByRef)
                                        {
                                            parameterType = p.ParameterType.GetElementType();
                                        }

                                        var parmType = LoadType(parameterType);

                                        return $"{prefix}{p.Name}: {parmType.PascalTypeName}";
                                    }));

                                    codeWriter.WriteLine(string.Format(format, m.Name, args, returnType.PascalTypeName));
                                });
                            }

                            codeWriter.WriteEnd();
                        }
                    }
                    else
                    {
                        throw new NotSupportedException($"Unable to declare type {type.Name}");
                    }

                    codeWriter.WriteBlankLine();
                }

                snippet.CopyTo(_context.TypeWriter);
            }
        }

        private void DeclareMethod(MethodInfo methodInfo, ICodeWriter typeWriter, string name = null)
        {
            name = name ?? methodInfo.Name;
            var format = "";

            if (methodInfo.ReturnType == typeof(void))
            {
                format = "procedure {0}({1});";
            }
            else
            {
                format = "function {0}({1}): {2};";
            }

            var parameters = methodInfo.GetParameters();

            typeWriter.WriteLine(string.Format(
                format,
                name,
                string.Join("; ", parameters.Select(p => $"{(p.ParameterType.IsByRef ? "var " : "")}{p.Name}: {LoadType(p.ParameterType.IsByRef ? p.ParameterType.GetElementType() : p.ParameterType).PascalTypeName}")),
                LoadType(methodInfo.ReturnType).PascalTypeName));
        }

        public Type ToType(KnownTypeCode typeCode)
        {
            return typeCode switch
            {
                KnownTypeCode.Boolean => typeof(bool),
                KnownTypeCode.Int32 => typeof(int),
                KnownTypeCode.String => typeof(string),
                KnownTypeCode.Int64 => typeof(long),
                KnownTypeCode.Void => typeof(void),
                KnownTypeCode.UInt32 => typeof(uint),
                KnownTypeCode.Byte => typeof(byte),
                _ => throw new NotSupportedException($"Encountered unknown primitive type {typeCode}")
            };
        }

        private Type GetTypeHarmless(string name)
        {
            try
            {
                return _context.GetType(name);
            }
            catch
            {

            }

            return null;
        }

        private bool TryGetMethodReference(ParameterInfo parameterInfo, Expression argument, out string methodName)
        {
            if(parameterInfo != null && typeof(Delegate).IsAssignableFrom(parameterInfo.ParameterType))
            {
                var identifier = argument.DescendantsAndSelf.OfType<Identifier>().SingleOrDefault();

                if (identifier != null)
                {
                    var method = BindingSearch.Flags.Select(f => _context.GetMethod(identifier.Name, f)).FirstOrDefault(m => m != null);
                    if (method != null)
                    {
                        methodName = method.Name;
                        return true;
                    }
                }
            }

            methodName = string.Empty;
            return false;
        }

        public void WriteComma()
        {
            _context.Write(", ");
        }

        public void WriteSemicolon()
        {
            _context.Write(";");
        }

        public void WriteAssign()
        {
            _context.Write(" := ");
        }

        public void WriteSpace()
        {
            _context.Write(" ");
        }

        public void WriteEndOfStatement()
        {
            _ignoreSeparator = false;
            _context.WriteLine(";");
        }

        public void WriteVar()
        {
            _context.WriteLine("var");
        }

        public void WriteBegin()
        {
            _ignoreSeparator = false;
            _context.WriteLine("begin");
        }

        public void WriteEnd()
        {
            _ignoreSeparator = false;
            _context.WriteLine("end;");
        }

        public void WriteLParen()
        {
            _context.Write("(");
        }

        public void WriteRParen()
        {
            _context.Write(")");
        }

        public void Write(string code)
        {
            _context.Write(code);
        }

        public void WriteBlankLine()
        {
            _context.WriteLine(string.Empty);
        }

        public void WriteLine(string code)
        {
            _ignoreSeparator = false;
            _context.WriteLine(code);
        }

        public void WriteSeparatorLine()
        {
            if(_ignoreSeparator)
            {
                _ignoreSeparator = false;
            }
            else
            {
                _context.WriteLine(string.Empty);
            }
        }

        public IDisposable WriteIndent()
        {
            _ignoreSeparator = true;
            return _context.Indent();
        }

        private static readonly Dictionary<string, Type> _typeAliases = new Dictionary<string, Type>
        {
            { "byte", typeof(byte) },
            { "sbyte", typeof(sbyte) },
            { "short", typeof(short) },
            { "ushort", typeof(ushort) },
            { "int", typeof(int) },
            { "uint", typeof(uint) },
            { "long", typeof(long) },
            { "ulong", typeof(ulong) },
            { "float", typeof(float) },
            { "double", typeof(double) },
            { "decimal", typeof(decimal) },
            { "bool", typeof(bool) },
            { "char", typeof(char)  }
        };
    }
}
