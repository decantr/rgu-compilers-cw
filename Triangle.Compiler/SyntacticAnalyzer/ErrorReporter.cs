using System;

namespace Triangle.Compiler.SyntacticAnalyzer {
	public class ErrorReporter {

		private bool hasErrored { get; set; }
		private int numErrors { get; set; }

		public ErrorReporter() {
			this.hasErrored = false;
			this.numErrors = 0;
		}

		public void ReportError( string message, Token token ) {
			this.hasErrored = true;
			this.numErrors++;

			System.Console.WriteLine(
				string.Format($"{token},\terror={this.numErrors},\tmessage=\"{message}\"")
				);
		}

		public bool HasErrors() {
			return this.hasErrored;
		}

		public int ErrorCount() {
			return this.numErrors;
		}
	}
}
