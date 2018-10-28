namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {
		////////////////////////////////////////////////////////////////////////////
		//
		// PROGRAMS
		//
		////////////////////////////////////////////////////////////////////////////

		public void ParseProgram() {
			System.Console.WriteLine( "parsing Program" );
			tokens.MoveNext();
			//var startLocation = _tokens.Current.Start;
			ParseCommand();
		}
	}
}
