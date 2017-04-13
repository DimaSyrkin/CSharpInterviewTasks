using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GetNumberOfOnes
{
	class Program
	{
		static void Main(string[] args)
		{
			Number number = new Number(15);
			Console.WriteLine(number.GetNumberInSequenceWithSameNumberOfOnes());
		}
	}
}
