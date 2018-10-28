using System;

namespace Triangle.Compiler.SyntacticAnalyzer {
	/// <summary>
	/// A range of locations in a file
	/// </summary>
	public class SourcePosition {

		public Location Start { get; }

		public Location Finish { get; }

		/// <summary>
		/// Creates a new file range location
		/// </summary>
		/// <param name="startLocation">The starting location of the range</param>
		/// <param name="endLocation">The ending location of the range</param>
		public SourcePosition( Location startLocation, Location endLocation ) {
			Start = startLocation;
			Finish = endLocation;
		}

		public override string ToString() {
			return $"{Start} -- {Finish}";
		}
	}
}