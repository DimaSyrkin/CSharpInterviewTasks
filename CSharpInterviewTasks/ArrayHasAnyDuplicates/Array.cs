using System;

/*
 * 56. Write, efficient code for extracting unique elements from a sorted list of array. e.g. (1, 1, 3, 3, 3, 5,
5, 5, 9, 9, 9, 9) -> (1, 3, 5, 9). - GetUniqueElements
 * 58. Given an array of length N containing integers between 1 and N, determine if it contains any
duplicates. - HasDuplicates
 */

namespace ArrayUtilities
{
	public class Array
	{
		private readonly int[] _inputElements;

		public Array(ref int[] inputElements)
		{
			_inputElements = inputElements;			
		}

		public bool HasDuplicates()
		{
			if ((_inputElements == null) || (_inputElements.Length == 0))
			{
				throw new InvalidOperationException("Input array is null or emplty");
			}

			if (!IsValid())
			{
				throw new InvalidOperationException("Input array doesn't contain valid numbers");
			}

			if (!IsSorted())
			{
				throw new InvalidOperationException("Input array is not sorted");
			}

			if (_inputElements.Length == 1)
			{
				return false;
			}

			return HasDuplicatesCore();
		}

		public int[] GetUniqueElements()
		{
			if ((_inputElements == null) || (_inputElements.Length == 0))
			{
				throw new InvalidOperationException("Input array is null or emplty");
			}

			if (!IsSorted())
			{
				throw new InvalidOperationException("Input array is not sorted");
			}

			if (_inputElements.Length == 1)
			{
				return new []{_inputElements[0]};
			}
			return GetUniqueElementsCore();
		}

		private bool IsSorted()
		{
			for (int i = 1; i < _inputElements.Length; i++)
			{
				if (_inputElements[i] < _inputElements[i - 1])
				{
					return false;
				}
			}
			return true;
		}

		private bool IsValid()
		{
			for (int i = 0; i < _inputElements.Length; i++)
			{
				if ((_inputElements[i] < 1) || (_inputElements[i] > _inputElements.Length))
				{
					return false;
				}
			}
			return true;
		}

		private bool HasDuplicatesCore()
		{
			for (int i = 0; i < _inputElements.Length; i++)
			{
				int index = Abs(_inputElements[i]) - 1;

				if (_inputElements[index] > 0)
				{
					_inputElements[index] = -_inputElements[index];
				}
				else
				{
					return true;
				}
			}
			return false;
		}

		private int[] GetUniqueElementsCore()
		{
			int[] uniqueElements = _inputElements;
			int uniqueCounter = 0;

			for (int i = 1; i < _inputElements.Length; i++)
			{
				if (_inputElements[i] != _inputElements[uniqueCounter])
				{
					uniqueCounter++;
					_inputElements[uniqueCounter] = _inputElements[i];
				}
			}

			if ((_inputElements.Length - uniqueCounter) > 1)
			{
				System.Array.Resize(ref uniqueElements, uniqueCounter + 1);
			}

			return uniqueElements;
		}

		public static int Abs(int value)
		{
			return value < 0 ? -value : value;
		}
	}
}
