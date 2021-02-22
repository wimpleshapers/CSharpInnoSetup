
using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Collections.Generic;
using CodingMuscles.CSharpInnoSetup.Generation.Visitor;
using CodingMuscles.CSharpInnoSetup.Script.Constructs.Code.Library;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CodingMuscles.CSharpInnoSetup.Generation
{
    /// <summary>
    /// Extensions to types in the ICSharpCode.Decompiler.TypeSystem namespace
    /// </summary>
    internal static class NodeExtensions
    {
        /// <summary>
        /// Converts a <see cref="Type"/> to a pascal type
        /// </summary>
        /// <param name="type">The type to convert</param>
        /// <returns>The pascal type as a string</returns>
        public static string ToPascal(this Type type)
        {
            if (type == typeof(bool))
                return "Boolean";
            if (type == typeof(string))
                return "String";
            if (type == typeof(int))
                return "Integer";
            if (type.GetCustomAttribute<BuiltInSymbolAttribute>() != null)
                return type.Name;
            if (type == typeof(long))
                return "longint";
            if (type == typeof(char))
                return "Char";
            if (type == typeof(object) && type.GetCustomAttribute<DynamicAttribute>() != null)
                return "Variant";
            if (type == typeof(double))
                return "Extended";
            if (type == typeof(void))
                return string.Empty;

            return type.Name;
        }

        /// <summary>
        /// Converts a <see cref="BinaryOperatorType"/> to a pascal operator
        /// </summary>
        /// <param name="operatorType">The operator to convert</param>
        /// <returns>The pascal operator as a string</returns>
        public static string ToPascal(this BinaryOperatorType operatorType)
        {
            return operatorType switch
            {
                BinaryOperatorType.ConditionalAnd => "and",
                BinaryOperatorType.ConditionalOr => "or",
                BinaryOperatorType.ExclusiveOr => "xor",
                BinaryOperatorType.GreaterThan => ">",
                BinaryOperatorType.GreaterThanOrEqual => ">=",
                BinaryOperatorType.Equality => "=",
                BinaryOperatorType.InEquality => "<>",
                BinaryOperatorType.LessThan => "<",
                BinaryOperatorType.LessThanOrEqual => "<=",
                BinaryOperatorType.Add => "+",
                BinaryOperatorType.Subtract => "-",
                BinaryOperatorType.Multiply => "*",
                BinaryOperatorType.Divide => "div",
                BinaryOperatorType.Modulus => "mod",
                BinaryOperatorType.BitwiseOr => "or",
                BinaryOperatorType.BitwiseAnd => "and",
                _ => throw new NotSupportedException($"Unrecognized operator {operatorType}"),
            };
        }

        /// <summary>
        /// Converts an <see cref="AssignmentOperatorType"/> to a pascal operator
        /// </summary>
        /// <param name="operatorType">The operator to convert</param>
        /// <returns>The pascal operator as a string</returns>
        public static string ToPascal(this AssignmentOperatorType operatorType)
        {
            return operatorType switch
            {
                AssignmentOperatorType.Assign => ":=",
                AssignmentOperatorType.Add => "+",
                AssignmentOperatorType.Subtract => "-",
                AssignmentOperatorType.Multiply => "*",
                AssignmentOperatorType.Divide => "/",
                AssignmentOperatorType.Modulus => "%",
                AssignmentOperatorType.ShiftLeft => "<<",
                AssignmentOperatorType.ShiftRight => ">>",
                AssignmentOperatorType.BitwiseAnd => "&",
                AssignmentOperatorType.BitwiseOr => "|",
                AssignmentOperatorType.ExclusiveOr => "^",
                _ => throw new Exception($"Unsupported operator {operatorType}"),
            };
        }

        /// <summary>
        /// Visits the children of <paramref name="node"/>
        /// </summary>
        /// <param name="node">The parent node whose children to visit</param>
        /// <param name="visitor">Vists each child</param>
        /// <param name="filter">Filter to apply to child enumeration</param>
        public static void VisitChildren(this AstNode node, AbstractVisitor visitor, Func<IEnumerable<AstNode>, IEnumerable<AstNode>> filter = null)
        {
            filter ??= (children => children);

            foreach (var child in filter(node.Children))
            {
                child.AcceptVisitor(visitor);
            }
        }

        /// <summary>
        /// Visits a single node
        /// </summary>
        /// <param name="node">The node to visit</param>
        /// <param name="visitor">The visitor to accept</param>
        public static void Visit(this AstNode node, AbstractVisitor visitor)
        {
            node.AcceptVisitor(visitor);
        }
    }
}
