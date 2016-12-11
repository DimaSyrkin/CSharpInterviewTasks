using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CleanString
{
	[TestClass]
	public class CleanStringTest
	{
		[TestMethod]
		public void Clean_OriginalLowerCaseStringContainsCleanedCharacters_ShouldReturnOriginalStringWithoutCleaned()
		{
			// arrange
			string input = "lemon";
			string cleaner = "eo";
			string expected = "lmn";

			MyString myString = new MyString(input);
			
			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void Clean_OriginalUpperCaseStringContainsCleanedCharacters_ShouldReturnOriginalStringWithoutCleaned()
		{
			// arrange
			string input = "LEMON";
			string cleaner = "EO";
			string expected = "LMN";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void Clean_BothStringsContainsLowerAndUpperCaseCharacters_ShouldReturnOriginalStringWithoutCleaned()
		{
			// arrange
			string input = "LemoN";
			string cleaner = "Lmo";
			string expected = "eN";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void Clean_OriginalStringWithMultipleOccurrencesOfCleanedChars_ShouldCleanAllOccurrences()
		{
			// arrange
			string input = "bananas";
			string cleaner = "na";
			string expected = "bs";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(expected, myString.Print());
		}

		[TestMethod]
		public void Clean_CleanerStringDoesNotContainSourceCharacters_ShouldReturnOriginalStringWithoutCleaned()
		{
			// arrange
			string input = "Lemon";
			string cleaner = "papaya";			

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(input, myString.Print());
		}

		[TestMethod]
		public void Clean_CleanerStringContainsSourceCharactersInDifferentCase_ShouldReturnOriginalStringWithoutCleaned()
		{
			// arrange
			string input = "LemOn";
			string cleaner = "MNloE";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(input, myString.Print());
		}

		[TestMethod]
		public void Clean_OriginalStringConsistsOfCleanedChars_ShouldReturnEmptyString()
		{
			// arrange
			string input = "apples";
			string cleaner = "please";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);

			// assert
			Assert.AreEqual(String.Empty, myString.Print());
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Clean_SourseStringIsNull_ShouldThrowInvalidOperationException()
		{
			// arrange
			string input = null;
			string cleaner = "any";			

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void Clean_SourseStringIsEmpty_ShouldThrowInvalidOperationException()
		{
			// arrange
			string input = "";
			string cleaner = "any";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Clean_CleanerStringIsNull_ShouldThrowArgumentException()
		{
			// arrange
			string input = "Any";
			string cleaner = null;

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Clean_CleanerStringIsEmpty_ShouldThrowArgumentException()
		{
			// arrange
			string input = "Any";
			string cleaner = "";

			MyString myString = new MyString(input);

			// act
			myString.Clean(cleaner);
		}
	}
}
