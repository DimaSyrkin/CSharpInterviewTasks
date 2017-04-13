using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeDepth
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

		public enum TraversalType
		{
			PreOrder,
			InOrder,
			PostOrder
		};
		
		public Node Root;

		public BinaryTree()
		{
			Root = null;			
		}

		public BinaryTree(int value)
		{
			Root = new Node(value);
		}

		public void TraverseRecursive(TraversalType traversalType)
		{
			if (traversalType == TraversalType.InOrder)
				TraverseInOrderRecursiveCore(Root);
			if (traversalType == TraversalType.PreOrder)
				TraversePreOrderRecursiveCore(Root);
			if (traversalType == TraversalType.PostOrder)
				TraversePostOrderRecursiveCore(Root);
		}

		/// <summary>
		/// Inserts a value in a binary tree.
		/// </summary>
		/// <param name="value">Value to be inserted.</param>
		public void Insert(int value)
		{
			InsertCore(ref Root, value);
		}

		/// <summary>
		/// Gets the tree depth in recursive way
		/// </summary>
		/// <returns>The tree depth.</returns>
		public int GetDepthRecursive()
		{
			return GetDepthRecursiveCore(Root);
		}

		public int GetMaxDepth()
		{
			if (Root == null)
			{
				return 0;
			}

			Dictionary nodeDepth = new Dictionary();
			int maxDepth = 1;
			int depth = 0;
			nodeDepth.Add(Root, maxDepth);

			while (nodeDepth.Count != 0)
			{

				Node current = nodeDepth.First().Key;
				if (current.Right != null)
				{
					depth = nodeDepth.Get(current) + 1;
					nodeDepth.Add(current.Right, depth);
				}

				if (current.Left != null)
				{
					depth = nodeDepth.Get(current) + 1;
					nodeDepth.Add(current.Left, depth);
				}
				nodeDepth.Remove(current);

				if (depth > maxDepth)
				{
					maxDepth = depth;
				}

				//Console.Write(current.Value + " ");			
			}
			return maxDepth;
		}

		public void TraverseDictionary()
		{
			Dictionary<Node, int> nodeDepth = new Dictionary<Node, int>();
			nodeDepth.Add(Root, 1);
			foreach (var node in nodeDepth.Keys)
			{
				if (node.Left != null && !nodeDepth.ContainsKey(node.Left))
				{
					nodeDepth.Add(node.Left, nodeDepth[node] + 1);
				}

				if (node.Right != null && !nodeDepth.ContainsKey(node.Right))
				{
					nodeDepth.Add(node.Right, nodeDepth[node] + 1);
				}
			}
		}

		private void TraversePostOrderRecursiveCore(Node node)
		{
			if (node != null)
			{				
				TraversePostOrderRecursiveCore(node.Left);
				TraversePostOrderRecursiveCore(node.Right);
				Console.Write(node.Value + " ");
			}
		}

		private void TraverseInOrderRecursiveCore(Node node)
		{
			if (node != null)
			{
				TraverseInOrderRecursiveCore(node.Left);
				Console.Write(node.Value + " ");
				TraverseInOrderRecursiveCore(node.Right);
			}
		}

		private void TraversePreOrderRecursiveCore(Node node)
		{
			if (node != null)
			{
				Console.Write(node.Value + " ");
				TraversePreOrderRecursiveCore(node.Left);
				TraversePreOrderRecursiveCore(node.Right);
			}
		}

		private int GetDepthRecursiveCore(Node node)
		{
			return node == null ? 0 : (1 + Math.Max(GetDepthRecursiveCore(node.Left), GetDepthRecursiveCore(node.Right)));
		}

		private void InsertCore(ref Node node, int value)
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
					InsertCore(ref node.Left, value);
				}
				else
				{
					InsertCore(ref node.Right, value);
				}
			}
		}

		/*
		public void TraverseMorrisInOrder()
		{
			Node current = Root;
			Node predecessor;

			while (current != null)
			{
				if (current.Left == null)
				{
					Console.Write(current.Value + " ");
					current = current.Right;
				}
				else
				{
					predecessor = current.Left;
					while (predecessor.Right != null && predecessor.Right != current)
					{
						predecessor = predecessor.Right;
					}

					if (predecessor.Right == null)
					{
						predecessor.Right = current;
						current = current.Left;
					}
					else
					{
						predecessor.Right = null;
						Console.Write(current.Value + " ");
						current = current.Right;
					}
				}
			}
		}

		public void TraverseMorrisPreOrder()
		{
			Node current = Root;
			Node predecessor = null;

			while (current != null)
			{
				if (current.Left == null)
				{
					Console.Write(current.Value + " ");
					current = current.Right;
				}
				else
				{
					predecessor = current.Left;
					while (predecessor.Right != null && predecessor.Right != current)
					{
						predecessor = predecessor.Right;
					}

					if (predecessor.Right == null)
					{
						Console.Write(current.Value + " ");
						predecessor.Right = current;
						current = current.Left;
					}
					else
					{
						predecessor.Right = null;
						current = current.Right;
					}
				}
			}
		}
		
		public void TraversePreOrderStack()
		{
			Node current = Root;
			Stack<Node> stack = new Stack<Node>();

			while (current != null || stack.Count != 0)
			{
				if (stack.Count != 0)
				{
					current = stack.Pop();
				}

				while (current != null)
				{
					Console.Write(current.Value + " ");
					if (current.Right != null)
					{
						stack.Push(current.Right);						
					}
					current = current.Left;
				}
			}
		}

		public void TraverseBreadth()
		{
			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(Root);

			while (queue.Count != 0)
			{
				Node current = queue.Peek();
				if (current.Left != null)
				{
					queue.Enqueue(current.Left);
				}

				if (current.Right != null)
				{
					queue.Enqueue(current.Right);
				}

				Console.Write(current.Value + " ");
				queue.Dequeue();
			}
		}
		*/
	}
}
