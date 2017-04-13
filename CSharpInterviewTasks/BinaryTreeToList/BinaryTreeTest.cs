using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeToList
{
	[TestClass]
	public class BinaryTreeTest
	{
		[TestMethod]
		public void BinaryTreeToSortedList_Symmetric_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();			
			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(50);
			int[] expectedValues = {10, 25, 50};
			int[] expectedReversedValues = { 50, 25, 10 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_LeftSubtreeHigherThanRight_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(15);
			tree.Insert(5);
			tree.Insert(12);
			tree.Insert(50);
			tree.Insert(40);
			int[] expectedValues = { 5, 10, 12, 15, 25, 40, 50};
			int[] expectedReversedValues = { 50, 40, 25, 15, 12, 10, 5 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_RightSubtreeThanRight_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(5);
			tree.Insert(15);
			tree.Insert(50);
			tree.Insert(40);
			tree.Insert(60);
			tree.Insert(35);
			tree.Insert(45);
			int[] expectedValues = { 5, 10, 15, 25, 35, 40, 45, 50, 60 };
			int[] expectedReversedValues = { 60, 50, 45, 40, 35, 25, 15, 10, 5 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_LeftSubtreeLeftDirection_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(5);
			tree.Insert(4);
			tree.Insert(2);
			int[] expectedValues = { 2, 4, 5, 10, 25 };
			int[] expectedReversedValues = { 25, 10, 5, 4, 2 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_RightSubtreeRightDirection_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			tree.Insert(50);
			tree.Insert(55);
			tree.Insert(60);
			tree.Insert(150);
			int[] expectedValues = { 25, 50, 55, 60, 150 };
			int[] expectedReversedValues = { 150, 60, 55, 50, 25 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_LeftSubtreeRightDirection_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			tree.Insert(10);
			tree.Insert(15);
			tree.Insert(18);
			tree.Insert(20);
			int[] expectedValues = { 10, 15, 18, 20, 25 };
			int[] expectedReversedValues = { 25, 20, 18, 15, 10 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_RightSubtreeLeftDirection_ShouldBeConverted()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			tree.Insert(100);
			tree.Insert(75);
			tree.Insert(50);
			tree.Insert(30);
			int[] expectedValues = { 25, 30, 50, 75, 100 };
			int[] expectedReversedValues = { 100, 75, 50, 30, 25 };
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			CollectionAssert.AreEqual(expectedValues, list.ToArray());
			CollectionAssert.AreEqual(expectedReversedValues, list.ToArrayReverse());
		}

		[TestMethod]
		public void BinaryTreeToSortedList_OneElement_ShouldReturnListWithOneElement()
		{
			BinaryTree tree = new BinaryTree();
			tree.Insert(25);
			int expected = 25;			
			LinkedList list = new LinkedList();

			tree.ToList(ref list);

			int actual = list.ToArray()[0];
			Assert.AreEqual(expected, actual);			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void BinaryTreeToSortedList_Empty_ShouldThrowException()
		{
			BinaryTree tree = new BinaryTree();
			LinkedList list = new LinkedList();

			tree.ToList(ref list);
		}
	}
}
