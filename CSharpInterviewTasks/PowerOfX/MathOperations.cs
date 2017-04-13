using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PowerOfX
{
	public static class MathOperations
	{
		public static int Power(int x, uint y)
		{
			if (x == 0 || x == 1)
			{
				return x; 
			}

			if (x == -1)
			{
				return y % 2 == 0 ? 1 : -1;
			}

			if (y == 0)
			{
				return 1;
			}

			int power = Power(x, y/2);
			return y%2 == 0 
				? power*power 
				: power*power*x;
		}
		
		public static double Power(double x, int y)
		{
			if (x == 0 || x == 1)
			{
				return x;
			}

			if (x == -1)
			{
				return y % 2 == 0 ? 1 : -1;
			}

			if (y == 0)
			{
				return 1;
			}

			double power = Power(x, y/2);
			if (y%2 == 0)
			{
				return power*power;
			}
			if (y > 0)
			{
				return power * power * x;
			}

			return (power*power)/x;
		}

		public static uint PowerBin(uint x, uint y)
		{
			uint result = (uint)(y*Log2(x));
			return result;
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
