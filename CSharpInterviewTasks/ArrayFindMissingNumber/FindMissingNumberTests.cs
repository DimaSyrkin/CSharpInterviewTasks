using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayFindMissingNumber
{
	[TestClass]
	public class FindMissingNumberTests
	{
		[TestMethod]
		public void FindMissingNumber_FirstMissing_ReturnsOne()
		{
			int missingNumber = 1;
			int[] numbers = Array.Generate(1, 100, missingNumber);
			int actualSum = Array.FindMissingNumber(numbers, Array.FindStrategy.Sum);
			int actualXor = Array.FindMissingNumber(numbers, Array.FindStrategy.Xor);

			Assert.AreEqual(actualSum, missingNumber);
			Assert.AreEqual(actualXor, missingNumber);
		}

		[TestMethod]
		public void FindMissingNumber_LastMissing_Returns100()
		{
			int missingNumber = 100;
			int[] numbers = Array.Generate(1, 100, missingNumber);
			int actualSum = Array.FindMissingNumber(numbers, Array.FindStrategy.Sum);
			int actualXor = Array.FindMissingNumber(numbers, Array.FindStrategy.Xor);

			Assert.AreEqual(actualSum, missingNumber);
			Assert.AreEqual(actualXor, missingNumber);
		}

		[TestMethod]
		public void FindMissingNumber_MiddleMissing_ReturnsMiddle()
		{
			int missingNumber = 50;
			int[] numbers = Array.Generate(1, 100, missingNumber);
			int actualSum = Array.FindMissingNumber(numbers, Array.FindStrategy.Sum);
			int actualXor = Array.FindMissingNumber(numbers, Array.FindStrategy.Xor);

			Assert.AreEqual(actualSum, missingNumber);
			Assert.AreEqual(actualXor, missingNumber);
		}
	}
}
