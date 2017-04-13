using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListFindFromEnd
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList list = new LinkedList();
			list.Add(10);			
			list.Add(20);
			list.Add(30);
			list.Add(40);
			list.Add(50);
			list.Add(60);

			int number = list.FindFromEnd(6);
			Console.WriteLine(number);
		}
	}
}
