using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LowerCaseToUpperCase
{
	[TestClass]
	public class ToUpperTests
	{
		[TestMethod]
		public void ToUpper_StringWithLowerAndUpperCase_ShouldConvertLowerToUpper()
		{
			// arrange
			string s = @"паРаПАрамЯя";
			string expected = @"ПАРАПАРАМЯЯ";
			// act
			MyString myString = new MyString(s);
			string actual = myString.ToUpper();

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUpper_StringWithLowerCaseOnly_ShouldConvertAllToUpper()
		{
			// arrange
			string s = @"армия";
			string expected = @"АРМИЯ";
			// act
			MyString myString = new MyString(s);
			string actual = myString.ToUpper();

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void ToUpper_StringWithUpperCaseOnly_ShouldReturnTheSameString()
		{
			// arrange
			string s = @"АРМИЯ";
			
			// act
			MyString myString = new MyString(s);
			string actual = myString.ToUpper();

			// assert
			Assert.AreEqual(s, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ToUpper_EmptyString_ShouldThrowException()
		{
			// arrange
			string s = @"";

			// act
			MyString myString = new MyString(s);
			string actual = myString.ToUpper();			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ToUpper_NullString_ShouldThrowException()
		{
			// arrange
			string s = null;

			// act
			MyString myString = new MyString(s);
			string actual = myString.ToUpper();
		}
	}
}
