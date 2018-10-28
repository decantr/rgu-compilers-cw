/**
 * @Author: John Isaacs <john>
 * @Date:   10-Oct-172017
 * @Filename: Parser - Common.cs
 * @Last modified by:   john
 * @Last modified time: 19-Oct-172017
 */

using System.Collections.Generic;

namespace Triangle.Compiler.SyntacticAnalyzer {
	public partial class Parser {
		Scanner scanner;

		IEnumerator<Token> tokens;

		public Parser( Scanner scanner ) {
			this.scanner = scanner;
			//errorReporter = errorReporter;
			//previousLocation = Location.Empty;
			tokens = this.scanner.GetEnumerator();
		}

		/// Checks that the kind of the current token matches the expected kind, and
		/// fetches the next token from the source file, if not it throws a
		void Accept(TokenKind expectedKind) {
			if ( tokens.Current.Kind == expectedKind ) {
				Token token = tokens.Current;
				//previousLocation = token.Start;
				tokens.MoveNext();
			}
		}

		// Just Fetches the next token from the source file.
		void AcceptIt() {
			//previousLocation = tokens.Current.Finish;
			tokens.MoveNext();
		}
	}
}
