/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {

		void ParseVname() {
			System.Console.WriteLine( "parsing variable name" );
			ParseIdentifier();
		}
	}
}
