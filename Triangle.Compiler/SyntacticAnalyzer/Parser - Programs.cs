/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {

		public void ParseProgram() {
			System.Console.WriteLine( "parsing Program" );
			tokens.MoveNext();
			//var startLocation = _tokens.Current.Start;
			ParseCommand();
		}
	}
}
