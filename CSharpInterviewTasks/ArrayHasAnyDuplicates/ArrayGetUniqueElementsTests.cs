using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayUtilities
{
	[TestClass]
	public class ArrayGetUniqueElementsTests
	{
		[TestMethod]
		public void Array_SortedWithOneDuplicate_ShouldReturnArrayWithUniqueElements()
		{
			// arrange
			int[] numbers = new[] {2, 3, 5, 5, 7, 12};
			int[] expected = new[] { 2, 3, 5, 7, 12 };
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();

			// assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_SortedWithSeveralElementsDuplicated_ShouldReturnArrayWithUniqueElements()
		{
			// arrange
			int[] numbers = new[] { 2, 2, 3, 3, 5, 5, 7, 12 };
			int[] expected = new[] { 2, 3, 5, 7, 12 };
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();

			// assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_SortedAllElementsEqual_ShouldReturnArrayWithOneElement()
		{
			// arrange
			int[] numbers = new[] { 2, 2, 2, 2, 2, 2, 2, 2 };
			int[] expected = new[] { 2 };
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();

			// assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_SortedAllElementsUnique_ShouldReturnSameArray()
		{
			// arrange
			int[] numbers = new[] { 2, 20, 200, 2000 };
			int[] expected = new[] { 2, 20, 200, 2000 };
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();

			// assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Array_SortedWithOneElement_ShouldReturnArrayWithOneElement()
		{
			// arrange
			int[] numbers = new[] { 2 };
			int[] expected = new[] { 2 };
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();

			// assert
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof (InvalidOperationException))]
		public void Array_Unsorted_ShouldThrowException()
		{
			// arrange
			int[] numbers = new[] { 2, 0 };			
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Array_Empty_ShouldThrowException()
		{
			// arrange			
			int[] numbers = new int[] { };
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Array_Null_ShouldThrowException()
		{
			// arrange			
			int[] numbers = null;
			Array array = new Array(ref numbers);

			// act
			int[] actual = array.GetUniqueElements();
		}
	}
}
