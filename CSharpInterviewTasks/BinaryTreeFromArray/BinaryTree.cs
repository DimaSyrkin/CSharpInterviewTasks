using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeFromArray
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

		internal List<int> NodeValues; // for testing

		public BinaryTree()
		{
			Root = null;
			NodeValues = new List<int>();
		}

		public void FromArray(ref int[] numbers)
		{
			if (numbers == null || numbers.Length == 0)
			{
				throw new InvalidOperationException("Input array is null or empty");
			}

			if (!IsSortedAsc(ref numbers))
			{
				throw new ArgumentException("Input array is not sorted", "numbers");
			}

			if (numbers.Length == 1)
			{
				Root = new Node(numbers[0]);
				return;
			}

			CreateNodesFromArray(ref Root, ref numbers, 0, numbers.Length - 1);
		}

		private void CreateNodesFromArray(ref Node node, ref int[] numbers, int left, int right)
		{
			if (left > right)
			{
				return;
			}

			int middle = (left + right)/2;
			node = new Node(numbers[middle]);
			CreateNodesFromArray(ref node.Left, ref numbers, left, middle-1);
			CreateNodesFromArray(ref node.Right, ref numbers, middle + 1, right);
		}

		public void TraverseInOrder(Node node)
		{
			if (node != null)
			{
				TraverseInOrder(node.Left);
				NodeValues.Add(node.Value);
				TraverseInOrder(node.Right);
			}
		}

		private bool IsSortedAsc(ref int[] array)
		{
			for (int i = 1; i < array.Length; i++)
			{
				if (array[i] < array[i - 1])
				{
					return false;
				}
			}
			return true;
		}
	}
}
