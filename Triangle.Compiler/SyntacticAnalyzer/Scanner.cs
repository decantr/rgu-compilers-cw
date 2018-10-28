using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace Triangle.Compiler.SyntacticAnalyzer {
	/// <summary>
	/// Scanner for the triangle language
	/// </summary>
	public class Scanner : IEnumerable<Token> {
		/// <summary>
		/// The file being read from
		/// </summary>
		private SourceFile source;

		/// <summary>
		/// The characters currently in the token being constructed
		/// </summary>
		private StringBuilder currentSpelling;

		/// <summary>
		/// Whether the reader has reached the end of the source file
		/// </summary>
		private bool atEndOfFile = false;

		/// <summary>
		/// Whether to perform debugging
		/// </summary>
		public bool Debug { get; set; }

		/// <summary>
		/// Lookup table of reserved words used to screen tokens
		/// </summary>
		private static ImmutableDictionary<string, TokenKind> ReservedWords { get; } =
				Enumerable.Range((int)TokenKind.Begin, (int)TokenKind.While)
				.Cast<TokenKind>()
				.ToImmutableDictionary(kind => kind.ToString().ToLower(), kind => kind);

		/// <summary>
		/// Creates a new scanner
		/// </summary>
		/// <param name="source">The file to read the characters from</param>
		public Scanner( SourceFile source ) {
			this.source = source;
			this.source.Reset();
			currentSpelling = new StringBuilder();
		}

		/// <summary>
		/// Returns the tokens in the source file
		/// </summary>
		/// <returns>The sequence of tokens that are found in the source code</returns>
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
			return GetEnumerator();
		}

		/// <summary>
		/// Returns the tokens in the source file
		/// </summary>
		/// <returns>The sequence of tokens that are found in the source code</returns>
		public IEnumerator<Token> GetEnumerator() {
			while ( !atEndOfFile ) {
				currentSpelling.Clear();
				ScanWhiteSpace();

				// Location startLocation = source.Location;
				TokenKind kind = ScanToken();
				// Location endLocation = source.Location;
				// SourcePosition position = new SourcePosition(startLocation, endLocation);

				Token token = new Token(kind, currentSpelling.ToString());

				if (kind == TokenKind.EndOfText)
					atEndOfFile = true;

				if (Debug)
					Console.WriteLine(token);

				yield return token;
			}
		}



		/// <summary>
		/// Skips over any whitespace
		/// </summary>
		private void ScanWhiteSpace() {
			while (source.Current == '!' || source.Current == ' ' || source.Current == '\t' || source.Current == '\n')
				ScanSeparator();
		}

		/// <summary>
		/// Skips a single separator
		/// </summary>
		private void ScanSeparator() {
			switch (source.Current) {
				case '!': source.SkipRestOfLine(); break;
				default: source.MoveNext(); break;
			}
		}

		/// <summary>
		/// Gets the next token in the file
		/// </summary>
		/// <returns>The type of the next token</returns>
		private TokenKind ScanToken() {
			if ( IsOperator( source.Current ) ) {
// operator
				TakeIt();
				return TokenKind.Operator;
			} else if ( char.IsLetter( source.Current ) ) {
// identifier
				while ( char.IsLetter( source.Current ) ||
					char.IsDigit( source.Current ) || source.Current == '_' )
					TakeIt();

				if ( ReservedWords.TryGetValue( currentSpelling.ToString(), out TokenKind reservedWordType ) )
					return reservedWordType;

				return TokenKind.Identifier;
			} else if (char.IsDigit(source.Current)) {
// integer
				TakeIt();
				while ( char.IsDigit(source.Current )) TakeIt();
				return TokenKind.IntLiteral;
			}

			switch ( source.Current ) {
				case '\'':
// char literal
					TakeIt();

					// attempt to find a 'graphic'
					if ( char.IsLetter( source.Current ) ||
								char.IsDigit( source.Current ) ||
								IsOperator( source.Current ) ||
								source.Current == '.' ||
								source.Current == '!' ||
								source.Current == '?' ||
								source.Current == '_' ||
								source.Current == ' ' ) TakeIt();
					else return TokenKind.Error;
					if ( source.Current == '\'' ) TakeIt();
					else return TokenKind.Error;

					return TokenKind.CharLiteral;
				case '(':
// left bracket
					TakeIt();
					return TokenKind.LeftBracket;
				case ')':
// right bracket
					TakeIt();
					return TokenKind.RightBracket;
				case ':':
// becomes || colon
					TakeIt();
					if ( source.Current == '=' ) {
						TakeIt();
						return TokenKind.Becomes;
					}
					return TokenKind.Colon;
				case ';':
// semicolon
					TakeIt();
					return TokenKind.Semicolon;
				case '~':
// is
					TakeIt();
					return TokenKind.Is;
				case ',':
// comma
					TakeIt();
					return TokenKind.Comma;
				case default( char ):
					// We have reached the end of the file
					return TokenKind.EndOfText;
				default:
					// We encountered something we weren't expecting
					TakeIt();
					return TokenKind.Error;
			}
		}

		/// <summary>
		/// Appends the current character to the current token, and gets the next character from the source program
		/// </summary>
		private void TakeIt() {
			currentSpelling.Append( source.Current );
			source.MoveNext();
		}



		/// <summary>
		/// Checks whether a character is an operator
		/// </summary>
		/// <param name="c">The character to check</param>
		/// <returns>True if and only if the character is an operator in the language</returns>
		private static bool IsOperator(char c) {
			switch ( c ) {
				case '+':
				case '-':
				case '*':
				case '/':
				case '=':
				case '<':
				case '>':
				case '\\':
					return true;
				default:
					return false;
			}
		}
	}
}