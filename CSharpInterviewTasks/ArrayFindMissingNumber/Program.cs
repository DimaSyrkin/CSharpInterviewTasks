using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayFindMissingNumber
{
	class Program
	{
		public static void Main(string[] args)
		{
			int[] numbers = Array.Generate(1, 100, 1);
			int missing = Array.FindMissingNumber(numbers, Array.FindStrategy.Sum);
			int missing2 = Array.FindMissingNumber(numbers, Array.FindStrategy.Xor);
			Console.WriteLine(missing);
			Console.WriteLine(missing2);
		}
	}
}
