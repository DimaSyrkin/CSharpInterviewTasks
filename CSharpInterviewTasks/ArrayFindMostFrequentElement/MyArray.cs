using System;

namespace ArrayFindMostFrequentElement
{
	public class MyArray
	{
		private readonly int[] _elements;

		public MyArray(ref int[] elements)
		{
			_elements = elements;			
		}

		public int FindElementOccurredMoreThanHalf(int returnIfNotFound = -1)
		{
			if (_elements == null || _elements.Length == 0)
			{
				throw new InvalidOperationException("Input array is null or empty");
			}

			if (_elements.Length == 1)
			{
				return _elements[0];
			}

			int candidate = FindMostFrequentNumberCandidate();
			return IsOccurredMoreThanHalf(candidate) ? candidate : returnIfNotFound;
		}		

		public int FindMostFrequentNumberCandidate()
		{			
			int counter = 0;
			int mostFrequent = _elements[0];

			for (int i = 0; i < _elements.Length; i++)
			{
				if (counter == 0)
				{
					mostFrequent = _elements[i];
					counter++;
					continue;
				}

				if (_elements[i] == mostFrequent)
				{
					counter++;					
				}
				else
				{
					counter--;
				}

				if (counter > _elements.Length / 2)
				{
					return mostFrequent;
				}
			}

			return mostFrequent;
		}

		public bool IsOccurredMoreThanHalf(int value)
		{			
			int counter = 0;
			for (int i = 0; i < _elements.Length; i++)
			{
				if (_elements[i] == value)
				{
					counter++;
				}

				if (counter > _elements.Length/2)
				{
					return true;
				}

				if ((_elements.Length - i - 1 + counter) <= _elements.Length/2)
				{
					return false;
				}
			}
			return false;
		}
	}
}
