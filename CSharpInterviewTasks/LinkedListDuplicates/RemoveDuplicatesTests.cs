using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedListDuplicates
{
	[TestClass]
	public class RemoveDuplicatesTests
	{
		[TestMethod]
		public void RemoveNodes_FixedListNoElements_ShouldReturnSameList()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(6).Add(8).Add(0);

			int[] expected = {1, 2, 5, 10, 5};

			input.RemoveNodesFrom(fixedList);

			CollectionAssert.AreEqual(expected, input.GetAllValues());
		}

		[TestMethod]
		public void RemoveNodes_FixedListOneElementNoHead_ShouldRemoveOneElement()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(0).Add(2);

			int[] expected = { 1, 5, 10, 5 };

			input.RemoveNodesFrom(fixedList);

			CollectionAssert.AreEqual(expected, input.GetAllValues());
		}

		[TestMethod]
		public void RemoveNodes_FixedListOneElementMultipleTimes_ShouldRemoveMultipleNodes()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(0).Add(5);

			int[] expected = { 1, 2, 10 };

			input.RemoveNodesFrom(fixedList);

			CollectionAssert.AreEqual(expected, input.GetAllValues());
		}

		[TestMethod]
		public void RemoveNodes_FixedListMultipleElementsWithHead_ShouldRemoveMultipleNodesAndChangeHead()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(0).Add(5).Add(1);

			int[] expectedValues = { 2, 10 };
			int expectedHeadValue = 2;

			input.RemoveNodesFrom(fixedList);

			CollectionAssert.AreEqual(expectedValues, input.GetAllValues());
			Assert.AreEqual(expectedHeadValue, input.Head.Value);
		}

		[TestMethod]
		public void RemoveNodes_FixedListAllElementsExceptHead_ShouldReturnListWithOneNode()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(0).Add(5).Add(10).Add(2);

			int[] expected = { 1 };

			input.RemoveNodesFrom(fixedList);

			CollectionAssert.AreEqual(expected, input.GetAllValues());
		}

		[TestMethod]
		public void RemoveNodes_FixedListAllElementsExceptOne_ShouldReturnListWithOneNode()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(0).Add(5).Add(1).Add(2);

			int[] expected = { 10 };

			input.RemoveNodesFrom(fixedList);

			CollectionAssert.AreEqual(expected, input.GetAllValues());
		}

		[TestMethod]
		public void RemoveNodes_FixedListAllElements_ShouldReturnEmptyList()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();
			fixedList.Add(0).Add(5).Add(1).Add(2).Add(10);			

			input.RemoveNodesFrom(fixedList);

			Assert.IsNull(input.Head);
			Assert.AreEqual(0, input.Size);			
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveNodes_FixedListIsEmpty_ShouldThrowException()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);

			LinkedList fixedList = new LinkedList();

			input.RemoveNodesFrom(fixedList);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveNodes_FixedListIsNull_ShouldThrowException()
		{
			LinkedList input = new LinkedList();
			input.Add(1).Add(2).Add(5).Add(10).Add(5);			

			input.RemoveNodesFrom(null);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void RemoveNodes_InputListIsEmpty_ShouldThrowException()
		{
			LinkedList input = new LinkedList();			

			LinkedList fixedList = new LinkedList();
			fixedList.Add(1).Add(2).Add(5).Add(10).Add(5);

			input.RemoveNodesFrom(fixedList);
		}
	}
}
