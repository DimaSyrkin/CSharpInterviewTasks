using System;

namespace ArraySumTwosComplement
{
	public class Array
	{
		public uint[] InputElements;

		public Array(ref uint[] inputElements)
		{
			InputElements = inputElements;
		}

		public uint Sum()
		{
			if (InputElements == null || InputElements.Length == 0)
			{
				throw new InvalidOperationException("Input array is null or empty");
			}

			uint sum = 0;
			for (int i = 0; i < InputElements.Length; i++)
			{
				checked
				{
					sum += InputElements[i];
				}				
			}
			
			return sum;
		}
	}
}
