using System;
using System.Collections.Generic;
using System.Xml;

namespace MyLinkedList
{
	public class LinkedList
	{
		/// <summary>
		/// Represents a Linked List node
		/// </summary>
		public class Node
		{
			/// <summary>
			/// Gets or sets the node value
			/// </summary>
			public int Value { get; set; }

			/// <summary>
			/// Gets or sets the next node
			/// </summary>
			public Node Next { get; set; }
		}

		private Node _tail;

		/// <summary>
		/// Gets the list size.
		/// </summary>
		public int Size { get; private set; }

		/// <summary>
		/// Gets the list head node.
		/// </summary>
		public Node Head { get; private set; }

		/// <summary>
		/// Default constructor
		/// </summary>
		public LinkedList()
		{
			Size = 0;
			Head = null;
			_tail = null;
		}

		/// <summary>
		/// Adds node to the end of linked list
		/// </summary>
		/// <param name="value">A <see cref="Node"/>'s value.</param>
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

		/// <summary>
		/// Adds an element at the specified index.
		/// </summary>
		/// <param name="value">An element's value.</param>
		/// <param name="index">An index where element will be added.</param>
		public void Add(int value, int index)
		{
			if (index > Size || index < 0)
			{
				string message = String.Format("Index is out of range. Expected value from 0 to {0}", Size);
				throw new ArgumentOutOfRangeException(message);
			}

			Node node = new Node() { Value = value };
			

			if (index == 0)
			{
				node.Next = Head;
				Head = node;
				Size++;
				return;
			}

			Node currentNode = Head;
			int i = 0;

			while (i < index - 1)
			{
				currentNode = currentNode.Next;
				i++;
			}

			node.Next = currentNode.Next;
			currentNode.Next = node;

			if (index == Size)
			{
				_tail = node;
			}

			Size++;
		}

		/// <summary>
		/// Gets list's element value at the specified index.
		/// </summary>
		/// <param name="index">Node's index.</param>
		/// <returns>Node's value.</returns>
		public object GetValue(int index)
		{
			if (index >= Size || index < 0)
			{
				string message = String.Format("Index is out of range. Expected value from 0 to {0}", Size - 1);
				throw new ArgumentOutOfRangeException(message);
			}

			if (Head == null)
			{
				throw new InvalidOperationException("List is empty.");
			}

			Node currentNode = Head;
			int i = 0;

			while (i < index)
			{
				currentNode = currentNode.Next;
				i++;
			}

			return currentNode.Value;
		}

		/// <summary>
		/// Gets all element's values in the list's order. Implemented for testing purposes.
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Deletes element at the specified index.
		/// </summary>
		/// <param name="index">Index of the element to be deleted</param>
		public void Delete(int index)
		{
			if (index >= Size || index < 0)
			{
				string message = String.Format("Index is out of range. Expected value from 0 to {0}", Size - 1);
				throw new ArgumentOutOfRangeException(message);
			}

			if (index == 0)
			{
				Head = Head.Next;
				Size--;
				return;
			}

			Node currentNode = Head;
			int i = 0;

			while (i < index - 1)
			{
				currentNode = currentNode.Next;
				i++;
			}

			currentNode.Next = currentNode.Next == null ? null : currentNode.Next.Next;

			Size--;
			if (index == Size)
			{
				_tail = currentNode;
			}
		}

		/// <summary>
		/// Reverses the elements in the linked list.
		/// </summary>
		public void Reverse()
		{
			Node previous = null;
			Node current = Head;
			Node next;

			_tail = Head;
			while (current != null)
			{
				next = current.Next;
				current.Next = previous;
				previous = current;
				current = next;
			}

			Head = previous;
		}

		/// <summary>
		/// Sorts the list using the merge sord
		/// </summary>
		public void Sort()
		{
			LinkedList front = new LinkedList();
			LinkedList back = new LinkedList();

			if ((Head == null) || (Head.Next == null))
			{
				return;
			}

			Node slow = Head;
			Node fast = Head.Next;

			while (fast != null)
			{
				fast = fast.Next;
				
				if (fast != null)
				{
					slow = slow.Next;
					fast = fast.Next;
				}
			}

			front.Head = Head;
			back.Head = slow.Next;
			slow.Next = null;

			front.Sort();
			back.Sort();
			Head = SortedMerge(front.Head, back.Head);
		}

		public void InsertIntoSorted(int value)
		{
			if (Head == null)
			{
				throw new InvalidOperationException("List is empty.");
			}

			Size++; //for testing purpose

			Node node = new Node();
			node.Value = value;
			
			if (node.Value <= Head.Value)
			{
				node.Next = Head;
				Head = node;
				return;
			}

			Node current = Head;

			while (current.Next != null)
			{
				if (node.Value <= current.Next.Value)
				{
					node.Next = current.Next;
					current.Next = node;
					return;
				}

				current = current.Next;
			}

			current.Next = node;
		}

		private Node SortedMerge(Node current, Node another)
		{
			Node result;

			if (current == null)
			{
				return another;
			}

			if (another == null)
			{
				return current;
			}

			if (current.Value < another.Value)
			{
				result = current;
				result.Next = SortedMerge(current.Next, another);

			}
			else
			{
				result = another;
				result.Next = SortedMerge(current, another.Next);
			}

			return result;
		}
	}
}
