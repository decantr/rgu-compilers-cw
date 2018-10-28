/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {

		void ParseActualParamater() {
			System.Console.WriteLine( "parsing paramater" );
			ParsePartialParamater();
			while ( tokens.Current.Kind == TokenKind.Comma ) {
				AcceptIt();
				ParsePartialParamater();
			}
		}

		void ParsePartialParamater() {
			switch ( tokens.Current.Kind ) {
				case TokenKind.Var:
					AcceptIt();
					ParseIdentifier();
					break;
				default:
					ParseExpression();
					break;
			}
		}
	}
}
