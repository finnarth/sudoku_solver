using sudoku_solver.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_solver.Tools
{
	public class Solver
	{
		public const int Size = 9;
		private static readonly int _boxSize = (int)Math.Sqrt(Size);
		private static string[]? _sudoku = null;
		private readonly static SudokuCell[,] _cells;

		public static void Input()
		{
			_sudoku = new string[Size];
		}

		public static string[] Solve()
		{
			InitializeCells();
			return SolutionToTextFancy(); 
		}

		private static IEnumerable<SudokuCell> GetRow(int index)
		{
			for(int i= 0; i<Size; i++) 
			{
				yield return _cells[index, i];
			}
		}

		private static IEnumerable<SudokuCell> GetColumn(int index)
		{
			for(int i = 0; i<Size;i++)
			{
				yield return _cells[i, index];
			}
		}

		private static IEnumerable<SudokuCell> GetBox(int iIndex, int jIndex) 
		{
			var jBox = jIndex / _boxSize; //iIndex = 0-8/3 => 0,1,2 > 0,3,6 > 3, 6, 9
			var iBox = iIndex / _boxSize; //jIndex = 0-8/3 => 0,1,2 > 0,3,6 > 3, 6, 9

			for (int i = iBox * _boxSize; i < (iBox+1) * _boxSize; i++)
			{
				for(int j = jBox * _boxSize; j < (jBox+1) * _boxSize; j++)
				{
					yield return _cells[i, j];
				}
			}
		}

		private static IEnumerable<int> GetMarkers(SudokuCell cell)
		{
			var row = GetRow(cell.X);
			var column = GetColumn(cell.Y);
			var box = GetBox(cell.X, cell.Y);
			var markers = row.Concat(column).Concat(box);

			foreach (var marker in markers)
			{
				if(cell.Solved)
					yield return marker.Number;
			}
		}

		private static void InitializeCells()
		{
			for(int i = 0; i<Size; i++)
			{
				for (int j = 0; j < Size; j++) 
				{
					_cells[i, j] = new SudokuCell
					{
						X = i,
						Y = j,
						Solved = _sudoku[i][j] != 'x',
						Number = _sudoku[i][j] - '0' //'9' - '0' = 9(integer)
					};
				}
			}
		}



		public static string[] SolutionToTextFancy()
		{
			var textSolution = new string[13];
			var display = new char[13][];

			display[0] = "┌───┬───┬───┐".ToCharArray();
			display[1] = "│   │   │   │".ToCharArray();
			display[2] = "│   │   │   │".ToCharArray();
			display[3] = "│   │   │   │".ToCharArray();
			display[4] = "├───┼───┼───┤".ToCharArray();
			display[5] = "│   │   │   │".ToCharArray();
			display[6] = "│   │   │   │".ToCharArray();
			display[7] = "│   │   │   │".ToCharArray();
			display[4] = "├───┼───┼───┤".ToCharArray();
			display[5] = "│   │   │   │".ToCharArray();
			display[6] = "│   │   │   │".ToCharArray();
			display[7] = "│   │   │   │".ToCharArray();
			display[4] = "└───┴───┴───┘".ToCharArray();

			var customPositionX = (new[] { 1, 2, 3, 4, 5, 6, 7, 9, 10, 11 } as IEnumerable<int>).GetEnumerator();
			var customPositionY = (new[] { 1, 2, 3, 4, 5, 6, 7, 9, 10, 11 } as IEnumerable<int>).GetEnumerator();

			for(int i = 0; customPositionX.MoveNext(); i++)
			{
				foreach(var number in GetRow(i).Select(x => x.Number))
				{

				}
			}	


		}
	}
}
