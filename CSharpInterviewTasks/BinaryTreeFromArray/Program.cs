using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinaryTreeFromArray
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = new[] { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };

			BinaryTree binaryTree = new BinaryTree();

			binaryTree.FromArray(ref numbers);
		}
	}
}
