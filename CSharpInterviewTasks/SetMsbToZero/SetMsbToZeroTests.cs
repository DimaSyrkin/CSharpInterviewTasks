using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SetMsbToZero
{
	[TestClass]
	public class SetMsbToZeroTests
	{
		[TestMethod]
		public void SetMsbToZero_ValueLowestMsbOne_ShouldReturnZero()
		{
			uint inputNumber = 0x80000000;
			uint expected = 0;
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.SetMsbToZero();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SetMsbToZero_ValueLowestMsbOnePlusOne_ShouldReturnOne()
		{
			uint inputNumber = 0x80000001;
			uint expected = 1;
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.SetMsbToZero();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void SetMsbToZero_ValueMaxUInt_ShouldReturnOne()
		{
			uint inputNumber =	0xFFFFFFFF;
			uint expected =		0x7FFFFFFF;
			UnsignedInt number = new UnsignedInt(inputNumber);

			uint actual = number.SetMsbToZero();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SetMsbToZero_ValueZero_ShouldThrowException()
		{
			uint inputNumber = 0;			
			UnsignedInt number = new UnsignedInt(inputNumber);

			number.SetMsbToZero();			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SetMsbToZero_ValueHighestMsbZero_ShouldThrowException()
		{
			uint inputNumber = 0x7FFFFFFF;
			UnsignedInt number = new UnsignedInt(inputNumber);

			number.SetMsbToZero();
		}
	}
}
