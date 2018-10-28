namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {
		void ParseDeclaration() {
			System.Console.WriteLine( "parsing declaration" );
			ParseSingleDeclaration();
			while ( tokens.Current.Kind == TokenKind.Semicolon ) {
				AcceptIt();
				ParseSingleDeclaration();
			}
		}

		void ParseSingleDeclaration() {
			switch ( tokens.Current.Kind ) {
				case TokenKind.Const:
					AcceptIt();
					ParseIdentifier();
					Accept( TokenKind.Is );
					ParseExpression();
					break;
				case TokenKind.Var:
					AcceptIt();
					ParseIdentifier();
					Accept( TokenKind.Colon );
					ParseIdentifier();
					if ( tokens.Current.Kind == TokenKind.Becomes) {
						AcceptIt();
						ParseExpression();
					}
					break;
				default:
					System.Console.WriteLine( "error" );
					break;
			}
		}
	}
}
