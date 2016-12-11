using System;

namespace BinaryTreeDepth
{
	// 50.	Write a function to find the depth of a binary tree.
	// TODO: Figure out the type of node's values and how data should be inserted
	// Currently implemented as basic binary search tree (values that are less then current - placed at the left,
	// greater or equal - to the right of the current node
	class Program
	{
		private static void Main(string[] args)
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(100);
			tree.Insert(18);

			int depth = tree.GetDepth();
			Console.WriteLine(depth);
		}
	}
}
