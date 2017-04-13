using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeToList
{
	public class LinkedList
	{
		public class Node
		{
			public int Value { get; set; }
			public Node Previous { get; set; }
			public Node Next { get; set; }
		}

		private Node _tail;
		public Node Head { get; private set; }

		public int Size;

		public LinkedList()
		{
			Head = null;
			_tail = null;
			Size = 0;
		}

		public void Add(int value)
		{
			Node node = new Node() { Value = value };

			if (Head == null)
			{
				Head = _tail = node;								
			}
			else
			{
				_tail.Next = node;
				node.Previous = _tail;
				_tail = node;
			}
			Size++;
		}

		internal int[] ToArray()
		{
			int[] values = new int[Size];
			int counter = 0;
			Node current = Head;

			while (current != null)
			{
				values[counter++] = current.Value;
				current = current.Next;
			}

			return values;
		}

		internal int[] ToArrayReverse()
		{
			int[] values = new int[Size];
			int counter = 0;
			Node current = _tail;

			while (current != null)
			{
				values[counter++] = current.Value;
				current = current.Previous;
			}

			return values;
		}
	}
}
