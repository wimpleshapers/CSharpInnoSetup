
using CodingMuscles.CSharpInnoSetup.Utilities;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    /// <summary>
    /// An <see cref="IAstVisitor"/> that declares virtual "visit" methods
    /// </summary>
    internal abstract class AbstractVisitor : Disposable, IAstVisitor
    {
        /// <summary>
        /// Method that is called if an <see cref="IAstVisitor"/> virtual method is not overridden
        /// </summary>
        /// <param name="syntax">The node to process</param>
        protected virtual void VisitNode(AstNode syntax)
        {

        }

        /// <inheritdoc/>
        public virtual void VisitAccessor(Accessor syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitArrayCreateExpression(ArrayCreateExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitArrayInitializerExpression(ArrayInitializerExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitArraySpecifier(ArraySpecifier syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitAsExpression(AsExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitAssignmentExpression(AssignmentExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitAttribute(Attribute syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitAttributeSection(AttributeSection syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitBaseReferenceExpression(BaseReferenceExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitBinaryOperatorExpression(BinaryOperatorExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitBlockStatement(BlockStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitBreakStatement(BreakStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCaseLabel(CaseLabel syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCastExpression(CastExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCatchClause(CatchClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCheckedExpression(CheckedExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCheckedStatement(CheckedStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitComment(Comment syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitComposedType(ComposedType syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitConditionalExpression(ConditionalExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitConstraint(Constraint syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitConstructorDeclaration(ConstructorDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitConstructorInitializer(ConstructorInitializer syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitContinueStatement(ContinueStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCSharpTokenNode(CSharpTokenNode syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitCustomEventDeclaration(CustomEventDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitDeclarationExpression(DeclarationExpression syntax)
        {
            VisitNode(syntax);
        }

        public virtual void VisitDefaultValueExpression(DefaultValueExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitDelegateDeclaration(DelegateDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitDestructorDeclaration(DestructorDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitDirectionExpression(DirectionExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitDocumentationReference(DocumentationReference syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitDoWhileStatement(DoWhileStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitEmptyStatement(EmptyStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitEnumMemberDeclaration(EnumMemberDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitErrorNode(AstNode syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitEventDeclaration(EventDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitExpressionStatement(ExpressionStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitExternAliasDeclaration(ExternAliasDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitFieldDeclaration(FieldDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitFixedFieldDeclaration(FixedFieldDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitFixedStatement(FixedStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitFixedVariableInitializer(FixedVariableInitializer syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitForeachStatement(ForeachStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitForStatement(ForStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitFunctionPointerType(FunctionPointerAstType syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitGotoCaseStatement(GotoCaseStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitGotoDefaultStatement(GotoDefaultStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitGotoStatement(GotoStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitIdentifier(Identifier syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitIdentifierExpression(IdentifierExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitIfElseStatement(IfElseStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitIndexerDeclaration(IndexerDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitIndexerExpression(IndexerExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitInterpolatedStringExpression(InterpolatedStringExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitInterpolatedStringText(InterpolatedStringText syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitInterpolation(Interpolation syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitInvocationExpression(InvocationExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitIsExpression(IsExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitLabelStatement(LabelStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitLambdaExpression(LambdaExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitLocalFunctionDeclarationStatement(LocalFunctionDeclarationStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitLockStatement(LockStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitMemberReferenceExpression(MemberReferenceExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitMemberType(MemberType syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitMethodDeclaration(MethodDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitNamedArgumentExpression(NamedArgumentExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitNamedExpression(NamedExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitNamespaceDeclaration(NamespaceDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitNullNode(AstNode syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitNullReferenceExpression(NullReferenceExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitObjectCreateExpression(ObjectCreateExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitOperatorDeclaration(OperatorDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitOutVarDeclarationExpression(OutVarDeclarationExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitParameterDeclaration(ParameterDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitParenthesizedExpression(ParenthesizedExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignation syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitPatternPlaceholder(AstNode placeholder, Pattern syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitPointerReferenceExpression(PointerReferenceExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitPreProcessorDirective(PreProcessorDirective syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitPrimitiveExpression(PrimitiveExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitPrimitiveType(PrimitiveType syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitPropertyDeclaration(PropertyDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryContinuationClause(QueryContinuationClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryExpression(QueryExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryFromClause(QueryFromClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryGroupClause(QueryGroupClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryJoinClause(QueryJoinClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryLetClause(QueryLetClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryOrderClause(QueryOrderClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryOrdering(QueryOrdering syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQuerySelectClause(QuerySelectClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitQueryWhereClause(QueryWhereClause syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitReturnStatement(ReturnStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSimpleType(SimpleType syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSingleVariableDesignation(SingleVariableDesignation syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSizeOfExpression(SizeOfExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitStackAllocExpression(StackAllocExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSwitchExpression(SwitchExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSwitchExpressionSection(SwitchExpressionSection syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSwitchSection(SwitchSection syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSwitchStatement(SwitchStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitSyntaxTree(SyntaxTree syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitThisReferenceExpression(ThisReferenceExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitThrowExpression(ThrowExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitThrowStatement(ThrowStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTryCatchStatement(TryCatchStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTupleExpression(TupleExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTupleType(TupleAstType syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTupleTypeElement(TupleTypeElement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTypeDeclaration(TypeDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTypeOfExpression(TypeOfExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTypeParameterDeclaration(TypeParameterDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitTypeReferenceExpression(TypeReferenceExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUnaryOperatorExpression(UnaryOperatorExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUncheckedExpression(UncheckedExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUncheckedStatement(UncheckedStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUndocumentedExpression(UndocumentedExpression syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUnsafeStatement(UnsafeStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUsingAliasDeclaration(UsingAliasDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUsingDeclaration(UsingDeclaration syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitUsingStatement(UsingStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitVariableInitializer(VariableInitializer syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitWhileStatement(WhileStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitYieldBreakStatement(YieldBreakStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        public virtual void VisitYieldReturnStatement(YieldReturnStatement syntax)
        {
            VisitNode(syntax);
        }

        /// <inheritdoc/>
        protected override void OnDisposing()
        {
        }
    }
}
