/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {

		void ParseExpression() {
			System.Console.WriteLine( "parsing expression" );
			ParseSecondaryExpression();
			while ( tokens.Current.Kind == TokenKind.Operator ) {
				ParseOperator();
				ParseExpression();
				ParseOperator();
				ParseExpression();
			}
		}

		void ParsePrimaryExpression() {
			switch ( tokens.Current.Kind ) {
				case TokenKind.IntLiteral:
					ParseIntLiteral();
					break;
				case TokenKind.CharLiteral:
					ParseCharLiteral();
					break;
				case TokenKind.Identifier:
					ParseIdentifier();
					if ( tokens.Current.Kind == TokenKind.RightBracket ) {
						AcceptIt();
						ParseActualParamater();
						Accept( TokenKind.RightBracket );
					}
					break;
				case TokenKind.Operator:
					ParseOperator();
					ParsePrimaryExpression();
					break;
				case TokenKind.LeftBracket:
					AcceptIt();
					ParseExpression();
					Accept( TokenKind.RightBracket );
					break;
				default:
					reporter.ReportError( "Expression" , tokens.Current );
					break;
			}
		}

		void ParseSecondaryExpression() {
			ParsePrimaryExpression();
			while ( tokens.Current.Kind == TokenKind.Operator ) {
				ParseOperator();
				ParsePrimaryExpression();
			}
		}
	}
}
