using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanString
{
	class Program
	{
		static void Main(string[] args)
		{
			MyString str = new MyString("z");
			str.Clean("nbahjkl");
			Console.WriteLine(str.Print());
		}
	}
}
