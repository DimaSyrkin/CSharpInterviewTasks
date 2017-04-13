using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GetNumberOfOnes
{
	[TestClass]
	public class GetNumberOfOnesTests
	{
		[TestMethod]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputOne_ShouldReturnOne()
		{
			uint inputNumber = 1;
			int expected = 1;
			Number number = new Number(inputNumber);

			int actual = number.GetNumberInSequenceWithSameNumberOfOnes();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputSequenceOneBitMSB_ShouldReturnLog2PlusOne()
		{
			uint inputNumber = 4;
			int expected = 3;
			Number number = new Number(inputNumber);

			int actual = number.GetNumberInSequenceWithSameNumberOfOnes();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputSequenceAllOnes_ShouldReturnOne()
		{
			uint inputNumber = 7;
			int expected = 1;
			Number number = new Number(inputNumber);

			int actual = number.GetNumberInSequenceWithSameNumberOfOnes();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputPowerOfTwo_ShouldReturnLog2PlusOne()
		{
			uint inputNumber = 8;
			int expected = 4;
			Number number = new Number(inputNumber);

			int actual = number.GetNumberInSequenceWithSameNumberOfOnes();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputMaxUInt_ShouldReturnOne()
		{
			uint inputNumber = 0xFFFFFFFF;
			int expected = 1;
			Number number = new Number(inputNumber);

			int actual = number.GetNumberInSequenceWithSameNumberOfOnes();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputSequenceNotAllOnes_ShouldReturn()
		{
			uint inputNumber = 6;
			int expected = 3;
			Number number = new Number(inputNumber);

			int actual = number.GetNumberInSequenceWithSameNumberOfOnes();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetNumberInSequenceWithSameNumberOfOnes_InputZero_ShouldThrowException()
		{
			uint inputNumber = 0;
			Number number = new Number(inputNumber);

			number.GetNumberInSequenceWithSameNumberOfOnes();
		}
	}
}
