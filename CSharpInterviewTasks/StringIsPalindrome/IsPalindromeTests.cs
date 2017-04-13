using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringIsPalindrome
{
	[TestClass]
	public class IsPalindromeTests
	{
		[TestMethod]
		public void IsPalindrome_OneSymbolNoSpaces_ShouldReturnPalindrome()
		{
			string input = "a";
			MyString str = new MyString(input);
			
			Assert.IsTrue(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_OneSymbolLeadingAndTrailingSpaces_ShouldReturnPalindrome()
		{
			string input = "       a  ";
			MyString str = new MyString(input);

			Assert.IsTrue(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_ValidEvenLengthNoSpaces_ShouldReturnPalindrome()
		{
			string input = "abccba";
			MyString str = new MyString(input);

			Assert.IsTrue(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_ValidEvenLengthWithSpaces_ShouldReturnPalindrome()
		{
			string input = "ab       ccb  a    ";
			MyString str = new MyString(input);

			Assert.IsTrue(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_ValidOddLengthNoSpaces_ShouldReturnPalindrome()
		{
			string input = "toyot";
			MyString str = new MyString(input);

			Assert.IsTrue(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_ValidOddLengthWithSpaces_ShouldReturnPalindrome()
		{
			string input = "                t              oy o  t";
			MyString str = new MyString(input);

			Assert.IsTrue(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_InvalidEvenLength_ShouldNotReturnPalindrome()
		{
			string input = "abcdba";
			MyString str = new MyString(input);

			Assert.IsFalse(str.IsPalindrome());
		}

		[TestMethod]
		public void IsPalindrome_InvalidOddLength_ShouldNotReturnPalindrome()
		{
			string input = "tayot";
			MyString str = new MyString(input);

			Assert.IsFalse(str.IsPalindrome());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsPalindrome_EmptyString_ShouldThrowException()
		{
			string input = "";
			MyString str = new MyString(input);
			str.IsPalindrome();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsPalindrome_SpacesString_ShouldThrowException()
		{
			string input = "   ";
			MyString str = new MyString(input);
			str.IsPalindrome();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void IsPalindrome_NullString_ShouldThrowException()
		{
			string input = null;
			MyString str = new MyString(input);
			str.IsPalindrome();
		}
	}
}
