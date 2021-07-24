﻿using com.github.javaparser.ast.expr;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JavaToCSharp.Expressions
{
    public class ConditionalExpressionVisitor : ExpressionVisitor<ConditionalExpr>
    {
        public override ExpressionSyntax Visit(ConversionContext context, ConditionalExpr conditionalExpr)
        {
            var condition = conditionalExpr.getCondition();
            var conditionSyntax = VisitExpression(context, condition);

            var thenExpr = conditionalExpr.getThenExpr();
            var thenSyntax = VisitExpression(context, thenExpr);

            var elseExpr = conditionalExpr.getElseExpr();
            var elseSyntax = VisitExpression(context, elseExpr);

            return SyntaxFactory.ConditionalExpression(conditionSyntax, thenSyntax, elseSyntax);
        }
    }
}
