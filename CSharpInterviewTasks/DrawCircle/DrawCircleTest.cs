using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawCircle
{
	[TestClass]
	public class DrawCircleTest
	{
		[TestMethod]
		public void Circle_WithValidEvenRadius_ShouldBeDrawn()
		{			
			char[,] expected = new char[,]
			{
				{ ' ', ' ', '.', ' ', ' ' }, 
				{ ' ', '.', '.', '.', ' ' }, 
				{ '.', '.', '.', '.', '.' }, 
				{ ' ', '.', '.', '.', ' ' }, 
				{ ' ', ' ', '.', ' ', ' ' }
			};
		

			Circle circle = new Circle(2);
			char[,] actual = circle.Draw();

			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Circle_WithValidOddRadius_ShouldBeDrawn()
		{
			char[,] expected = new char[,]
			{
				{ ' ', ' ', ' ', '.', ' ', ' ', ' ' }, 
				{ ' ', '.', '.', '.', '.', '.', ' ' }, 
				{ ' ', '.', '.', '.', '.', '.', ' ' }, 
				{ '.', '.', '.', '.', '.', '.', '.' }, 
				{ ' ', '.', '.', '.', '.', '.', ' ' }, 
				{ ' ', '.', '.', '.', '.', '.', ' ' }, 
				{ ' ', ' ', ' ', '.', ' ', ' ', ' ' }, 
			};


			Circle circle = new Circle(3);
			char[,] actual = circle.Draw();

			CollectionAssert.AreEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Circle_WithZeroRadius_ShouldNotBeDrawn()
		{
			Circle circle = new Circle(0);
			char[,] actual = circle.Draw();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Circle_WithNegativeRadius_ShouldNotBeDrawn()
		{
			Circle circle = new Circle(-1);
			char[,] actual = circle.Draw();
		}
	}
}
