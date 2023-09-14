using sudoku_solver.Tools;
using System;

namespace sudoku_solver
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Sudoku solver made by FinnArth");
            Console.WriteLine("Instruction: insert sudoku lines with 'x' instead of an empty cell");
			Console.WriteLine("Your Sudoku:");

			Solver.Input();
			var solution = string .Join("\n", Solver.Solve());

			Console.WriteLine();
			Console.WriteLine("Solution:");
			Console.Write(solution);
			Console.WriteLine();
			Console.WriteLine();
        }
	}
}