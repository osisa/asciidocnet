﻿using com.github.javaparser.ast.stmt;
using JavaToCSharp.Expressions;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JavaToCSharp.Statements
{
    public class ReturnStatementVisitor : StatementVisitor<ReturnStmt>
    {
        public override StatementSyntax Visit(ConversionContext context, ReturnStmt returnStmt)
        {
            var expr = returnStmt.getExpr();

            if (expr == null)
                return SyntaxFactory.ReturnStatement(); // i.e. "return" in a void method

            var exprSyntax = ExpressionVisitor.VisitExpression(context, expr);

            return SyntaxFactory.ReturnStatement(exprSyntax);
        }
    }
}
