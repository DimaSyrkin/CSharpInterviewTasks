// Write a routine that prints out a 2-D array in spiral order.
using System;

namespace ArrayPrintSpirally
{
	public class Array2D
	{
		private readonly int[,] _values;

		private readonly int _right;
		private readonly int _bottom;

		// Created for testing purpose
		private int _printIndex = 0;
		internal int[] PrintedValues;

		public Array2D(ref int[,] values, int right, int bottom)
		{
			_values = values;
			_right = right - 1;
			_bottom = bottom - 1;
		}

		public void PrintSpirally()
		{
			if ((_values == null) || (_values.Length == 0))
			{
				throw new ArgumentException("Array is null or empty.");
			}

			if ((_right < 0) || (_bottom < 0) || ((_right + 1) * (_bottom + 1) > _values.Length))
			{
				throw new ArgumentException("Array boundaries are invalid.");
			}

			if ((_right == 0) || (_bottom == 0))
			{
				throw new ArgumentException("Array is not two-dimensional.");
			}

			PrintedValues = new int[(_right + 1) * (_bottom + 1)];
			PrintPrintSpirallyCore(0, _right, 0, _bottom);
			//PrintSpirallyCoreRecursive(0, _right, 0, _bottom);
		}

		private void PrintPrintSpirallyCore(int left, int right, int top, int bottom)
		{
			while (left <= right && top <= bottom)
			{
				for (int i = left; i <= right; i++)
				{
					// Console.Write("{0} ", _values[top, i]);
					PrintedValues[_printIndex++] = _values[top, i];
				}
				top++;

				for (int i = top; i <= bottom; i++)
				{
					// Console.Write("{0} ", _values[i, right]);
					PrintedValues[_printIndex++] = _values[i, right];
				}
				right--;

				for (int i = right; i >= left; i--)
				{
					// Console.Write("{0} ", _values[bottom, i]);
					PrintedValues[_printIndex++] = _values[bottom, i];
				}
				bottom--;
				  

				for (int i = bottom; i >= top; i--)
				{
					// Console.Write("{0} ", _values[i, left]);
					PrintedValues[_printIndex++] = _values[i, left];
				}
				left++;				
			}

			// Console.WriteLine();
		}

		private void PrintSpirallyCoreRecursive(int left, int right, int top, int bottom)
		{			
			if ((left > right) || (top > bottom))
			{
				// Console.WriteLine();
				return;
			}			

			for (int i = left; i <= right; i++)
			{
				// Console.Write("{0} ", _values[top, i]);
				PrintedValues[_printIndex++] = _values[top, i];
			}

			for (int i = top + 1; i <= bottom; i++)
			{
				// Console.Write("{0} ", _values[i, right]);
				PrintedValues[_printIndex++] = _values[i, right];
			}

			for (int i = right - 1; i >= left; i--)
			{
				// Console.Write("{0} ", _values[bottom, i]);
				PrintedValues[_printIndex++] = _values[bottom, i];
			}

			for (int i = bottom - 1; i > top; i--)
			{
				// Console.Write("{0} ", _values[i, left]);
				PrintedValues[_printIndex++] = _values[i, left];
			}		

			PrintSpirallyCoreRecursive(left + 1, right - 1, top + 1, bottom - 1);
		}
	}
}
