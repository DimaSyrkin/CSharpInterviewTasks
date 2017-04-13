using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCharsRepeat
{
	[TestClass]
	public class CollapseRepeatsTest
	{
		public TestContext TestContext { get; set; }

		[TestMethod]
		[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Data.csv", "Data#csv", DataAccessMethod.Sequential)]
		public void CollapseTests_ValidString_ReturnsCollapsedStringWithRepeats()
		{
			string input = TestContext.DataRow[0].ToString();
			string expected = TestContext.DataRow[1].ToString();
			CustomString customString = new CustomString(input);
			string actual = customString.Collapse();

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void CollapseTests_InvalidString_ThrowsException()
		{
			string input = "afrGde5";
			CustomString customString = new CustomString(input);
			customString.Collapse();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void CollapseTests_EmptyString_ThrowsException()
		{
			string input = "";
			CustomString customString = new CustomString(input);
			customString.Collapse();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void CollapseTests_NullString_ThrowsException()
		{
			string input = "";
			CustomString customString = new CustomString(input);
			customString.Collapse();
		}
	}
}
