using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedListDuplicates
{
	/// <summary>
	/// 63. Given a list of numbers (fixed list). Now given any other list, how can you efficiently find out if
	/// there is any element in the second list that is an element of the first list (fixed list).
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			LinkedList linkedList = new LinkedList();

			linkedList.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			//fixedList.Add(1);
			//fixedList.Add(5);
			//fixedList.Add(2);
			//fixedList.Add(10);

			linkedList.RemoveNodesFrom(fixedList);
		}
	}
}
