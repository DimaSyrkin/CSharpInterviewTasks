using System;

namespace MyLinkedList
{
	/// <summary>
	/// 47.	Linked list manipulation: AddLast, AddAtIndex, Delete elements. 
	/// 44.	Reverse a linked list. 
	/// </summary>
	public class Program
	{
		static void Main(string[] args)
		{
			/*
			int index = 2;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Delete(1);
			//LinkedList list = new LinkedList();


			list.Add(10);
			list.Add(20);

			// act
			list.Add(30, 2);

			list.Add(2);			
			list.Add(5);
			list.Add(10);
			list.Add(25);
			list.Add(15, 0);
			list.Add(30, 3);
			list.Add(50, 6);
			list.Delete(6);
			list.Delete(0);
			list.Add(100);
			list.Reverse();

			var values = list.GetAllValues();
			var first = list.GetValue(0);
			var last = list.GetValue(list.Size - 1);
			 */
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);
			list.Add(5);
			list.Add(25);
			list.Add(40);
			list.Sort();
			//list.InsertIntoSorted(55);
			//list.InsertIntoSorted(0);
			list.InsertIntoSorted(15);
			

			LinkedList list2 = new LinkedList();
			list2.Add(15);
			list2.Add(25);
			list2.Add(35);

			
		}
	}
}
