using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeToList
{
	class Program
	{
		static void Main(string[] args)
		{
			BinaryTree tree = new BinaryTree();
			LinkedList list = new LinkedList();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(100);
			tree.Insert(18);
			tree.Insert(8);
			tree.Insert(6);
			tree.Insert(66);

			tree.ToList(ref list);
			// tree.TraverseInOrder(tree.Root);
		}
	}
}
