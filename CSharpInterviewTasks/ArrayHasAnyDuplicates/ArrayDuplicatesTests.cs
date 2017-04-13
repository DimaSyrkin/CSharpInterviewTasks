using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayUtilities
{
	[TestClass]
	public class ArrayDuplicatesTests
	{
		[TestMethod]
		public void HasDuplicates_ArrayWithOneDuplicate_ShouldReturnTrue()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3, 3 };			
			Array array = new Array(ref arr);
			
			// act
			bool hasDuplicates = array.HasDuplicates();

			// assert
			Assert.IsTrue(hasDuplicates);
		}


		[TestMethod]
		public void HasDuplicates_ArrayWithMultipleOccurrencesOfMultipleValues_ShouldReturnTrue()
		{
			// arrange
			int[] arr = new int[] { 1, 3, 3, 4, 4, 4 };			
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();

			// assert
			Assert.IsTrue(hasDuplicates);
		}

		[TestMethod]
		public void HasDuplicates_ArrayWithMultipleOccurrenceOfOneValue_ShouldReturnTrue()
		{
			// arrange
			int[] arr = new int[] { 1, 3, 4, 5, 5, 5, 5, 5, 9 };			
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();

			// assert
			Assert.IsTrue(hasDuplicates);
		}

		[TestMethod]
		public void HasDuplicates_ArrayWithAllEqualNumbers_ShouldReturnTrue()
		{
			// arrange
			int[] arr = new int[] { 2, 2, 2 };
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();

			// assert
			Assert.IsTrue(hasDuplicates);
		}

		[TestMethod]
		public void HasDuplicates_ArrayWithoutDuplicates_ShouldReturnFalse()
		{
			// arrange
			int[] arr = new int[] { 1, 2, 3 };			
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();

			// assert
			Assert.IsFalse(hasDuplicates);
		}

		[TestMethod]
		public void HasDuplicates_ArrayWithSingleElement_ShouldReturnFalse()
		{
			// arrange
			int[] arr = new int[] { 1 };
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();

			// assert
			Assert.IsFalse(hasDuplicates);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void HasDuplicates_EmptyArray_ShouldNotReturnResult()
		{
			// arrange			
			int[] arr = new int[] { };
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void HasDuplicates_NullArray_ShouldNotReturnResult()
		{
			// arrange
			int[] arr = null;
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void HasDuplicates_ArrayWithNumbersLessThanOne_ShouldNotReturnResult()
		{
			// arrange
			int[] arr = {-1, 0, 2, 2, 4};
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void HasDuplicates_ArrayWithNumbersGreaterThanSize_ShouldNotReturnResult()
		{
			// arrange
			int[] arr = { 1, 2, 2, 5 };
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void HasDuplicates_ArrayUnsorted_ShouldNotReturnResult()
		{
			// arrange
			int[] arr = { 2, 2, 4, 1 };
			Array array = new Array(ref arr);

			// act
			bool hasDuplicates = array.HasDuplicates();
		}
	}
}
