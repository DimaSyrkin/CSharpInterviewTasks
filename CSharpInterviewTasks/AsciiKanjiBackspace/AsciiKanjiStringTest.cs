using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AsciiKanjiBackspace
{
	[TestClass]
	public class AsciiKanjiStringTest
	{
		private const byte ZERO = 0x00;
		private const byte ASCII = 0x41;
		private const byte KANJI_HEAD = 0xB0;
		private const byte KANJI_TAIL_MSB_1 = 0xB1;
		private const byte KANJI_TAIL_MSB_0 = 0x30;

		[TestMethod]
		public void String_WithIndexAtSecondAndAsciiFirst_ShouldRemoveFirstByte()
		{
			// arrange
			byte[] array = {ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1};
			int index = 2;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO };			

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithTwoAsciiBeforeIndex_ShouldRemoveOneByte()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 5;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithAsciiKanjiBeforeIndex_ShouldRemoveOneByte()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 4;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithKanjiTailOneBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 5;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithKanjiTailZeroBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 5;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiHeadAndAsciiBeforeIndex_ShouldRemoveOneByte()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 6;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiHeadAndKanjiZeroBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 5;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiHeadAndKanjiOneBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 3;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiTailOneAndKanjiZeroBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII };
			int index = 6;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, ZERO, ZERO};

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiTailZeroAndKanjiZeroBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII };
			int index = 4;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiTailOneAndKanjiOneBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII };
			int index = 6;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiTailZeroAndKanjiOneBeforeIndex_ShouldRemoveTwoBytes()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII };
			int index = 4;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ASCII, ZERO, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiTailZeroAndAsciiBeforeIndex_ShouldRemoveOneByte()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 5;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		public void String_WithIndexAtKanjiTailOneAndAsciiBeforeIndex_ShouldRemoveOneByte()
		{
			// arrange
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1 };
			int index = 5;
			byte[] expected = { KANJI_HEAD, KANJI_TAIL_MSB_0, KANJI_HEAD, KANJI_TAIL_MSB_1, KANJI_HEAD, KANJI_TAIL_MSB_1, ZERO };

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);

			CollectionAssert.AreEqual(expected, array);
		}

		[TestMethod]
		[ExpectedException(typeof (InvalidOperationException))]
		public void String_Invalid_ShouldThrowInvalidOperationException()
		{
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII, KANJI_HEAD };
			int index = 2;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void String_Empty_ShouldThrowInvalidOperationException()
		{
			byte[] array = {};
			int index = 1;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void String_OneChar_ShouldThrowInvalidOperationException()
		{
			byte[] array = { ASCII };
			int index = 1;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void String_IndexAtFirstByte_ShouldThrowInvalidOperationException()
		{
			byte[] array = { ASCII, KANJI_HEAD, KANJI_TAIL_MSB_0 };
			int index = 1;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void String_IndexAtFirstKanjiTail_ShouldThrowInvalidOperationException()
		{
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII };
			int index = 2;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void String_IndexZero_ShouldThrowIndexOutOfRangeExceptionException()
		{
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII };
			int index = 0;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}

		[TestMethod]
		[ExpectedException(typeof(IndexOutOfRangeException))]
		public void String_IndexGreaterThanLength_ShouldThrowIndexOutOfRangeExceptionException()
		{
			byte[] array = { KANJI_HEAD, KANJI_TAIL_MSB_0, ASCII };
			int index = 10;

			AsciiKanjiString input = new AsciiKanjiString(ref array);
			input.Backspace(index);
		}
	}
}
