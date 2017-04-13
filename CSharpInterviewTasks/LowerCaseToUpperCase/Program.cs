using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace LowerCaseToUpperCase
{
	class Program
	{
		static void Main(string[] args)
		{
			MyString myString = new MyString(@"АяИдУПоГородУ");
			Console.WriteLine(myString.ToUpper());
		}
	}
}
