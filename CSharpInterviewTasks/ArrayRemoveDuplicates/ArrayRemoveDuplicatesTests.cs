using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayRemoveDuplicates
{
	[TestClass]
	public class ArrayRemoveDuplicatesTests
	{
		[TestMethod]
		public void RemoveDuplicates_FirstElementsDuplicatedResize_ShouldResizeArray()
		{
			int[] inputNumbers = {2, 2, 2, 3, 6, 7, 9};
			int[] expected = { 2, 3, 6, 7, 9 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_FirstElementsDuplicatedFillMax_ShouldFillArray()
		{
			int[] inputNumbers = { 2, 2, 2, 3, 6, 7, 9 };
			int[] expected = { 2, 3, 6, 7, 9, Int32.MaxValue, Int32.MaxValue };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.FillMaxInt);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_LastElementsDuplicatedResize_ShouldResizeArray()
		{
			int[] inputNumbers = { 2, 3, 6, 7, 9, 9, 9 };
			int[] expected = { 2, 3, 6, 7, 9 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_LastElementsDuplicatedFillMax_ShouldFillArray()
		{
			int[] inputNumbers = { 2, 3, 6, 7, 9, 9, 9 };
			int[] expected = { 2, 3, 6, 7, 9, Int32.MaxValue, Int32.MaxValue };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.FillMaxInt);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_SeveralElementsDuplicatedResize_ShouldResizeArray()
		{
			int[] inputNumbers = { 2, 2, 3, 6, 6, 6, 7, 7, 9, 9 };
			int[] expected = { 2, 3, 6, 7, 9 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_SeveralElementsDuplicatedFillMax_ShouldFillArray()
		{
			int[] inputNumbers = { 2, 2, 3, 6, 6, 6, 7, 7, 9, 9 };
			int[] expected = { 2, 3, 6, 7, 9, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.FillMaxInt);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_AllElementsEqualResize_ShouldResizeArray()
		{
			int[] inputNumbers = { 2, 2, 2 };
			int[] expected = { 2 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_AllElementsEqualFillMax_ShouldFillArray()
		{
			int[] inputNumbers = { 2, 2, 2};
			int[] expected = { 2, Int32.MaxValue, Int32.MaxValue };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.FillMaxInt);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_ArrayUniqueResize_ShouldReturnSameArray()
		{
			int[] inputNumbers = { 1, 2, 3 };
			int[] expected = { 1, 2, 3 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_ArrayUniqueFillMaxInt_ShouldReturnSameArray()
		{
			int[] inputNumbers = { 1, 2, 3 };
			int[] expected = { 1, 2, 3 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.FillMaxInt);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_ArraySizeOneResize_ShouldReturnSameArray()
		{
			int[] inputNumbers = { 3 };
			int[] expected = { 3 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		public void RemoveDuplicates_ArraySizeOneFillMax_ShouldReturnSameArray()
		{
			int[] inputNumbers = { 3 };
			int[] expected = { 3 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.FillMaxInt);

			CollectionAssert.AreEqual(expected, array.InputElements);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void RemoveDuplicates_ArrayUnsorted_ShouldThrowException()
		{
			int[] inputNumbers = { 2, 3, 4, 1 };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void RemoveDuplicates_ArrayEmpty_ShouldThrowException()
		{
			int[] inputNumbers = {  };
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void RemoveDuplicates_ArrayNull_ShouldThrowException()
		{
			int[] inputNumbers = null;
			Array array = new Array(ref inputNumbers);

			array.RemoveDuplicates(Array.RemoveDuplicatesStrategy.ResizeArray);

		}

	}
}
