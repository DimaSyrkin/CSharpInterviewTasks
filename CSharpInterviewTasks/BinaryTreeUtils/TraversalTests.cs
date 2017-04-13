using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeUtils
{
	[TestClass]
	public class TraversalTests
	{
		[TestMethod]
		public void PreorderTraversal_BalancedTree_ShouldPrintRootLeftRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);

			List<int> expected = new List<int>() {25, 10, 50};

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PreorderTraversal_BalancedTreeLeftSubtreeHigher_ShouldPrintRootLeftRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(15);
			tree.Insert(1);

			List<int> expected = new List<int>() { 25, 10, 1, 15, 50 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PreorderTraversal_BalancedTreeRightSubtreeHigher_ShouldPrintRootLeftRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(75);
			tree.Insert(40);

			List<int> expected = new List<int>() { 25, 10, 50, 40, 75 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PreorderTraversal_UnBalancedTreeLeftSubTree_ShouldPrintRootLeftRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(5);
			tree.Insert(3);
			tree.Insert(2);
			tree.Insert(1);

			List<int> expected = new List<int>() { 25, 10, 5, 3, 2, 1 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PreorderTraversal_UnBalancedTreeRightSubTree_ShouldPrintRootLeftRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(50);
			tree.Insert(55);
			tree.Insert(60);
			tree.Insert(80);
			tree.Insert(100);

			List<int> expected = new List<int>() { 25, 50, 55, 60, 80, 100 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PreorderTraversal_RootOnly_ShouldPrintOneElement()
		{
			int expected = 100;
			BinaryTree tree = new BinaryTree();
			tree.Insert(expected);			

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PreOrder);

			int actual = tree.NodeValues[0];
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PostorderTraversal_BalancedTree_ShouldPrintLeftRightRoot()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);

			List<int> expected = new List<int>() { 10, 50, 25 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PostOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PostorderTraversal_BalancedTreeLeftSubtreeHigher_ShouldPrintLeftRightRoot()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(15);
			tree.Insert(1);

			List<int> expected = new List<int>() { 1, 15, 10, 50, 25 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PostOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PostorderTraversal_BalancedTreeRightSubtreeHigher_ShouldPrintLeftRightRoot()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(75);
			tree.Insert(40);

			List<int> expected = new List<int>() { 10, 40, 75, 50, 25 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PostOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PostorderTraversal_UnBalancedTreeLeftSubTree_ShouldPrintLeftRightRoot()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(5);
			tree.Insert(3);
			tree.Insert(2);
			tree.Insert(1);

			List<int> expected = new List<int>() { 1, 2, 3, 5, 10, 25 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PostOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PostorderTraversal_UnBalancedTreeRightSubTree_ShouldPrintLeftRightRoot()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(50);
			tree.Insert(55);
			tree.Insert(60);
			tree.Insert(80);
			tree.Insert(100);

			List<int> expected = new List<int>() { 100, 80, 60, 55, 50, 25 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PostOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void PostorderTraversal_RootOnly_ShouldPrintOneElement()
		{
			int expected = 100;
			BinaryTree tree = new BinaryTree();
			tree.Insert(expected);

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.PostOrder);

			int actual = tree.NodeValues[0];
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void InorderTraversal_BalancedTree_ShouldPrintLeftRootRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);

			List<int> expected = new List<int>() { 10, 25, 50 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void InorderTraversal_BalancedTreeLeftSubtreeHigher_ShouldPrintLeftRootRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(15);
			tree.Insert(1);

			List<int> expected = new List<int>() { 1, 10, 15, 25, 50 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void InorderTraversal_BalancedTreeRightSubtreeHigher_ShouldPrintLeftRootRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			tree.Insert(75);
			tree.Insert(40);

			List<int> expected = new List<int>() { 10, 25, 40, 50, 75 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void InorderTraversal_UnBalancedTreeLeftSubTree_ShouldPrintLeftRootRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(5);
			tree.Insert(3);
			tree.Insert(2);
			tree.Insert(1);

			List<int> expected = new List<int>() { 1, 2, 3, 5, 10, 25 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void InorderTraversal_UnBalancedTreeRightSubTree_ShouldPrintLeftRootRight()
		{
			BinaryTree tree = new BinaryTree();

			tree.Insert(25);
			tree.Insert(50);
			tree.Insert(55);
			tree.Insert(60);
			tree.Insert(80);
			tree.Insert(100);

			List<int> expected = new List<int>() { 25, 50, 55, 60, 80, 100 };

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

			CollectionAssert.AreEqual(expected, tree.NodeValues);
		}

		[TestMethod]
		public void InorderTraversal_RootOnly_ShouldPrintOneElement()
		{
			int expected = 100;
			BinaryTree tree = new BinaryTree();
			tree.Insert(expected);

			tree.SetTestMode(true);
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

			int actual = tree.NodeValues[0];
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Traversal_EmptyTree_ShouldThrowException()
		{			
			BinaryTree tree = new BinaryTree();		
			tree.TraverseRecursive(BinaryTree.TraversalType.InOrder);

		}
	}
}
