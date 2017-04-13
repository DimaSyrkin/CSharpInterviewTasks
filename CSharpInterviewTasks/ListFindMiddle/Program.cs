using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListFindMiddle
{
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList list = new LinkedList();
			list.Add(10);
			/*
			list.Add(20);
			list.Add(30);
			list.Add(40);
			list.Add(50);
			list.Add(60);
			 */
			list.LoopTo(10);
			Console.WriteLine(list.HasLoop());
		}
	}
}
