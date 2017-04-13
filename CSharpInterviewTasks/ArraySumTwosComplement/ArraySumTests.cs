using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArraySumTwosComplement
{
	[TestClass]
	public class ArraySumTests
	{
		[TestMethod]
		public void Sum_NotOverflowMin_ShouldBeCalculated()
		{
			uint[] inputNumbers = { 0, 0, 0 };
			uint expectedSum = 0;
			Array array = new Array(ref inputNumbers);

			uint actualSum = array.Sum();

			Assert.AreEqual(expectedSum, actualSum);
		}

		[TestMethod]
		public void Sum_NotOverflowMax_ShouldBeCalculated()
		{
			uint[] inputNumbers = { 1, 0, 0xFFFFFFFE };
			uint expectedSum = 0xFFFFFFFF;
			Array array = new Array(ref inputNumbers);

			uint actualSum = array.Sum();

			Assert.AreEqual(expectedSum, actualSum);
		}

		[TestMethod]
		[ExpectedException(typeof(OverflowException))]
		public void Sum_Overflow_ShouldThrowException()
		{
			uint[] inputNumbers = { 1, 1, 0xFFFFFFFE };			
			Array array = new Array(ref inputNumbers);

			uint actualSum = array.Sum();			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sum_ArrayEmpty_ShouldThrowException()
		{
			uint[] inputNumbers = { };
			Array array = new Array(ref inputNumbers);

			uint actualSum = array.Sum();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Sum_ArrayNull_ShouldThrowException()
		{
			uint[] inputNumbers = null;
			Array array = new Array(ref inputNumbers);

			uint actualSum = array.Sum();
		}
	}
}
