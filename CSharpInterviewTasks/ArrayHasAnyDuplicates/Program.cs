using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayUtilities
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] input = new[] {1, 3, 5};
			Array array = new Array(ref input);
			array.GetUniqueElements();
		}
	}
}
