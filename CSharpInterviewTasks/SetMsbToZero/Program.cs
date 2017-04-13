using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SetMsbToZero
{
	class Program
	{
		static void Main(string[] args)
		{
			UnsignedInt number = new UnsignedInt(2147483648 - 1);
			Console.WriteLine(number.SetMsbToZero());
		}
	}
}
