using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayFindMostFrequentElement
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[] numbers = {2, 1, 2, 2, 4, 2, 3, 2, 0, 0, 2, 2, 0};
			int[] numbers = { 2, 1, 5, 6, 1 };
			Console.WriteLine(numbers.Length);
			MyArray array = new MyArray(ref numbers);
			Console.WriteLine(array.FindElementOccurredMoreThanHalf());			
		}
	}
}
