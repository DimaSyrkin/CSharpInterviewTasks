using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ListFindMiddle
{
	[TestClass]
	public class ListLoopTests
	{
		[TestMethod]
		public void List_WithoutLoopOneElement_ShoudReturnFalse()
		{
			// arrange
			LinkedList list = new LinkedList();
			list.Add(10);			

			// act
			bool hasLoop = list.HasLoop();

			// assert
			Assert.IsFalse(hasLoop);
		}
		[TestMethod]
		public void List_WithoutLoopSeveralElements_ShoudReturnFalse()
		{
			// arrange
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);
			
			// act
			bool hasLoop = list.HasLoop();

			// assert
			Assert.IsFalse(hasLoop);
		}

		[TestMethod]
		public void List_WithLoopToHead_ShoudReturnTrue()
		{
			// arrange
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);
			list.LoopTo(10);

			// act			
			bool hasLoop = list.HasLoop();

			// assert
			Assert.IsTrue(hasLoop);
		}

		[TestMethod]
		public void List_WithLoopToTail_ShoudReturnTrue()
		{
			// arrange
			LinkedList list = new LinkedList();
			list.Add(10);
			list.Add(20);
			list.Add(30);
			list.LoopTo(30);

			bool hasLoop = list.HasLoop();

			// assert
			Assert.IsTrue(hasLoop);
		}

		[TestMethod]
		public void List_WithHeadLooped_ShoudReturnTrue()
		{
			// arrange
			LinkedList list = new LinkedList();
			list.Add(10);
			list.LoopTo(10);

			bool hasLoop = list.HasLoop();

			// assert
			Assert.IsTrue(hasLoop);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void List_Empty_ShoudThrowException()
		{
			// arrange
			LinkedList list = new LinkedList();

			list.HasLoop();
		}
	}
}
