using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListFindFromEnd
{
	public class LinkedList
	{
		public class Node
		{
			public int Value { get; set; }
			public Node Next { get; set; }
		}

		private Node _tail;
		public Node Head { get; private set; }
		public int Count { get; private set; }

		public LinkedList()
		{
			Head = null;
			_tail = null;
			Count = 0;
		}

		public void Add(int value)
		{
			Node node = new Node() { Value = value };

			if (Head == null)
			{
				Head = node;
				_tail = node;
			}
			else
			{
				_tail.Next = node;
				_tail = _tail.Next;
			}
			Count++;
		}

		public int FindFromEnd(int position)
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}

			if (position > Count || position <= 0)
			{
				throw new ArgumentOutOfRangeException("position");
			}

			if (Count == position)
			{
				return Head.Value;
			}

			Node current = Head;
			Node result = Head;
			for (int i = 1; i < position; i++)
			{
				current = current.Next;
			}

			while (current.Next != null)
			{
				current = current.Next;
				result = result.Next;
			}

			return result.Value;
		}
	}
}
