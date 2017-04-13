using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySortScratch
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] inputNumbers = new[] {5, 2, 1, 4, 1, 4, 3};
			Array array = new Array(ref inputNumbers);
			array.Sort(250);
		}
	}
}
