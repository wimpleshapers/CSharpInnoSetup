
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace CodingMuscles.CSharpInnoSetup.Generation.Visitor
{
    internal class InterceptorVisitor : AbstractVisitor
    {
        private readonly IAstVisitor _underlyingVisitor;

        public InterceptorVisitor(IAstVisitor underlyingVisitor)
        {
            _underlyingVisitor = underlyingVisitor;
        }

        public override void VisitAccessor(Accessor syntax)
        {
            _underlyingVisitor.VisitAccessor(syntax);
        }

        public override void VisitAnonymousMethodExpression(AnonymousMethodExpression syntax)
        {
            _underlyingVisitor.VisitAnonymousMethodExpression(syntax);
        }

        public override void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression syntax)
        {
            _underlyingVisitor.VisitAnonymousTypeCreateExpression(syntax);
        }

        public override void VisitArrayCreateExpression(ArrayCreateExpression syntax)
        {
            _underlyingVisitor.VisitArrayCreateExpression(syntax);
        }

        public override void VisitArrayInitializerExpression(ArrayInitializerExpression syntax)
        {
            _underlyingVisitor.VisitArrayInitializerExpression(syntax);
        }

        public override void VisitArraySpecifier(ArraySpecifier syntax)
        {
            _underlyingVisitor.VisitArraySpecifier(syntax);
        }

        public override void VisitAsExpression(AsExpression syntax)
        {
            _underlyingVisitor.VisitAsExpression(syntax);
        }

        public override void VisitAssignmentExpression(AssignmentExpression syntax)
        {
            _underlyingVisitor.VisitAssignmentExpression(syntax);
        }

        public override void VisitAttribute(ICSharpCode.Decompiler.CSharp.Syntax.Attribute syntax)
        {
            _underlyingVisitor.VisitAttribute(syntax);
        }

        public override void VisitAttributeSection(AttributeSection syntax)
        {
            _underlyingVisitor.VisitAttributeSection(syntax);
        }

        public override void VisitBaseReferenceExpression(BaseReferenceExpression syntax)
        {
            _underlyingVisitor.VisitBaseReferenceExpression(syntax);
        }

        public override void VisitBinaryOperatorExpression(BinaryOperatorExpression syntax)
        {
            _underlyingVisitor.VisitBinaryOperatorExpression(syntax);
        }

        public override void VisitBlockStatement(BlockStatement syntax)
        {
            _underlyingVisitor.VisitBlockStatement(syntax);
        }

        public override void VisitBreakStatement(BreakStatement syntax)
        {
            _underlyingVisitor.VisitBreakStatement(syntax);
        }

        public override void VisitCaseLabel(CaseLabel syntax)
        {
            _underlyingVisitor.VisitCaseLabel(syntax);
        }

        public override void VisitCastExpression(CastExpression syntax)
        {
            _underlyingVisitor.VisitCastExpression(syntax);
        }

        public override void VisitCatchClause(CatchClause syntax)
        {
            _underlyingVisitor.VisitCatchClause(syntax);
        }

        public override void VisitCheckedExpression(CheckedExpression syntax)
        {
            _underlyingVisitor.VisitCheckedExpression(syntax);
        }

        public override void VisitCheckedStatement(CheckedStatement syntax)
        {
            _underlyingVisitor.VisitCheckedStatement(syntax);
        }

        public override void VisitComment(Comment syntax)
        {
            _underlyingVisitor.VisitComment(syntax);
        }

        public override void VisitComposedType(ComposedType syntax)
        {
            _underlyingVisitor.VisitComposedType(syntax);
        }

        public override void VisitConditionalExpression(ConditionalExpression syntax)
        {
            _underlyingVisitor.VisitConditionalExpression(syntax);
        }

        public override void VisitConstraint(Constraint syntax)
        {
            _underlyingVisitor.VisitConstraint(syntax);
        }

        public override void VisitConstructorDeclaration(ConstructorDeclaration syntax)
        {
            _underlyingVisitor.VisitConstructorDeclaration(syntax);
        }

        public override void VisitConstructorInitializer(ConstructorInitializer syntax)
        {
            _underlyingVisitor.VisitConstructorInitializer(syntax);
        }

        public override void VisitContinueStatement(ContinueStatement syntax)
        {
            _underlyingVisitor.VisitContinueStatement(syntax);
        }

        public override void VisitCSharpTokenNode(CSharpTokenNode syntax)
        {
            _underlyingVisitor.VisitCSharpTokenNode(syntax);
        }

        public override void VisitCustomEventDeclaration(CustomEventDeclaration syntax)
        {
            _underlyingVisitor.VisitCustomEventDeclaration(syntax);
        }

        public override void VisitDeclarationExpression(DeclarationExpression syntax)
        {
            _underlyingVisitor.VisitDeclarationExpression(syntax);
        }

        public override void VisitDefaultValueExpression(DefaultValueExpression syntax)
        {
            _underlyingVisitor.VisitDefaultValueExpression(syntax);
        }

        public override void VisitDelegateDeclaration(DelegateDeclaration syntax)
        {
            _underlyingVisitor.VisitDelegateDeclaration(syntax);
        }

        public override void VisitDestructorDeclaration(DestructorDeclaration syntax)
        {
            _underlyingVisitor.VisitDestructorDeclaration(syntax);
        }

        public override void VisitDirectionExpression(DirectionExpression syntax)
        {
            _underlyingVisitor.VisitDirectionExpression(syntax);
        }

        public override void VisitDocumentationReference(DocumentationReference syntax)
        {
            _underlyingVisitor.VisitDocumentationReference(syntax);
        }

        public override void VisitDoWhileStatement(DoWhileStatement syntax)
        {
            _underlyingVisitor.VisitDoWhileStatement(syntax);
        }

        public override void VisitEmptyStatement(EmptyStatement syntax)
        {
            _underlyingVisitor.VisitEmptyStatement(syntax);
        }

        public override void VisitEnumMemberDeclaration(EnumMemberDeclaration syntax)
        {
            _underlyingVisitor.VisitEnumMemberDeclaration(syntax);
        }

        public override void VisitErrorNode(AstNode syntax)
        {
            _underlyingVisitor.VisitErrorNode(syntax);
        }

        public override void VisitEventDeclaration(EventDeclaration syntax)
        {
            _underlyingVisitor.VisitEventDeclaration(syntax);
        }

        public override void VisitExpressionStatement(ExpressionStatement syntax)
        {
            _underlyingVisitor.VisitExpressionStatement(syntax);
        }

        public override void VisitExternAliasDeclaration(ExternAliasDeclaration syntax)
        {
            _underlyingVisitor.VisitExternAliasDeclaration(syntax);
        }

        public override void VisitFieldDeclaration(FieldDeclaration syntax)
        {
            _underlyingVisitor.VisitFieldDeclaration(syntax);
        }

        public override void VisitFixedFieldDeclaration(FixedFieldDeclaration syntax)
        {
            _underlyingVisitor.VisitFixedFieldDeclaration(syntax);
        }

        public override void VisitFixedStatement(FixedStatement syntax)
        {
            _underlyingVisitor.VisitFixedStatement(syntax);
        }

        public override void VisitFixedVariableInitializer(FixedVariableInitializer syntax)
        {
            _underlyingVisitor.VisitFixedVariableInitializer(syntax);
        }

        public override void VisitForeachStatement(ForeachStatement syntax)
        {
            _underlyingVisitor.VisitForeachStatement(syntax);
        }

        public override void VisitForStatement(ForStatement syntax)
        {
            _underlyingVisitor.VisitForStatement(syntax);
        }

        public override void VisitFunctionPointerType(FunctionPointerAstType syntax)
        {
            _underlyingVisitor.VisitFunctionPointerType(syntax);
        }

        public override void VisitGotoCaseStatement(GotoCaseStatement syntax)
        {
            _underlyingVisitor.VisitGotoCaseStatement(syntax);
        }

        public override void VisitGotoDefaultStatement(GotoDefaultStatement syntax)
        {
            _underlyingVisitor.VisitGotoDefaultStatement(syntax);
        }

        public override void VisitGotoStatement(GotoStatement syntax)
        {
            _underlyingVisitor.VisitGotoStatement(syntax);
        }

        public override void VisitIdentifier(Identifier syntax)
        {
            _underlyingVisitor.VisitIdentifier(syntax);
        }

        public override void VisitIdentifierExpression(IdentifierExpression syntax)
        {
            _underlyingVisitor.VisitIdentifierExpression(syntax);
        }

        public override void VisitIfElseStatement(IfElseStatement syntax)
        {
            _underlyingVisitor.VisitIfElseStatement(syntax);
        }

        public override void VisitIndexerDeclaration(IndexerDeclaration syntax)
        {
            _underlyingVisitor.VisitIndexerDeclaration(syntax);
        }

        public override void VisitIndexerExpression(IndexerExpression syntax)
        {
            _underlyingVisitor.VisitIndexerExpression(syntax);
        }

        public override void VisitInterpolatedStringExpression(InterpolatedStringExpression syntax)
        {
            _underlyingVisitor.VisitInterpolatedStringExpression(syntax);
        }

        public override void VisitInterpolatedStringText(InterpolatedStringText syntax)
        {
            _underlyingVisitor.VisitInterpolatedStringText(syntax);
        }

        public override void VisitInterpolation(Interpolation syntax)
        {
            _underlyingVisitor.VisitInterpolation(syntax);
        }

        public override void VisitInvocationExpression(InvocationExpression syntax)
        {
            _underlyingVisitor.VisitInvocationExpression(syntax);
        }

        public override void VisitIsExpression(IsExpression syntax)
        {
            _underlyingVisitor.VisitIsExpression(syntax);
        }

        public override void VisitLabelStatement(LabelStatement syntax)
        {
            _underlyingVisitor.VisitLabelStatement(syntax);
        }

        public override void VisitLambdaExpression(LambdaExpression syntax)
        {
            _underlyingVisitor.VisitLambdaExpression(syntax);
        }

        public override void VisitLocalFunctionDeclarationStatement(LocalFunctionDeclarationStatement syntax)
        {
            _underlyingVisitor.VisitLocalFunctionDeclarationStatement(syntax);
        }

        public override void VisitLockStatement(LockStatement syntax)
        {
            _underlyingVisitor.VisitLockStatement(syntax);
        }

        public override void VisitMemberReferenceExpression(MemberReferenceExpression syntax)
        {
            _underlyingVisitor.VisitMemberReferenceExpression(syntax);
        }

        public override void VisitMemberType(MemberType syntax)
        {
            _underlyingVisitor.VisitMemberType(syntax);
        }

        public override void VisitMethodDeclaration(MethodDeclaration syntax)
        {
            _underlyingVisitor.VisitMethodDeclaration(syntax);
        }

        public override void VisitNamedArgumentExpression(NamedArgumentExpression syntax)
        {
            _underlyingVisitor.VisitNamedArgumentExpression(syntax);
        }

        public override void VisitNamedExpression(NamedExpression syntax)
        {
            _underlyingVisitor.VisitNamedExpression(syntax);
        }

        public override void VisitNamespaceDeclaration(NamespaceDeclaration syntax)
        {
            _underlyingVisitor.VisitNamespaceDeclaration(syntax);
        }

        public override void VisitNullNode(AstNode syntax)
        {
            _underlyingVisitor.VisitNullNode(syntax);
        }

        public override void VisitNullReferenceExpression(NullReferenceExpression syntax)
        {
            _underlyingVisitor.VisitNullReferenceExpression(syntax);
        }

        public override void VisitObjectCreateExpression(ObjectCreateExpression syntax)
        {
            _underlyingVisitor.VisitObjectCreateExpression(syntax);
        }

        public override void VisitOperatorDeclaration(OperatorDeclaration syntax)
        {
            _underlyingVisitor.VisitOperatorDeclaration(syntax);
        }

        public override void VisitOutVarDeclarationExpression(OutVarDeclarationExpression syntax)
        {
            _underlyingVisitor.VisitOutVarDeclarationExpression(syntax);
        }

        public override void VisitParameterDeclaration(ParameterDeclaration syntax)
        {
            _underlyingVisitor.VisitParameterDeclaration(syntax);
        }

        public override void VisitParenthesizedExpression(ParenthesizedExpression syntax)
        {
            _underlyingVisitor.VisitParenthesizedExpression(syntax);
        }

        public override void VisitParenthesizedVariableDesignation(ParenthesizedVariableDesignation syntax)
        {
            _underlyingVisitor.VisitParenthesizedVariableDesignation(syntax);
        }

        public override void VisitPatternPlaceholder(AstNode syntax, Pattern pattern)
        {
            _underlyingVisitor.VisitPatternPlaceholder(syntax, pattern);
        }

        public override void VisitPointerReferenceExpression(PointerReferenceExpression syntax)
        {
            _underlyingVisitor.VisitPointerReferenceExpression(syntax);
        }

        public override void VisitPreProcessorDirective(PreProcessorDirective syntax)
        {
            _underlyingVisitor.VisitPreProcessorDirective(syntax);
        }

        public override void VisitPrimitiveExpression(PrimitiveExpression syntax)
        {
            _underlyingVisitor.VisitPrimitiveExpression(syntax);
        }

        public override void VisitPrimitiveType(PrimitiveType syntax)
        {
            _underlyingVisitor.VisitPrimitiveType(syntax);
        }

        public override void VisitPropertyDeclaration(PropertyDeclaration syntax)
        {
            _underlyingVisitor.VisitPropertyDeclaration(syntax);
        }

        public override void VisitQueryContinuationClause(QueryContinuationClause syntax)
        {
            _underlyingVisitor.VisitQueryContinuationClause(syntax);
        }

        public override void VisitQueryExpression(QueryExpression syntax)
        {
            _underlyingVisitor.VisitQueryExpression(syntax);
        }

        public override void VisitQueryFromClause(QueryFromClause syntax)
        {
            _underlyingVisitor.VisitQueryFromClause(syntax);
        }

        public override void VisitQueryGroupClause(QueryGroupClause syntax)
        {
            _underlyingVisitor.VisitQueryGroupClause(syntax);
        }

        public override void VisitQueryJoinClause(QueryJoinClause syntax)
        {
            _underlyingVisitor.VisitQueryJoinClause(syntax);
        }

        public override void VisitQueryLetClause(QueryLetClause syntax)
        {
            _underlyingVisitor.VisitQueryLetClause(syntax);
        }

        public override void VisitQueryOrderClause(QueryOrderClause syntax)
        {
            _underlyingVisitor.VisitQueryOrderClause(syntax);
        }

        public override void VisitQueryOrdering(QueryOrdering syntax)
        {
            _underlyingVisitor.VisitQueryOrdering(syntax);
        }

        public override void VisitQuerySelectClause(QuerySelectClause syntax)
        {
            _underlyingVisitor.VisitQuerySelectClause(syntax);
        }

        public override void VisitQueryWhereClause(QueryWhereClause syntax)
        {
            _underlyingVisitor.VisitQueryWhereClause(syntax);
        }

        public override void VisitReturnStatement(ReturnStatement syntax)
        {
            _underlyingVisitor.VisitReturnStatement(syntax);
        }

        public override void VisitSimpleType(SimpleType syntax)
        {
            _underlyingVisitor.VisitSimpleType(syntax);
        }

        public override void VisitSingleVariableDesignation(SingleVariableDesignation syntax)
        {
            _underlyingVisitor.VisitSingleVariableDesignation(syntax);
        }

        public override void VisitSizeOfExpression(SizeOfExpression syntax)
        {
            _underlyingVisitor.VisitSizeOfExpression(syntax);
        }

        public override void VisitStackAllocExpression(StackAllocExpression syntax)
        {
            _underlyingVisitor.VisitStackAllocExpression(syntax);
        }

        public override void VisitSwitchExpression(SwitchExpression syntax)
        {
            _underlyingVisitor.VisitSwitchExpression(syntax);
        }

        public override void VisitSwitchExpressionSection(SwitchExpressionSection syntax)
        {
            _underlyingVisitor.VisitSwitchExpressionSection(syntax);
        }

        public override void VisitSwitchSection(SwitchSection syntax)
        {
            _underlyingVisitor.VisitSwitchSection(syntax);
        }

        public override void VisitSwitchStatement(SwitchStatement syntax)
        {
            _underlyingVisitor.VisitSwitchStatement(syntax);
        }

        public override void VisitSyntaxTree(SyntaxTree syntax)
        {
            _underlyingVisitor.VisitSyntaxTree(syntax);
        }

        public override void VisitThisReferenceExpression(ThisReferenceExpression syntax)
        {
            _underlyingVisitor.VisitThisReferenceExpression(syntax);
        }

        public override void VisitThrowExpression(ThrowExpression syntax)
        {
            _underlyingVisitor.VisitThrowExpression(syntax);
        }

        public override void VisitThrowStatement(ThrowStatement syntax)
        {
            _underlyingVisitor.VisitThrowStatement(syntax);
        }

        public override void VisitTryCatchStatement(TryCatchStatement syntax)
        {
            _underlyingVisitor.VisitTryCatchStatement(syntax);
        }

        public override void VisitTupleExpression(TupleExpression syntax)
        {
            _underlyingVisitor.VisitTupleExpression(syntax);
        }

        public override void VisitTupleType(TupleAstType syntax)
        {
            _underlyingVisitor.VisitTupleType(syntax);
        }

        public override void VisitTupleTypeElement(TupleTypeElement syntax)
        {
            _underlyingVisitor.VisitTupleTypeElement(syntax);
        }

        public override void VisitTypeDeclaration(TypeDeclaration syntax)
        {
            _underlyingVisitor.VisitTypeDeclaration(syntax);
        }

        public override void VisitTypeOfExpression(TypeOfExpression syntax)
        {
            _underlyingVisitor.VisitTypeOfExpression(syntax);
        }

        public override void VisitTypeParameterDeclaration(TypeParameterDeclaration syntax)
        {
            _underlyingVisitor.VisitTypeParameterDeclaration(syntax);
        }

        public override void VisitTypeReferenceExpression(TypeReferenceExpression syntax)
        {
            _underlyingVisitor.VisitTypeReferenceExpression(syntax);
        }

        public override void VisitUnaryOperatorExpression(UnaryOperatorExpression syntax)
        {
            _underlyingVisitor.VisitUnaryOperatorExpression(syntax);
        }

        public override void VisitUncheckedExpression(UncheckedExpression syntax)
        {
            _underlyingVisitor.VisitUncheckedExpression(syntax);
        }

        public override void VisitUncheckedStatement(UncheckedStatement syntax)
        {
            _underlyingVisitor.VisitUncheckedStatement(syntax);
        }

        public override void VisitUndocumentedExpression(UndocumentedExpression syntax)
        {
            _underlyingVisitor.VisitUndocumentedExpression(syntax);
        }

        public override void VisitUnsafeStatement(UnsafeStatement syntax)
        {
            _underlyingVisitor.VisitUnsafeStatement(syntax);
        }

        public override void VisitUsingAliasDeclaration(UsingAliasDeclaration syntax)
        {
            _underlyingVisitor.VisitUsingAliasDeclaration(syntax);
        }

        public override void VisitUsingDeclaration(UsingDeclaration syntax)
        {
            _underlyingVisitor.VisitUsingDeclaration(syntax);
        }

        public override void VisitUsingStatement(UsingStatement syntax)
        {
            _underlyingVisitor.VisitUsingStatement(syntax);
        }

        public override void VisitVariableDeclarationStatement(VariableDeclarationStatement syntax)
        {
            _underlyingVisitor.VisitVariableDeclarationStatement(syntax);
        }

        public override void VisitVariableInitializer(VariableInitializer syntax)
        {
            _underlyingVisitor.VisitVariableInitializer(syntax);
        }

        public override void VisitWhileStatement(WhileStatement syntax)
        {
            _underlyingVisitor.VisitWhileStatement(syntax);
        }

        public override void VisitYieldBreakStatement(YieldBreakStatement syntax)
        {
            _underlyingVisitor.VisitYieldBreakStatement(syntax);
        }

        public override void VisitYieldReturnStatement(YieldReturnStatement syntax)
        {
            _underlyingVisitor.VisitYieldReturnStatement(syntax);
        }
    }
}
