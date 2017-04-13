using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberToText
{
	[TestClass]
	public class NumberToTextTests
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data.csv", "Data#csv", DataAccessMethod.Sequential)]
		public void NumberToText_Zero_ReturnsZero()
		{
			int numnber = Convert.ToInt32(TestContext.DataRow[0]);
			string expected = TestContext.DataRow[1].ToString();

			string actual = Number.ConvertToText(numnber);

			Assert.AreEqual(expected, actual);
		}
	}
}
