using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibonacciNumbers
{
	public class Fibonacci
	{
		private const int MAX_FIBONACCI_INDEX_IN_UINT = 47;
		private static bool _isTestMode;

		internal static uint[] Numbers;

		public static void SetTestMode(bool value)
		{
			_isTestMode = value;
		}

		public static void Print(uint number)
		{
			if (number > MAX_FIBONACCI_INDEX_IN_UINT)
			{
				throw new InvalidOperationException("Sequence exceeds the allocated memory");
			}

			if (_isTestMode)
			{
				Numbers = new uint[number+1];
			}

			var mean = (1 + Math.Sqrt(5)) / 2;

			for (int i = 0; i <= number; i++)
			{
				var result = (uint)((Math.Pow(mean, i) - Math.Pow(-1 / mean, i)) / Math.Sqrt(5));
				if (!_isTestMode)
				{
					Console.WriteLine(result);
				}
				else
				{
					Numbers[i] = result;
				}
			}			
		}
	}
}
