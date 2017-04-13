using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace BinaryTreeUtils
{
	public class BinaryTree
	{
		private bool _isTestMode;
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

		public enum TraversalType
		{
			PreOrder,
			InOrder,
			PostOrder
		};

		public enum InsertDirection
		{
			Left,
			Right			
		};

		public Node Root;
		internal List<int> NodeValues; // for testing

		public BinaryTree()
		{
			Root = null;
			_isTestMode = false;
			NodeValues = new List<int>();
		}

		public void Insert(int value)
		{
			InsertRecursive(ref Root, value);
		}

		public void TraverseRecursive(TraversalType traversalType)
		{
			if (Root == null)
			{
				throw new InvalidOperationException("Tree is empty");
			}

			if (traversalType == TraversalType.InOrder)
				TraverseInOrderRecursive(Root);
			if (traversalType == TraversalType.PreOrder)
				TraversePreOrderRecursive(Root);
			if (traversalType == TraversalType.PostOrder)
				TraversePostOrderRecursive(Root);
			Console.WriteLine();
		}

		public void Mirror()
		{
			if (Root == null)
			{
				throw new InvalidOperationException("Tree is empty");
			}

			MirrorSubTrees(Root);
		}

		internal void SetTestMode(bool value)
		{
			_isTestMode = value;
		}

		private void TraversePostOrderRecursive(Node node)
		{
			if (node != null)
			{
				TraversePostOrderRecursive(node.Left);
				TraversePostOrderRecursive(node.Right);
				PrintNodeValue(node);
			}
		}

		private void TraverseInOrderRecursive(Node node)
		{
			if (node != null)
			{
				TraverseInOrderRecursive(node.Left);
				PrintNodeValue(node);
				TraverseInOrderRecursive(node.Right);
			}
		}

		private void TraversePreOrderRecursive(Node node)
		{
			if (node != null)
			{
				PrintNodeValue(node);
				TraversePreOrderRecursive(node.Left);
				TraversePreOrderRecursive(node.Right);
			}			
		}

		private void MirrorSubTrees(Node node)
		{
			if (node != null)
			{
				MirrorSubTrees(node.Left);
				MirrorSubTrees(node.Right);
				
				Node temp;
				temp = node.Left;
				node.Left = node.Right;
				node.Right = temp;
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

		private void PrintNodeValue(Node node)
		{
			if (!_isTestMode)
			{
				Console.Write(node.Value + " ");
			}
			else
			{
				NodeValues.Add(node.Value);
			}
		}

		public static BinaryTree GenerateBinaryTree(int?[,] triples)
		{
			if (triples[0, 0] == null)
			{
				throw new ArgumentException("First element in input array is null");
			}

			if (triples.GetLength(1) != 3)
			{
				throw new ArgumentException("Input array size is invalid");
			}

			BinaryTree tree = new BinaryTree();
			Dictionary<int, Node> leaves = new Dictionary<int, Node>();

			if (tree.Root == null)
			{
				tree.Root = new Node((int)triples[0, 0]);
				AddChildren(ref tree.Root, ref triples, 0, ref leaves);
			}

			for (int i = 1; i < triples.Length/3; i++)
			{
				if (triples[i, 0] != null && leaves.ContainsKey((int)triples[i, 0]))
				{
					Node parent = leaves[(int) triples[i, 0]];
					leaves.Remove(parent.Value);
					AddChildren(ref parent, ref triples, i, ref leaves);				
				}
			}

			return tree;
		}

		private static void AddChildren(ref Node parent, ref int?[,] triples, int index, ref Dictionary<int, Node> leaves)
		{
			if (triples[index, 1] != null)
			{
				parent.Left = new Node((int)triples[index, 1]);
				leaves.Add(parent.Left.Value, parent.Left);
			}

			if (triples[index, 2] != null)
			{
				parent.Right = new Node((int)triples[index, 2]);
				leaves.Add(parent.Right.Value, parent.Right);
			}	
		}
	}
}
