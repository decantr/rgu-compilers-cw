/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {

		/// Parses the command error
		void ParseCommand() {
			System.Console.WriteLine( "parsing command" );
			ParseSingleCommand();
			while ( tokens.Current.Kind == TokenKind.Semicolon ) {
				AcceptIt();
				ParseSingleCommand();
			}
		}

		/// Parses the single command
		void ParseSingleCommand() {
			System.Console.WriteLine( "parsing single command" );
			switch ( tokens.Current.Kind ) {
				case TokenKind.Identifier:
					ParseIdentifier();
					if ( tokens.Current.Kind == TokenKind.Becomes ) {
						AcceptIt();
						ParseExpression();
					} else if ( tokens.Current.Kind == TokenKind.LeftBracket ) {
						AcceptIt();
						ParseActualParamater();
					}
					break;
				case TokenKind.If:
					AcceptIt();
					ParseExpression();
					Accept( TokenKind.Then );
					ParseSingleCommand();
					Accept( TokenKind.Else );
					ParseSingleCommand();
					break;
				case TokenKind.While:
					AcceptIt();
					ParseExpression();
					Accept( TokenKind.Do );
					ParseSingleCommand();
					break;
				case TokenKind.Let :
					AcceptIt();
					ParseDeclaration();
					Accept( TokenKind.In );
					ParseSingleCommand();
					break;
				case TokenKind.Begin:
					AcceptIt();
					ParseCommand();
					AcceptIt();
					break;
				case TokenKind.Skip:
					// accept this differently as there is not a second statement
					AcceptIt();
					AcceptIt();
					break;
				default:
					reporter.ReportError( "command" , tokens.Current );
					break;
			}
		}
	}
}
