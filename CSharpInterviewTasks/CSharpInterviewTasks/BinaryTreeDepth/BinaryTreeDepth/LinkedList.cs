using System;

namespace BinaryTreeDepth
{
	public class LinkedList
	{
		public class Node
		{
			public int Value { get; set; }
			public Node Next { get; set; }
		}

		private Node _tail;

		public int Size { get; private set; }
		public Node Head { get; private set; }

		public LinkedList()
		{
			Size = 0;
			Head = null;
			_tail = null;
		}

		public void Add(int value)
		{
			Node node = new Node() { Value = value };

			Size++;

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
		}

		public int Pop()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}

			Node head = Head;
			Head = Head.Next;
			Size--;
			return head.Value;
		}

		public void Reset()
		{
			Size = 0;
			Head = null;
			_tail = null;
		}
	}
}
