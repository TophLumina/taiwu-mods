using System.Collections.Generic;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Debugging;
using MoonSharp.Interpreter.Execution;
using MoonSharp.Interpreter.Tree;
using MoonSharp.Interpreter.Tree.Expressions;
using MoonSharp.Interpreter.Tree.Statements;

public static class LuaParser
{
	public static DynValue Parse(string luaSourceString, Script script = null)
	{
		if (string.IsNullOrEmpty(luaSourceString))
		{
			return DynValue.Nil;
		}
		SourceCode source = new SourceCode("luaSourceString", luaSourceString, 0, script);
		ScriptLoadingContext ctx = new ScriptLoadingContext(script)
		{
			Scope = new BuildTimeScope(),
			Source = source,
			Lexer = new Lexer(source.SourceID, source.Code, autoSkipComments: true)
		};
		return MakeStatementValue(script, new ChunkStatement(ctx));
	}

	private static DynValue MakeStatementValue(Script script, Statement statement)
	{
		if (!(statement is CompositeStatement compositeStatement))
		{
			if (!(statement is ReturnStatement returnStatement))
			{
				if (statement is ChunkStatement chunkStatement)
				{
					return MakeStatementValue(script, chunkStatement.InnerStatement);
				}
				return DynValue.Nil;
			}
			return MakeExpressionValue(script, returnStatement.ReturnValueExpression);
		}
		return MakeStatementValue(script, compositeStatement.Statements[0]);
	}

	private static DynValue MakeExpressionValue(Script script, Expression expression)
	{
		if (!(expression is ExprListExpression exprListExpression))
		{
			if (!(expression is TableConstructor tableConstructor))
			{
				if (!(expression is UnaryOperatorExpression unaryOperatorExpression))
				{
					if (expression is LiteralExpression literalExpression)
					{
						return literalExpression.Value;
					}
					return DynValue.Nil;
				}
				DynValue value = MakeExpressionValue(script, unaryOperatorExpression.m_Exp);
				if (value.Type == DataType.Number && unaryOperatorExpression.m_OpText.Equals("-"))
				{
					value = DynValue.NewNumber(value.Number * -1.0);
				}
				return value;
			}
			Table table = new Table(script);
			foreach (KeyValuePair<Expression, Expression> pair in tableConstructor.Arguments)
			{
				table.Set(MakeExpressionValue(script, pair.Key), MakeExpressionValue(script, pair.Value));
			}
			foreach (Expression positional in tableConstructor.PositionalValues)
			{
				table.Set(table.Length + 1, MakeExpressionValue(script, positional));
			}
			return DynValue.NewTable(table);
		}
		return MakeExpressionValue(script, exprListExpression.GetExpressions()[0]);
	}
}
