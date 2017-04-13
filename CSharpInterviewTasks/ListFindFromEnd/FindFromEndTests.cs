using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListFindFromEnd
{
	[TestClass]
	public class FindFromEndTests
	{
		private static LinkedList _validLinkedListManyElements = new LinkedList();
		private static LinkedList _linkedListOneElement = new LinkedList();
		private static LinkedList _emptyList = new LinkedList();
		private static LinkedList _nullList = null;

		[ClassInitialize]
		public static void InitializeTestData(TestContext context)
		{
			_validLinkedListManyElements.Add(10);
			_validLinkedListManyElements.Add(20);
			_validLinkedListManyElements.Add(30);
			_validLinkedListManyElements.Add(40);
			_validLinkedListManyElements.Add(50);
			_validLinkedListManyElements.Add(60);
			_linkedListOneElement.Add(1);
		}

		[TestMethod]
		public void FindFromEnd_ValidListManyFindTop_ReturnsLastElement()
		{
			int expected = 60;
			int position = 1;

			int actual = _validLinkedListManyElements.FindFromEnd(position);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FindFromEnd_ValidListManyFindMiddle_ReturnsMiddleElement()
		{
			int expected = 40;
			int position = 3;

			int actual = _validLinkedListManyElements.FindFromEnd(position);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FindFromEnd_ValidListManyFindBottom_ReturnsLastElement()
		{
			int expected = 10;
			int position = 6;

			int actual = _validLinkedListManyElements.FindFromEnd(position);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void FindFromEnd_ValidListOneElement_ReturnsHead()
		{
			int expected = 1;
			int position = 1;

			int actual = _linkedListOneElement.FindFromEnd(position);

			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void FindFromEnd_ValidListPositionZero_ThrowsException()
		{
			_linkedListOneElement.FindFromEnd(0);			
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentOutOfRangeException))]
		public void FindFromEnd_ValidListPositionGreaterThanSize_ThrowsException()
		{
			int position = _validLinkedListManyElements.Count + 1;
			_validLinkedListManyElements.FindFromEnd(position);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void FindFromEnd_EmptyList_ThrowsException()
		{			
			_emptyList.FindFromEnd(1);
		}
	}
}
