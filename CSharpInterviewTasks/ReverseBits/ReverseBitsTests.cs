using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseBits
{
	[TestClass]
	public class ReverseBitsTests
	{
		private const uint UintMax = 4294967295;
		[TestMethod]
		public void ReverseBits_InputZero_ShouldReturnZero()
		{
			uint inputNumber = 0;
			uint expected = 0;
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.ReverseNoLoop();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ReverseBits_InputMaxUint_ShouldReturnMaxUint()
		{
			uint inputNumber = UintMax;
			uint expected = UintMax;
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.ReverseNoLoop();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ReverseBits_InputLSBZero_ShouldReturnMSBZero()
		{
			uint inputNumber = UintMax - 1;	//11111111111111111111111111111110
			uint expected = 2147483647;		//01111111111111111111111111111111
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.ReverseNoLoop();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ReverseBits_InputLSBOne_ShouldReturnMSBOne()
		{
			uint inputNumber = 1;			//00000000000000000000000000000001
			uint expected = 2147483648;		//10000000000000000000000000000000
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.ReverseNoLoop();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ReverseBits_Twice_ShouldReturnOriginalNumber()
		{
			Random random = new Random();
			uint inputNumber = (uint)(random.Next(2, Int32.MaxValue));
			uint expected = inputNumber;

			UnsignedInt number = new UnsignedInt(inputNumber);
			uint reversed = number.ReverseNoLoop();

			UnsignedInt reversedNumber = new UnsignedInt(reversed);
			uint actual = reversedNumber.ReverseNoLoop();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ReverseBits_TwiceInputGreaterMaxInt_ShouldReturnOriginalNumber()
		{
			Random random = new Random();
			uint inputNumber = (uint)(UintMax - random.Next(0, Int32.MaxValue));
			uint expected = inputNumber;

			UnsignedInt number = new UnsignedInt(inputNumber);
			uint reversed = number.ReverseNoLoop();

			UnsignedInt reversedNumber = new UnsignedInt(reversed);
			uint actual = reversedNumber.ReverseNoLoop();

			Assert.AreEqual(expected, actual);
		}
	}
}
