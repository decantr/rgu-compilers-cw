/* @Author: Shaw Eastwood <1504614@rgu.ac.uk>
 * @Date:   10-Oct-172017
 */

namespace Triangle.Compiler.SyntacticAnalyzer {
    /// <summary>
    /// A location in a file
    /// </summary>
    public class Location {
		public int Line { get; }

		public int Column { get; }

		public Location( int line, int column ) {
			Line = line;
			Column = column;
		}

		public override string ToString() {
			return $"Line {Line}, Column {Column}";
		}
    }
}