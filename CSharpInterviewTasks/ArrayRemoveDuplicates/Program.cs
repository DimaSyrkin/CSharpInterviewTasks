using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayRemoveDuplicates
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = new[] {1, 1, 2, 2, 3, 4, 4, 4, 4, 5};

			Array array = new Array(ref numbers);
			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ConsoleOutput);
		}
	}
}
