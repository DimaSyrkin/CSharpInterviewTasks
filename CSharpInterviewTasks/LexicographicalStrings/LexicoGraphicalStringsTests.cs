using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LexicographicalStrings
{
	[TestClass]
	public class LexicoGraphicalStringsTests
	{
		[TestMethod]
		public void GetMinMaxLength_InputWithMultipleLexicalAndMultipleGraphicalStrings_ShouldReturmMinAndMax()
		{
			string[] inputStrings = new[] { "ab", "cvc", "an", "fre", "bd", "abfgh", "mmmm", "abexz" };
			string[] expected = new[] { "ab", "abfgh" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetMinMaxLength_InputWithSingleLexicalAndMultipleGraphicalStrings_ShouldReturmMinAndMax()
		{
			string[] inputStrings = new[] { "ba", "cvc", "an", "fre", "bd", "cfghj", "abfgh", "mmmm", "abexz", "bfghi" };
			string[] expected = new[] { "an", "cfghj" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetMinMaxLength_InputWithMultipleLexicalAndSingleGraphicalStrings_ShouldReturmMinAndMax()
		{
			string[] inputStrings = new[] { "ba", "cvc", "avn", "fre", "bdds", "cfghj", "abfgh", "mamamam", "abexz", "bfghi" };
			string[] expected = new[] { "ba", "mamamam" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetMinMaxLength_InputWithMultipleLexicalAndMultipleleGraphicalStringsMinAndMaxLength_ShouldReturmMinAndMax()
		{
			string[] inputStrings = new[] 
			{ 
				"ba", "cvc", "z", "fre", "d", "cfghj", "u", "mamamam", "abexz", "bfghi", "abcdefwnzfzdqlxzcustczqcfv",
				"abcdefiponogzxudwthrcsukni", "abcdefdmnezgtwebflgrhbvryy", "abcdefoigoufdwmjurljsxmcyo"
			};
			string[] expected = new[] { "d", "abcdefwnzfzdqlxzcustczqcfv" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetMinMaxLength_InputWithSameMinLength_ShouldReturmMinAndMaxSameLength()
		{
			string[] inputStrings = new[] 
			{ 
				"c", "v", "g", "b", "n", "m"
			};
			string[] expected = new[] { "b", "v" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetMinMaxLength_InputWithSameStrings_ShouldReturmMinAndMaxSameString()
		{
			string[] inputStrings = new[] 
			{ 
				"bbb", "bbb", "bbb", "bbb", "bbb", "bbb"
			};
			string[] expected = new[] { "bbb", "bbb" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void GetMinMaxLength_InputWithSameMaxLength_ShouldReturmMinAndMaxSameLength()
		{
			string[] inputStrings = new[] 
			{ 
				"abcdefiponogzxudwthrcsukni", "abcdefdmnezgtwebflgrhbvryy", "abcdefoigoufdwmjurljsxmcyo", "abcdwfwnzfzdqlxzcustczqcfv"
			};
			string[] expected = new[] { "abcdefdmnezgtwebflgrhbvryy", "abcdwfwnzfzdqlxzcustczqcfv" };
			StringArray array = new StringArray(ref inputStrings);

			string[] actual = array.GetMinMaxLength();
			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetMinMaxLength_InputWithEmptyString_ShouldThrowException()
		{
			string[] inputStrings = new[] 
			{ 
				"ba", "cvc", "z", "fre", "d", "cfghj", "u", "mamamam", "abexz", "bfghi", "abcdefwnzfzdqlxzcustczqcfv",
				"abcdefiponogzxudwthrcsukni", "", "abcdefdmnezgtwebflgrhbvryy", "abcdefoigoufdwmjurljsxmcyo"
			};			
			StringArray array = new StringArray(ref inputStrings);

			array.GetMinMaxLength();			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetMinMaxLength_InputWithLongerString_ShouldThrowException()
		{
			string[] inputStrings = new[] 
			{ 
				"ba", "cvc", "z", "fre", "d", "cfghj", "u", "mamamam", "abexz", "bfghi", "abcdefwnzfzdqlxzcustczqcfv",
				"abcdefiponogzxudwthfgdrgtrcsukni", "abcdefdmnezgtwebflgrhbvryy", "abcdefoigoufdwmjurljsxmcyo"
			};
			StringArray array = new StringArray(ref inputStrings);

			array.GetMinMaxLength();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetMinMaxLength_InputWithOneString_ShouldThrowException()
		{
			string[] inputStrings = new[] 
			{ 
				"abcdefoigoufdwmjurljsxmcyo"
			};
			StringArray array = new StringArray(ref inputStrings);

			array.GetMinMaxLength();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetMinMaxLength_InputEmptyArray_ShouldThrowException()
		{
			string[] inputStrings = {};
			StringArray array = new StringArray(ref inputStrings);

			array.GetMinMaxLength();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetMinMaxLength_InputNullArray_ShouldThrowException()
		{
			string[] inputStrings = null;
			StringArray array = new StringArray(ref inputStrings);

			array.GetMinMaxLength();
		}
	}
}
