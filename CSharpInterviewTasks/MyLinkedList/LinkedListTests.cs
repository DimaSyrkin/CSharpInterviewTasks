using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyLinkedList
{
	[TestClass]
	public class LinkedListTests
	{
		[TestMethod]
		public void LinkedList_AddElementToEmptyList_ShouldContainValue()
		{
			// arrange
			int expectedSize = 1;
			LinkedList list = new LinkedList();

			// act
			list.Add(10);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			Assert.AreEqual(10, list.GetValue(0));
			Assert.IsNotNull(list.Head);
		}

		[TestMethod]
		public void LinkedList_AddElementToNonEmptyList_ShouldAddElementAtTheEnd()
		{
			// arrange
			int expectedSize = 3;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			// act
			list.Add(30);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			Assert.AreEqual(30, list.GetValue(expectedSize - 1));			
		}

		[TestMethod]
		public void LinkedList_AddElementAtIndex_ShouldExtendListWithTheElement()
		{
			// arrange
			int expectedSize = 4;
			int addedValue = 15;
			int[] expectedElements = new int[] {10, 15, 20, 30};
			int index = 1;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Add(addedValue, index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			Assert.AreEqual(addedValue, list.GetValue(index)); // probably duplicates the next assertion
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		public void LinkedList_AddElementAtStartIndex_ShouldExtendListWithTheElementAndChangeHead()
		{
			// arrange
			int expectedSize = 4;
			int addedValue = 5;
			int[] expectedElements = new int[] { 5, 10, 20, 30 };
			int index = 0;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Add(addedValue, index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			Assert.AreEqual(addedValue, list.GetValue(index)); // probably duplicates the next assertion
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(addedValue, list.Head.Value, "Head value is not changed. Expected {0}, actual {1}", addedValue, list.Head.Value);
		}

		[TestMethod]
		public void LinkedList_AddElementAtEndIndex_ShouldExtendListWithTheElementAtTheEnd()
		{
			// arrange
			int expectedSize = 3;
			int addedValue = 30;
			int[] expectedElements = new int[] { 10, 20, 30 };
			int index = 2;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			// act
			list.Add(addedValue, index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void LinkedList_AddElementAtNegativeIndex_ShouldThrowException()
		{
			// arrange			
			int addedValue = 30;			
			int index = -1;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			// act
			list.Add(addedValue, index);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void LinkedList_AddElementAtIndexGreaterThanSize_ShouldThrowException()
		{
			// arrange			
			int addedValue = 30;			
			int index = 4;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			// act
			list.Add(addedValue, index);
		}

		[TestMethod]
		public void LinkedList_DeleteElementAtMiddleIndex_ShouldReduceListAndRemoveElement()
		{
			// arrange
			int expectedSize = 2;			
			object[] expectedElements = new object[] { 10, 30 };
			int index = 1;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Delete(index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		public void LinkedList_DeleteElementAtStartIndex_ShouldReduceListAndChangeHead()
		{
			// arrange
			int expectedSize = 2;
			int[] expectedElements = new int[] { 20, 30 };
			int index = 0;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Delete(index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(20, list.Head.Value);
		}

		[TestMethod]
		public void LinkedList_WithOneElementDelete_ShouldReturnEmptyList()
		{
			// arrange
			int expectedSize = 0;			
			int index = 0;
			LinkedList list = new LinkedList();
			list.Add(10);			

			// act
			list.Delete(index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);			
			Assert.IsNull(list.Head);
		}

		[TestMethod]
		public void LinkedList_DeleteElementAtEndIndex_ShouldReduceListAndRemoveElement()
		{
			// arrange
			int expectedSize = 2;
			int[] expectedElements = new int[] { 10, 20 };
			int index = 2;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Delete(index);

			// assert
			Assert.AreEqual(expectedSize, list.Size, "Elements count does not match. Expected - {0}, Actual - {1}", expectedSize, list.Size);
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void LinkedList_DeleteElementAtNegativeIndex_ShouldThrowException()
		{
			// arrange			
			int index = -1;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			// act
			list.Delete(index);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void LinkedList_DeleteElementAtIndexGreaterThanSize_ShouldThrowException()
		{
			// arrange			
			int index = 2; // Greater or equal
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			// act
			list.Delete(index);
		}

		// TODO: Think about more tests for the reverse
		[TestMethod]
		public void LinkedList_Reverse_ShouldReverseElements()
		{
			// arrange
			int[] expectedElements = new int[] { 30, 20, 10 };			
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			// act
			list.Reverse();

			// assert			
			CollectionAssert.AreEqual(expectedElements, list.GetAllValues());
			Assert.AreEqual(30, list.Head.Value);
		}
	}
}
