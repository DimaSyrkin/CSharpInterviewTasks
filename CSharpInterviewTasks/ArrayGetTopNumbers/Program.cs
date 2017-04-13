using System;
using System.Runtime.CompilerServices;

namespace ArrayGetTopNumbers
{
	class Program
	{
		public static void Main(string[] args)
		{
			int[] inputNumbers = {33, 2, 110, 21, 21};		

			Array array = new Array(ref inputNumbers);

			int[] topNumbers = array.GetTop(3);

			for (int i = 0; i < topNumbers.Length; i++)
			{
				Console.WriteLine(topNumbers[i]);
			}
		}
	}
}
