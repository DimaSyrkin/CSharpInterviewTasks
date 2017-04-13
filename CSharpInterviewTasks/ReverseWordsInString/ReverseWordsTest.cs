using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ReverseWordsInString
{
	[TestClass]
	public class ReverseWordsTest
	{
		[TestMethod]
		public void ReverseWords_LatinStringWithMultipleWords_ShouldBeReversed()
		{
			// arrange
			string input = "Happy New Year";
			string expected = "Year New Happy";
			MyString myString = new MyString(input);

			// act
			myString.ReverseWords();			

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void ReverseWords_CyrillicStringWithMultipleWords_ShouldBeReversed()
		{
			// arrange
			string input = "С Новым Годом";
			string expected = "Годом Новым С";
			MyString myString = new MyString(input);

			// act
			myString.ReverseWords();

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void ReverseWords_StringWithMultipleWordsBeginsWithSpace_ShouldBeReversedWithSpace()
		{
			// arrange
			string input = " Happy New Year";
			string expected = "Year New Happy ";
			MyString myString = new MyString(input);

			// act			
			myString.ReverseWords();

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void ReverseWords_StringWithMultipleWordsEndsWithSpace_ShouldBeReversedWithSpace()
		{
			// arrange
			string input = "Happy New Year ";
			string expected = " Year New Happy";
			MyString myString = new MyString(input);

			// act			
			myString.ReverseWords();

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void ReverseWords_StringWithSingleWord_ShouldReturnSameString()
		{
			// arrange
			string input = "year";

			// act
			MyString myString = new MyString(input);
			myString.ReverseWords();

			// assert
			Assert.AreEqual(input, myString.Print());
		}

		[TestMethod]
		public void ReverseWords_StringWithSingleLetterWord_ShouldReturnSameString()
		{
			// arrange
			string input = "I";
			MyString myString = new MyString(input);

			// act
			myString.ReverseWords();

			// assert
			Assert.AreEqual(input, myString.Print());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ReverseWords_EmptyString_ShouldThrowInvalidOperationException()
		{
			// arrange
			string input = "";
			MyString myString = new MyString(input);

			// act
			myString.ReverseWords();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void ReverseWords_NullString_ShouldThrowInvalidOperationException()
		{
			// arrange
			string input = null;
			MyString myString = new MyString(input);

			// act
			myString.ReverseWords();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void ReverseWords_StringWithInvalidCharacters_ShouldThrowArgumentException()
		{
			// arrange
			string input = "Year! Month>";
			MyString myString = new MyString(input);

			// act
			myString.ReverseWords();
		}
	}
}
