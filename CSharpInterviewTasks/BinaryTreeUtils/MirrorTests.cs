using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeUtils
{
	[TestClass]
	public class MirrorTests
	{
		[TestMethod]
		public void Mirror_BalancedTreeRootDepthOne_ShouldReturnRootRightLeft()
		{
			int?[,] triples =
			{
				{1, 2, 3}
			};
			List<int> expected = new List<int>() {3, 1, 2};
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void Mirror_BalancedTreeLeftSubTreeGreater_ShouldReturnTreeRightSubTreeGreater()
		{
			int?[,] triples =
			{
				{1, 2, 3},
				{3, 6, 9},
				{2, 4, 8},
				{8, 16, 24},
				{4, 12, 8}
			};
			List<int> expected = new List<int>() { 9, 3, 6, 1, 24, 8, 16, 2, 8, 4, 12 };
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void Mirror_BalancedTreeRightSubTreeGreater_ShouldReturnTreeLeftSubTreeGreater()
		{
			int?[,] triples =
			{
				{1, 3, 2},
				{3, 6, 9},
				{2, 4, 8},
				{8, 16, 24},
				{4, 12, 8}
			};
			List<int> expected = new List<int>() { 24, 8, 16, 2, 8, 4, 12, 1, 9, 3, 6 };
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void Mirror_TreeRootOnly_ShouldReturnRoot()
		{
			int?[,] triples =
			{
				{1, null, null}
			};
			List<int> expected = new List<int>() {1};
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void Mirror_UnBalancedTreeLeftSubTreeGreater_ShouldReturnRightSubTreeGreater()
		{
			int?[,] triples =
			{
				{1, 2, 3},
				{3, 6, 9},
				{2, 4, 8},
				{8, 16, null},
				{4, null, 12}
			};
			List<int> expected = new List<int>() { 9, 3, 6, 1, 8, 16, 2, 12, 4 };
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void Mirror_UnBalancedTreeLeftSubTreeOnly_ShouldReturnRightSubTreeOnly()
		{
			int?[,] triples =
			{
				{1, 2, null},				
				{2, 4, 8},
				{8, 16, 24},
				{24, null, 48},
				{48, 96, null}
			};
			List<int> expected = new List<int>() { 1, 48, 96, 24, 8, 16, 2, 4 };
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void Mirror_UnBalancedTreeRightSubTreeOnly_ShouldReturnLeftSubTreeOnly()
		{
			int?[,] triples =
			{
				{1, null, 2},				
				{2, 4, 8},
				{8, 16, 24},
				{24, null, 48},
				{48, 96, null}
			};
			List<int> expected = new List<int>() { 48, 96, 24, 8, 16, 2, 4, 1 };
			BinaryTree tree = BinaryTree.GenerateBinaryTree(triples);

			tree.Mirror();

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);
			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}
	}
}
