using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayGetTopNumbers
{
	[TestClass]
	public class ArrayGetTopNumbersTests
	{
		[TestMethod]
		public void GetTopNumbers_UnsortedArrayDifferentValuesTop1_ReturnsArrayWithMaxValue()
		{
			int[] inputNumbers = { 33, 2, 110, 21, 17 };
			int topCount = 1;
			int[] expected = { 110 };			
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_UnsortedArrayDifferentValuesTop2_ReturnsArrayWithTwoMaxValues()
		{
			int[] inputNumbers = { 33, 2, 110, 21, 17 };
			int topCount = 2;
			int[] expected = { 110, 33 };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_UnsortedArrayDifferentValuesTopNMinusOne_ReturnsArrayWithoutMinValue()
		{
			int[] inputNumbers = { 33, 2, 110, 21, 17 };
			int topCount = 4;
			int[] expected = { 110, 33, 21, 17 };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_UnsortedArrayDifferentValuesTopAll_ReturnsSameArray()
		{
			int[] inputNumbers = { 33, 2, 110, 21, 17 };
			int topCount = 5;
			int[] expected = { 33, 2, 110, 21, 17 };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_UnsortedArrayDuplicatedValuesInTopN_ReturnsArrayWithDuplicatedValues()
		{
			int[] inputNumbers = { 21, 33, 2, 110, 21, 17 };
			int topCount = 4;
			int[] expected = { 110, 33, 21, 21 };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_UnsortedArrayOneDuplicatedValueInTopN_ReturnsArrayWithUniqueValues()
		{
			int[] inputNumbers = { 21, 33, 2, 110, 21, 17 };
			int topCount = 3;
			int[] expected = { 110, 33, 21 };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_ArrayWithAllEqualValues_ReturnsArrayWithNEqualValues()
		{
			int[] inputNumbers = { 1, 1, 1, 1, 1 };
			int topCount = 2;
			int[] expected = { 1, 1 };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		public void GetTopNumbers_ArrayWithMinValueInTop_ReturnsArrayWithMinValue()
		{
			int[] inputNumbers = { Int32.MinValue, Int32.MinValue, 1, Int32.MinValue, 0 };
			int topCount = 3;
			int[] expected = { 1, 0, Int32.MinValue };
			Array array = new Array(ref inputNumbers);

			int[] actual = array.GetTop(topCount);
			CollectionAssert.AreEquivalent(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GetTopNumbers_TopCountGreaterThanArraySize_ThrowsException()
		{
			int[] inputNumbers = { 1, 2, 5, 3 };
			int topCount = 50;			
			Array array = new Array(ref inputNumbers);

			array.GetTop(topCount);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GetTopNumbers_TopCountZero_ThrowsException()
		{
			int[] inputNumbers = { 1, 2, 5, 3 };
			int topCount = 0;
			Array array = new Array(ref inputNumbers);

			array.GetTop(topCount);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void GetTopNumbers_TopCountNegative_ThrowsException()
		{
			int[] inputNumbers = { 1, 2, 5, 3 };
			int topCount = -1;
			Array array = new Array(ref inputNumbers);

			array.GetTop(topCount);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetTopNumbers_ArrayEmpty_ThrowsException()
		{
			int[] inputNumbers = {  };
			int topCount = 1;
			Array array = new Array(ref inputNumbers);

			array.GetTop(topCount);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetTopNumbers_ArrayNull_ThrowsException()
		{
			int[] inputNumbers = null;
			int topCount = 1;
			Array array = new Array(ref inputNumbers);

			array.GetTop(topCount);
		}
	}
}
