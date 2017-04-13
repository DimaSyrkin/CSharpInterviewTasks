using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetNumberOfOnes
{
	public class Number
	{
		private readonly uint _number;

		public Number(uint number)
		{
			_number = number;
		}

		public int GetNumberInSequenceWithSameNumberOfOnes()
		{
			if (_number == 0)
			{
				throw new InvalidOperationException("Input number is zero");
			}

			if ((_number & (_number - 1)) == 0)
			{
				return Log2(_number) + 1;
			}

			if (((_number == UInt32.MaxValue) || (_number & (_number + 1)) == 0))
			{
				return 1;
			}

			uint numberOfOnes = GetNumberOfOnesInBinary(_number);
			int count = 1;
			for (uint i = _number-1; i > 0; i--)
			{
				if (GetNumberOfOnesInBinary(i) == numberOfOnes)
				{
					count++;
				}
			}

			return count;
		}

		public static uint GetNumberOfOnesInBinary(uint number)
		{
			uint[] masks = { 0x55555555, 0x33333333, 0x0F0F0F0F, 0x00FF00FF, 0x0000FFFF };
			int[] lens = { 1, 2, 4, 8, 16 };
			
			uint result = number;

			for (int i = 0; i < masks.Length; i++)
			{
				result = (result & masks[i]) + ((result >> lens[i]) & masks[i]);
			}

			return result;
		}

		public static int Log2(uint number)
		{
			uint[] masks = { 0x2, 0xC, 0xF0, 0xFF00, 0xFFFF0000 };
			int[] lens = { 1, 2, 4, 8, 16 };
			int value = 0;
			for (int i = masks.Length - 1; i >= 0; --i)
			{
				if ((number & masks[i]) > 0)
				{
					value += lens[i];
					number >>= lens[i];
				}
			}
			return value;
		} 
	}
}
