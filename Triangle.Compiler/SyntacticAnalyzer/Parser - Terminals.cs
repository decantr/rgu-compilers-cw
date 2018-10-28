/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {

		// parses an identifier, and constructs a leaf AST to represent it.
		void ParseIdentifier() {
			System.Console.WriteLine( "parsing identifier" );
			Accept(TokenKind.Identifier);
		}

		void ParseOperator() {
			System.Console.WriteLine( "parsing operator" );
			Accept( TokenKind.Operator );
		}

		void ParseIntLiteral() {
			System.Console.WriteLine( "parsing integer literal" );
			Accept( TokenKind.IntLiteral );
		}

		void ParseCharLiteral() {
			System.Console.WriteLine( "parsing character literal" );
			Accept( TokenKind.CharLiteral );
		}
	}
}
