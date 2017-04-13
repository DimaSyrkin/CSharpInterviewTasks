using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringIsPalindrome
{
	class Program
	{
		static void Main(string[] args)
		{
			MyString str = new MyString("          a b b              a");
			Console.WriteLine(str.IsPalindrome());
		}
	}
}
