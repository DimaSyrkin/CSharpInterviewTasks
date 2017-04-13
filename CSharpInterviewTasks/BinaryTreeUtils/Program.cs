using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeUtils
{
	class Program
	{
		static void Main(string[] args)
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(100);
			tree.Insert(18);
			tree.Insert(8);
			tree.Insert(6);
			tree.Insert(66);

			//tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);
			tree.Mirror();
			//tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			int?[,] triples =
			{
				{0, 1, 2}, {1, 5, 9}, {9, 6, 4}, {2, 7, 1}, {1, 3, 8}, {7, null, 1}
			};

			BinaryTree generatedTree = BinaryTree.GenerateBinaryTree(triples);
		}
	}
}
