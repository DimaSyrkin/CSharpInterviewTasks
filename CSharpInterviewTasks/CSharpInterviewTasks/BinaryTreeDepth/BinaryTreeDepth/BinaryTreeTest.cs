using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryTreeDepth
{
	[TestClass]
	public class BinaryTreeTest
	{
		[TestMethod]
		public void Tree_WithOneNode_ShouldReturnOne()
		{
			// arrange
			int expectedDeplth = 1;
			BinaryTree tree = new BinaryTree(25);

			// act
			int actualDepth = tree.GetDepth();

			// assert
			Assert.AreEqual(expectedDeplth, actualDepth);
		}

		[TestMethod]
		public void Tree_Empty_ShouldReturnZero()
		{
			// arrange
			int expectedDeplth = 0;
			BinaryTree tree = new BinaryTree();

			// act
			int actualDepth = tree.GetDepth();

			// assert
			Assert.AreEqual(expectedDeplth, actualDepth);
		}

		// TODO: Create a better name
		[TestMethod]
		public void Tree_Symmetric_ShouldReturn()
		{			
			// arrange
			int expectedDeplth = 2;
			BinaryTree tree = new BinaryTree(25);
			tree.Insert(20);
			tree.Insert(30);

			// act
			int actualDepth = tree.GetDepth();

			// assert
			Assert.AreEqual(expectedDeplth, actualDepth);
		}

		// TODO: Create a better name
		[TestMethod]
		public void Tree_LongestLeft_ShouldReturnLeftDepth()
		{
			// arrange
			int expectedDeplth = 4;
			BinaryTree tree = new BinaryTree(25);
			tree.Insert(20);
			tree.Insert(30);
			tree.Insert(10);
			tree.Insert(15);
			tree.Insert(25);
			tree.Insert(50);

			// act
			int actualDepth = tree.GetDepth();

			// assert
			Assert.AreEqual(expectedDeplth, actualDepth);
		}

		// TODO: Create a better name
		[TestMethod]
		public void Tree_LongestRight_ShouldReturnRightDepth()
		{
			// arrange
			int expectedDeplth = 5;
			BinaryTree tree = new BinaryTree(25);
			tree.Insert(20);
			tree.Insert(30);
			tree.Insert(10);
			tree.Insert(35);
			tree.Insert(25);
			tree.Insert(50);
			tree.Insert(40);

			// act
			int actualDepth = tree.GetDepth();

			// assert
			Assert.AreEqual(expectedDeplth, actualDepth);
		}
	}
}
