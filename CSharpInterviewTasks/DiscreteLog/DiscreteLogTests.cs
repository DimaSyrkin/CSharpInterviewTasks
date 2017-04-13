
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscreteLog
{
	[TestClass]
	public class DiscreteLogTests
	{
		[TestMethod]
		public void DiscreteLog_BinaryInputOne_ShouldReturnZero()
		{
			uint input = 1;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 0;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);
			
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_RoundInputOne_ShouldReturnZero()
		{
			uint input = 1;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 0;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_BinaryInputNoRound_ShouldReturnIntNoRound()
		{
			uint input = 128;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 7;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_RoundInputNoRound_ShouldReturnIntNoRound()
		{
			uint input = 128;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 7;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_BinaryInputMaxIntNoRound_ShouldReturn31()
		{
			uint input = 0x80000000;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 31;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_RoundInputMaxIntNoRound_ShouldReturn31()
		{
			uint input = 0x80000000;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 31;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_BinaryInputLessThenHalf_ShouldReturnRoundedToLower()
		{
			uint input = 90;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 6;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_RoundInputLessThenHalf_ShouldReturnRoundedToLower()
		{
			uint input = 90;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 6;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_BinaryInputGreaterThenHalf_ShouldReturnRoundedToLower()
		{
			uint input = 91;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 6;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_RoundInputGreaterThenHalf_ShouldReturnRoundedToHigher()
		{
			uint input = 91;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 7;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_BinaryInputMaxUint_ShouldReturn31()
		{
			uint input = 0xFFFFFFFF;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 31;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void DiscreteLog_RoundInputMaxUint_ShouldReturn32()
		{
			uint input = 0xFFFFFFFF;
			UnsignedInt number = new UnsignedInt(input);
			int expected = 32;

			int actual = number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void DiscreteLog_BinaryInputZero_ShouldThrowException()
		{
			uint input = 0;
			UnsignedInt number = new UnsignedInt(input);			

			number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Binary);			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void DiscreteLog_RoundInputZero_ShouldThrowException()
		{
			uint input = 0;
			UnsignedInt number = new UnsignedInt(input);

			number.DiscreteLog(UnsignedInt.DiscreteLogCalculation.Round);			
		}
	}
}
