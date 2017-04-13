using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscreteLog
{
	public class UnsignedInt
	{
		private readonly uint _inputNumber;

		public UnsignedInt(uint inputNumber)
		{
			_inputNumber = inputNumber;
		}
		
		public enum DiscreteLogCalculation
		{
			Binary,
			Round
		}

		public int DiscreteLog(DiscreteLogCalculation discreteLogCalculation)
		{
			if (_inputNumber == 0)
			{
				throw new InvalidOperationException("Input number is zero");
			}

			return discreteLogCalculation == DiscreteLogCalculation.Binary
				? Log2(_inputNumber)
				: Log2Round(_inputNumber);
		}

		public static int Log2Round(uint number)
		{
			return (int) (Math.Log(number, 2) + 0.5);
		}

		public static int Log2(uint number)
		{
			uint[] masks = { 0x2, 0xC, 0xF0, 0xFF00, 0xFFFF0000 };
			int[] lens = { 1, 2, 4, 8, 16 };
			int result = 0;
			for (int i = masks.Length - 1; i >= 0; --i)
			{
				if ((number & masks[i]) > 0)
				{
					result += lens[i];
					number >>= lens[i];
				}
			}
			return result;
		}
	}
}
