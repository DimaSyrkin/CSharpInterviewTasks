using System;

namespace BinaryTreeDepth
{
	/// <summary>
	/// Represents a binary tree
	/// </summary>
	public class BinaryTree
	{
		/// <summary>
		/// Represents a binary tree node
		/// </summary>
		public class Node
		{			
			/// <summary>
			/// Gets or sets the node value
			/// </summary>
			public int Value { get; set; }

			/// <summary>
			/// Gets or sets the left child node
			/// </summary>
			public Node Left;

			/// <summary>
			/// Gets or sets the left child node
			/// </summary>
			public Node Right;

			/// <summary>
			/// Default constructor
			/// </summary>
			/// <param name="value">Value of the tree node.</param>
			public Node(int value)
			{
				Value = value;
				Left = Right = null;
			}
		}

		/// <summary>
		/// Root (Top) tree node
		/// </summary>
		public Node Root;

		/// <summary>
		/// Default constuctor
		/// </summary>
		public BinaryTree()
		{
			Root = null;			
		}

		/// <summary>
		/// Constructor that assigns value to the Root node
		/// </summary>
		/// <param name="value">Root value to be assigned.</param>
		public BinaryTree(int value)
		{
			Root = new Node(value);
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
		public int GetDepth()
		{
			return GetDepthCore(Root);
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

		private int GetDepthCore(Node node)
		{
			return node == null ? 0 : (1 + Math.Max(GetDepthCore(node.Left), GetDepthCore(node.Right)));
		}
	}
}
