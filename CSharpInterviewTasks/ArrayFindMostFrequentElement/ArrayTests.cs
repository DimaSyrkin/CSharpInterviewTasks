using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayFindMostFrequentElement
{
	[TestClass]
	public class ArrayTests
	{
		private const int VALUE_IF_NOT_FOUND = -1;

		[TestMethod]
		public void Array_LengthOne_ShouldReturnFirstElement()
		{
			int[] input = {1};
			int expected = 1;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_LengthTwoElementsEqual_ShouldReturnElement()
		{
			int[] input = { 2, 2 };
			int expected = 2;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_LengthTwoElementsNotEqual_ShouldNotFindElement()
		{
			int[] input = { 1, 2 };
			int expected = VALUE_IF_NOT_FOUND;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_LengthEvenMaxOccurredMoreThanHalf_ShouldReturnElement()
		{
			int[] input = { 3, 2, 4, 2, 2, 2 };
			int expected = 2;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_LengthOddMaxOccurredMoreThanHalf_ShouldReturnElement()
		{
			int[] input = { 3, 2, 4, 2, 2, 2, 0 };
			int expected = 2;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_LengthEvenMaxOccurredHalf_ShouldNotFindElement()
		{
			int[] input = { 3, 2, 3, 3, 2, 2 };
			int expected = VALUE_IF_NOT_FOUND;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_LengthOddMaxOccurredLessThanHalf_ShouldNotFindElement()
		{
			int[] input = { 3, 2, 3, 3, 1, 2, 2 };
			int expected = VALUE_IF_NOT_FOUND;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_AllElementsDifferent_ShouldNotFindElement()
		{
			int[] input = { 1, 2, 4, 0, 5, 3, 6 };
			int expected = VALUE_IF_NOT_FOUND;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_MaxOccurredMoreThanHalfOccurrencesFromLeft_ShouldReturnElement()
		{
			int[] input = { 2, 2, 2, 2, 0, 1, 3 };
			int expected = 2;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_MaxOccurredMoreThanHalfOccurrencesFromRight_ShouldReturnElement()
		{
			int[] input = { 0, 1, 3, 2, 2, 2, 2 };
			int expected = 2;

			MyArray array = new MyArray(ref input);
			int actual = array.FindElementOccurredMoreThanHalf();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof (InvalidOperationException))]
		public void Array_Empty_ShouldThrowException()
		{
			int[] input = { };			

			MyArray array = new MyArray(ref input);
			array.FindElementOccurredMoreThanHalf();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Array_Null_ShouldThrowException()
		{
			int[] input = null;

			MyArray array = new MyArray(ref input);
			array.FindElementOccurredMoreThanHalf();
		}

	}
}
