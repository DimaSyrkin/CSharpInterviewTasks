using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeFromArray
{
	[TestClass]
	public class BinaryTreeTest
	{
		
		[TestMethod]
		public void FromArray_OneElement_ReturnsTreeWithOneElement()
		{
			int[] array = new []{1};
			List<int> expected = new List<int>() { 1 };

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);

			binaryTree.TraverseInOrder(binaryTree.Root);
			CollectionAssert.AreEqual(expected, binaryTree.NodeValues);
		}

		[TestMethod]
		public void FromArray_TwoElements_ReturnsTreeWithLeftChild()
		{
			int[] array = new[] { 1, 2 };
			List<int> expected = new List<int>(array);

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);

			binaryTree.TraverseInOrder(binaryTree.Root);
			CollectionAssert.AreEqual(expected, binaryTree.NodeValues);
		}

		[TestMethod]
		public void FromArray_OddElementsSorted_ReturnsBinarySearchTree()
		{
			int[] array = new[] { 1, 3, 5, 7, 9, 11, 13 };
			List<int> expected = new List<int>(array);

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);

			binaryTree.TraverseInOrder(binaryTree.Root);
			CollectionAssert.AreEqual(expected, binaryTree.NodeValues);
		}

		[TestMethod]
		public void FromArray_EvenElementsSorted_ReturnsBinarySearchTree()
		{
			int[] array = new[] { 1, 3, 5, 7, 9, 11 };
			List<int> expected = new List<int>(array);

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);

			binaryTree.TraverseInOrder(binaryTree.Root);
			CollectionAssert.AreEqual(expected, binaryTree.NodeValues);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void FromArray_NotSorted_ThrowsException()
		{
			int[] array = new[] { 1, 5, 2, 7 };			

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FromArray_EmptyArray_ThrowsException()
		{
			int[] array = { };			

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);						
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FromArray_NullArray_ThrowsException()
		{
			int[] array = null;

			BinaryTree binaryTree = new BinaryTree();
			binaryTree.FromArray(ref array);
		}
	}
}
