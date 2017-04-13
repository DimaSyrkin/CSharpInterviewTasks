using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeToList
{
	public class BinaryTree
	{
		public class Node
		{
			public int Value { get; set; }
			public Node Left;
			public Node Right;

			public Node(int value)
			{
				Value = value;
				Left = Right = null;
			}
		}

		public Node Root;		

		public BinaryTree()
		{
			Root = null;			
		}

		public void Insert(int value)
		{
			InsertRecursive(ref Root, value);
		}

		public void TraverseInOrder(Node node)
		{			
			if (node != null)
			{
				TraverseInOrder(node.Left);
				Console.Write(node.Value + " ");
				TraverseInOrder(node.Right);
			}
		}

		public void ToList(ref LinkedList list)
		{
			if (Root == null)
			{
				throw new InvalidOperationException("Tree is empty");
			}

			ToListRecursive(Root, ref list);
		}

		private void ToListRecursive(Node node, ref LinkedList list)
		{
			if (node != null)
			{
				ToListRecursive(node.Left, ref list);
				list.Add(node.Value);
				ToListRecursive(node.Right, ref list);
			}
		}

		private void InsertRecursive(ref Node node, int value)
		{
			if (node == null)
			{
				Node newNode = new Node(value);
				node = newNode;
			}
			else
			{
				if (value < node.Value)
				{
					InsertRecursive(ref node.Left, value);
				}
				else
				{
					InsertRecursive(ref node.Right, value);
				}
			}
		}
	}
}
