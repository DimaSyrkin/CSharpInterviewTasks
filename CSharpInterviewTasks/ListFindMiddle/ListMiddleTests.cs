using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListFindMiddle
{
	[TestClass]
	public class ListMiddleTests
	{
		[TestMethod]
		public void List_SizeEven_ReturnsMiddleElement()
		{
			int expected = 20;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);

			int actual = list.GetMiddle();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void List_SizeOdd_ReturnsMiddleElement()
		{
			int expected = 20;
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);

			int actual = list.GetMiddle();
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof (InvalidOperationException))]
		public void List_OneElement_ShouldThrowException()
		{			
			LinkedList list = new LinkedList();
			list.Add(10);

			list.GetMiddle();
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void List_Empty_ShouldThrowException()
		{
			LinkedList list = new LinkedList();			

			list.GetMiddle();
		}
	}
}
