using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLinkedList
{
	[TestClass]
	public class InsertIntoSortedTests
	{
		[TestMethod]
		public void InsertIntoSorted_InsertInTheMiddle_ShouldReturnListWithInsertedValueInTheMiddle()
		{
			// arrange
			int insertedValue = 25;
			int[] expectedElements = new int[] { 10, 20, 25, 30, 40 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Add(40);
			list.Add(30);
			list.Add(10);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		public void InsertIntoSorted_InsertSmallestValue_ShouldReturnListWithInsertedValueInTheFirstAndChangeHead()
		{
			// arrange
			int insertedValue = 5;
			int[] expectedElements = new int[] { 5, 10, 20, 30, 40 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Add(40);
			list.Add(30);
			list.Add(10);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(insertedValue, list.Head.Value);
		}

		[TestMethod]
		public void InsertIntoSorted_InsertSmallEqualValue_ShouldReturnListWithFirstTwoEqualValues()
		{
			// arrange
			int insertedValue = 10;
			int[] expectedElements = new int[] { 10, 10, 20, 30, 40 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Add(40);
			list.Add(30);
			list.Add(10);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(insertedValue, list.Head.Value);
		}

		[TestMethod]
		public void InsertIntoSorted_InsertLargestValue_ShouldReturnListWithNewLastElement()
		{
			// arrange
			int insertedValue = 50;
			int[] expectedElements = new int[] { 10, 20, 30, 40, 50 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Add(40);
			list.Add(30);
			list.Add(10);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		public void InsertIntoSorted_InsertLargestEqualValue_ShouldReturnListWithTwoLastElementsEqual()
		{
			// arrange
			int insertedValue = 40;
			int[] expectedElements = new int[] { 10, 20, 30, 40, 40 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Add(40);
			list.Add(30);
			list.Add(10);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		public void InsertIntoSorted_ListWithOneElementInsertLess_ShouldReturnListWithInsertedValueInTheFirstAndChangeHead()
		{
			// arrange
			int insertedValue = 5;
			int[] expectedElements = new int[] { 5, 20 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(insertedValue, list.Head.Value);
		}

		[TestMethod]
		public void InsertIntoSorted_ListWithOneElementInsertGreater_ShouldReturnListWithInsertedValueInTheLast()
		{
			// arrange
			int insertedValue = 25;
			int[] expectedElements = new int[] { 20, 25 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(insertedValue, list.Head.Next.Value);
			Assert.IsNull(list.Head.Next.Next);
		}

		[TestMethod]
		public void InsertIntoSorted_ListWithOneElementInsertEqual_ShouldReturnListTwoEqualValues()
		{
			// arrange
			int insertedValue = 20;
			int[] expectedElements = new int[] { 20, 20 };
			LinkedList list = new LinkedList();
			list.Add(20);
			list.Sort();

			// act
			list.InsertIntoSorted(insertedValue);

			// assert
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void InsertIntoSorted_EmptyList_ShouldThrowException()
		{
			// arrange
			LinkedList list = new LinkedList();

			// act
			list.Sort();
			list.InsertIntoSorted(0);
		}
	}
}
