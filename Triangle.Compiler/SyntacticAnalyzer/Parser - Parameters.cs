using Triangle.Compiler.SyntaxTrees.Parameters;
using Triangle.Compiler.SyntaxTrees.Expressions;
using Triangle.Compiler.SyntaxTrees.Terminals;

namespace Triangle.Compiler.SyntacticAnalyzer
{
	public partial class Parser
	{

		///////////////////////////////////////////////////////////////////////////////
		//
		// PARAMETERS
		//
		///////////////////////////////////////////////////////////////////////////////

		ParameterSequence ParseParameters()
		{
			Compiler.WriteDebuggingInfo("Parsing Parameters");
			Location startLocation = tokens.Current.Position.Start;
			if (tokens.Current.Kind == TokenKind.RightBracket)
			{
				SourcePosition parameterPosition = new SourcePosition(startLocation, tokens.Current.Position.Finish);
				return new EmptyParameterSequence(parameterPosition);
			}

			Parameter p = ParseParameter();

			if (tokens.Current.Kind == TokenKind.Comma)
			{
				AcceptIt();
				ParameterSequence p2 = ParseParameters();
				SourcePosition parameterPosition = new SourcePosition(startLocation, tokens.Current.Position.Finish);
				return new MultipleParameterSequence(p, p2, parameterPosition);
			}
			else
			{
				SourcePosition parameterPosition = new SourcePosition(startLocation, tokens.Current.Position.Finish);
				return new SingleParameterSequence(p, parameterPosition);
			}

		}

		Parameter ParseParameter()
		{
			Compiler.WriteDebuggingInfo("Parsing Parameter");
			Location startLocation = tokens.Current.Position.Start;
			switch (tokens.Current.Kind)
			{
				case TokenKind.Identifier:
				case TokenKind.IntLiteral:
				case TokenKind.CharLiteral:
				case TokenKind.Operator:
				case TokenKind.LeftBracket:
					{
						Compiler.WriteDebuggingInfo("Parsing Value Parameter");
						Expression expression = ParseExpression();
						SourcePosition parameterPosition = new SourcePosition(startLocation, tokens.Current.Position.Finish);
						return new ValueParameter(expression, parameterPosition);
					}

				case TokenKind.Var:
					{
						Compiler.WriteDebuggingInfo("Parsing Variable Parameter");
						AcceptIt();
						Identifier identifier = ParseIdentifier();
						SourcePosition parameterPosition = new SourcePosition(startLocation, tokens.Current.Position.Finish);
						return new VarParameter(identifier, parameterPosition);
					}

				default:
					{
						RaiseSyntacticError("\"%\" cannot start a parameter", tokens.Current);
						return null;
					}
			}

		}
	}
}