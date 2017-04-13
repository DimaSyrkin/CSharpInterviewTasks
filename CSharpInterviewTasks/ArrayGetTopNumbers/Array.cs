using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayGetTopNumbers
{
	public class Array
	{
		private readonly int[] _elements;

		public Array(ref int[] elements)
		{
			_elements = elements;			
		}

		public int[] GetTop(int count)
		{
			if (_elements == null || _elements.Length == 0)
			{
				throw new InvalidOperationException("INput array is null or empty");
			}

			if (count <= 0 || count > _elements.Length)
			{
				throw new ArgumentOutOfRangeException("count", "Count is greater than array size or invalid");
			}

			if (count == _elements.Length)
			{
				return _elements;
			}

			int[] result = new int[count];
			PopulateWitnMinValue(result);

			for (int i = 0; i < _elements.Length; i++)
			{
				if (i < result.Length)
				{
					InsertToSorted(ref result, _elements[i]);
				}
				else
				{
					InsertIfGreater(ref result, _elements[i]);
				}
			}

			return result;
		}

		private static void PopulateWitnMinValue(int[] array)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Int32.MinValue;
			}
		}

		private void InsertToSorted(ref int[] array, int value)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == Int32.MinValue)
				{
					array[i] = value;
					return;
				}

				if (value > array[i])
				{
					Swap(ref array[i], ref value);
				}
			}
		}

		private void InsertIfGreater(ref int[] array, int value)
		{
			if (value <= array[array.Length - 1])
			{
				return;
			}

			array[array.Length - 1] = value;

			for (int i = array.Length - 2; i >= 0; i--)
			{
				if (array[i] >= array[i + 1])
				{
					return;
				}

				Swap(ref array[i], ref array[i + 1]);
			}
		}

		private void Swap(ref int first, ref int second)
		{
			int temp = first;
			first = second;
			second = temp;
		}
	}
}
