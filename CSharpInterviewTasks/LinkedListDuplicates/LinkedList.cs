using System;
using System.Collections.Generic;

namespace LinkedListDuplicates
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

		public LinkedList Add(int value)
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
			return this;
		}

		public void RemoveNodesFrom(LinkedList fixedList)
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is null or empty");
			}

			HashSet<int> uniqueValues = CreateHashSet(fixedList);

			// checking Head
			while (uniqueValues.Contains(Head.Value))
			{
				Head = Head.Next;
				Size--;

				if (Head == null)
				{
					_tail = Head;
					return;
				}
			}

			RemoveNodes(uniqueValues);
		}

		private void RemoveNodes(HashSet<int> uniqueValues)
		{
			Node previous = Head;
			Node current = Head.Next;

			while (current != null)
			{
				if (uniqueValues.Contains(current.Value))
				{
					previous.Next = current.Next;
					Size--;
				}
				else
				{
					previous = current;
				}

				current = current.Next;
				_tail = previous;
			}
		}

		public HashSet<int> CreateHashSet(LinkedList linkedList)
		{
			if (linkedList == null || linkedList.Head == null)
			{
				throw new ArgumentException("Unable to create hashset for list values. List is null or empty");
			}

			HashSet<int> hashSet = new HashSet<int>();

			Node current = linkedList.Head;
			while (current != null)
			{
				hashSet.Add(current.Value);
				current = current.Next;
			}

			return hashSet;
		}

		internal object[] GetAllValues()
		{
			object[] values = new object[Size];
			Node node = Head;

			for (int i = 0; i < Size; i++)
			{
				values[i] = node.Value;
				node = node.Next;
			}

			return values;
		}
	}
}
