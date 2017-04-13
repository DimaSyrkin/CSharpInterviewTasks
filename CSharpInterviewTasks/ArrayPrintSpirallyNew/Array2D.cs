using System;

namespace ArrayPrintSpirallyNew
{	
	public class Array2D
	{		
		private readonly int[,] _values;

		private readonly int _right;
		private readonly int _bottom;
		public enum Directions { Right, Bottom, Left, Top };

		public Array2D(ref int[,] values, int right, int bottom)
		{
			_values = values;
			_right = right;
			_bottom = bottom;
		}

		public void PrintSpirally()
		{
			if ((_values == null) || (_values.Length == 0))
			{
				throw new ArgumentException("Array is null or empty.");
			}

			if ((_right < 0) || (_bottom < 0) || ((_right)*(_bottom) > _values.Length))
			{
				throw new ArgumentException("Array boundaries are invalid.");
			}

			if ((_right == 0) || (_bottom == 0))
			{
				throw new ArgumentException("Array is not two-dimensional.");
			}
			PrintSpirallyCore();
		}

		public void PrintSpirallyCore()
		{
			Directions currentDirection = Directions.Right;			
			int curRow = 0;
			int curCol = 0;
			for (int i = 0; i < _right * _bottom; i++)
			{
				Console.Write("{0} ", _values[curRow, curCol]);
				if (IsTurn(curRow, curCol))
				{					
					ChangeDirection(ref currentDirection);
				}

				if (currentDirection == Directions.Right)
				{
					curCol++;
				}

				if (currentDirection == Directions.Bottom)
				{
					curRow++;
				}

				if (currentDirection == Directions.Left)
				{
					curCol--;
				}

				if (currentDirection == Directions.Top)
				{
					curRow--;
				}
			}
			Console.WriteLine();

		}

		public bool IsTurn(int row, int col)
		{
			bool isLeftTop = true;
			if (row > _bottom - row - 1)
			{
				row = _bottom - row - 1;
				isLeftTop = false;
			}

			if (col >= _right - col - 1)
			{
				col = _right - col - 1;
				isLeftTop = false;
			}

			if (isLeftTop)
				row--;
			if (row == col)
				return true;
			return false;
		}

		public void ChangeDirection(ref Directions direction)
		{
			if (direction == Directions.Right)
			{
				direction = Directions.Bottom;
				return;
			}

			if (direction == Directions.Bottom)
			{
				direction = Directions.Left;
				return;
			}

			if (direction == Directions.Left)
			{
				direction = Directions.Top;
				return;
			}

			if (direction == Directions.Top)
			{
				direction = Directions.Right;				
			}			
		}		
	}
}
