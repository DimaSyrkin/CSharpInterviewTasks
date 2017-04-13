using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListFindMiddle
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

		public LinkedList()
		{			
			Head = null;
			_tail = null;
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
		}

		public void LoopTo(int value)
		{
			Node current = Head;
			while (current != null && current.Value != value)
			{
				current = current.Next;
			}

			if (current != null && current != _tail)
			{
				_tail.Next = current;
				return;
			}

			if (current == _tail && current != null)
			{
				_tail.Next = _tail;
				return;
			}

			if (current == null)
			{
				Node node = new Node() {Value = value};
				_tail.Next = node;
				node.Next = _tail;
			}
		}

		public int GetMiddle()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}

			if (Head.Next == null)
			{
				throw new InvalidOperationException("List contains only one element");
			}

			Node slow = Head;
			Node fast = Head;

			while (fast != null && fast.Next != null)
			{
				fast = fast.Next.Next;
				slow = slow.Next;
			}
			return slow.Value;
		}

		public bool HasLoop()
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty");
			}

			if (Head.Next == null)
			{
				return false;
			}

			Node slow = Head;
			Node fast = Head;

			while (fast != null && fast.Next != null)
			{
				fast = fast.Next.Next;
				slow = slow.Next;

				if (fast == slow)
				{
					return true;
				}

				if (fast == null || fast.Next == null)
				{
					return false;
				}
			}
			return false;
		}
	}
}
