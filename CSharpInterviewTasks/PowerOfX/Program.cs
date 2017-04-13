using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PowerOfX
{
	class Program
	{
		static void Main(string[] args)
		{
			checked
			{
				uint x = 25;
				uint y = 2;
				Console.WriteLine(MathOperations.PowerBin(x, y));
			}
		}
	}
}
