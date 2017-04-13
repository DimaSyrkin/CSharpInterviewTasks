using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciNumbers
{
	[TestClass]
	public class FibonacciTests
	{
		[ClassInitialize]
		public static void SetupTests(TestContext context)
		{
			Fibonacci.SetTestMode(true);
		}

		[TestMethod]
		public void Print_OneNumber_ShouldPrintZero()
		{
			uint[] expected = new uint[] {0};
			Fibonacci.Print(0);
			CollectionAssert.AreEqual(expected, Fibonacci.Numbers);
		}

		[TestMethod]
		public void Print_TwoNumbers_ShouldPrintZeroAndOne()
		{
			uint[] expected = new uint[] { 0, 1 };
			Fibonacci.Print(1);
			CollectionAssert.AreEqual(expected, Fibonacci.Numbers);
		}

		[TestMethod]
		public void Print_MaxNumbers_ShouldPrint48Numbers()
		{			
			Fibonacci.Print(47);
			Assert.AreEqual(48, Fibonacci.Numbers.Length);
			Assert.AreEqual((uint)0, Fibonacci.Numbers[0]);
			Assert.AreEqual(2971215073, Fibonacci.Numbers[47]);			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Print_OverMaxNumbers_ShouldThrowException()
		{
			Fibonacci.Print(48);
		}

		[ClassCleanup]
		public static void CleanupTests()
		{
			Fibonacci.SetTestMode(false);
		}
	}
}
