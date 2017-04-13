using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArraySortScratch
{
	[TestClass]
	public class SortScratchTests
	{
		[TestMethod]
		public void Sort_ScratchSizeEqualsToInput_ShouldReturnSortedArray()
		{
			int[] inputNumbers = {3, 1, 4, 5, 2};
			int scratchSize = 5;
			int[] expected = {1, 2, 3, 4, 5};
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void Sort_ScratchSizeLessThenInput_ShouldReturnSortedArray()
		{
			int[] inputNumbers = { 3, 1, 4, 5, 2, 3, 1, 5, 1, 5 };
			int scratchSize = 5;
			int[] expected = { 1, 1, 1, 2, 3, 3, 4, 5, 5, 5 };
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void Sort_ScratchSizeGreaterThenInput_ShouldReturnSortedArray()
		{
			int[] inputNumbers = { 3, 1, 4, 5, 2 };
			int scratchSize = 1000;
			int[] expected = { 1, 2, 3, 4, 5 };
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void Sort_InputSizeOne_ShouldReturnSameArray()
		{
			int[] inputNumbers = { 1 };
			int scratchSize = 5;
			int[] expected = { 1 };
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void Sort_ScratchSizeOne_ShouldReturnSameArray()
		{
			int[] inputNumbers = { 1, 1, 1, 1 };
			int scratchSize = 1;
			int[] expected = { 1, 1, 1, 1 };
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sort_InputOutOfRange_ShouldThrowException()
		{
			int[] inputNumbers = { 3, 1, 4, 5, 2, 3, 1, 5, 1, 6 };
			int scratchSize = 5;			
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sort_InputEmpty_ShouldThrowException()
		{
			int[] inputNumbers = { };
			int scratchSize = 5;
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);	
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sort_InputNull_ShouldThrowException()
		{
			int[] inputNumbers = null;
			int scratchSize = 2;
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Sort_ScratchEmpty_ShouldThrowException()
		{
			int[] inputNumbers = { 3, 1, 4, 5, 2, 3, 1, 5, 1 };
			int scratchSize = 0;
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);	
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Sort_ScratchNegative_ShouldThrowException()
		{
			int[] inputNumbers = { 3, 1, 4, 5, 2, 3, 1, 5, 1 };
			int scratchSize = -1;
			Array array = new Array(ref inputNumbers);

			array.Sort(scratchSize);	
		}
	}
}
