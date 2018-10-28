/**
 * @Author: John Isaacs <john>
 * @Date:   10-Oct-172017
 * @Filename: Parser - Commands.cs
 * @Last modified by:   john
 * @Last modified time: 19-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {
		////////////////////////////////////////////////////////////////////////////
		//
		// COMMANDS
		//
		////////////////////////////////////////////////////////////////////////////

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
					ParseVname();
					AcceptIt();
					ParseExpression();
					if ( tokens.Current.Kind == TokenKind.RightBracket )
						AcceptIt();
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
					AcceptIt();
					break;
				default:
					System.Console.WriteLine( "error" );
					break;
			}
		}
	}
}
