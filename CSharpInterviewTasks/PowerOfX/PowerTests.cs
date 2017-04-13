using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerOfX
{
	[TestClass]
	public class PowerTests
	{
		[TestMethod]
		public void Power_XZeroYValid_RetunsZero()
		{
			int x = 0;
			uint y = 2;
			int expected = 0;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XOneYValid_RetunsOne()
		{
			int x = 1;
			uint y = 22;
			int expected = 1;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XValidYZero_RetunsOne()
		{
			int x = 10;
			uint y = 0;
			int expected = 1;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XPositiveIntYPositiveIntOdd_RetunsPowerOfX()
		{
			int x = 3;
			uint y = 5;
			int expected = 243;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XPositiveIntYPositiveIntEven_RetunsPowerOfX()
		{
			int x = 3;
			uint y = 4;
			int expected = 81;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XMinusOneIntYPositiveIntEven_RetunsOne()
		{
			int x = -1;
			uint y = 4;
			int expected = 1;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XMinusOneIntYPositiveIntOdd_RetunsMinusOne()
		{
			int x = -1;
			uint y = 99;
			int expected = -1;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XNegativeIntYPositiveIntOdd_RetunsPowerOfXNegative()
		{
			int x = -3;
			uint y = 5;
			int expected = -243;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XNegativeIntYPositiveIntEven_RetunsPowerOfXPositive()
		{
			int x = -3;
			uint y = 4;
			int expected = 81;

			int actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Power_XPositiveDoubleYPositiveOdd_RetunsPowerOfX()
		{
			double x = 3;
			int y = -5;
			double expected = 0.00411d;

			double actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual, 0.00001);
		}

		[TestMethod]
		public void Power_XPositiveDoubleYNegativeEven_RetunsPowerOfX()
		{
			double x = 3;
			int y = -4;
			double expected = 0.012345d;

			double actual = MathOperations.Power(x, y);
			Assert.AreEqual(expected, actual, 0.00001);
		}

		//// TODO: Tests with float X, Overflow tests
	}
}
