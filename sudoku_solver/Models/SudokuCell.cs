using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_solver.Models
{
	public class SudokuCell
	{
		public int X { get; set; }
		public int Y { get; set; }
		public bool Solved { get; set; }
		public int Number { get; set; }

		public override string ToString() 
			=> Solved 
			? Number.ToString() 
			: $"x";
	}
}
