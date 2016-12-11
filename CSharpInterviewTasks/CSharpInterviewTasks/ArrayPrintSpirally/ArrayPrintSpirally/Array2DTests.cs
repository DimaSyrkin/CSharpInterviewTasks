using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayPrintSpirally
{
	[TestClass]
	public class Array2DTests
	{
		[TestMethod]
		public void PrintSpirally_RectangularArray4x5_ShouldBePrinted()
		{
			// arrange
			int[] expected = {1, 2, 3, 4, 5, 10, 15, 20, 19, 18, 17, 16, 11, 6, 7, 8, 9, 14, 13, 12};
			const int BOTTOM = 4;
			const int RIGHT = 5;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 }, { 11, 12, 13, 14, 15 }, { 16, 17, 18, 19, 20 } };
			Array2D array2D = new Array2D(ref array, RIGHT, BOTTOM);
			
			// act
			array2D.PrintSpirally();
			
			// assert
			CollectionAssert.AreEqual(expected, array2D.PrintedValues);
		}

		[TestMethod]
		public void PrintSpirally_RectangularArray5x4_ShouldBePrinted()
		{
			// arrange
			int[] expected = { 1, 2, 3, 4, 8, 12, 16, 20, 19, 18, 17, 13, 9, 5, 6, 7, 11, 15, 14, 10 };
			const int BOTTOM = 5;
			const int RIGHT = 4;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 }, {17, 18, 19, 20} };
			Array2D array2D = new Array2D(ref array, RIGHT, BOTTOM);

			// act
			array2D.PrintSpirally();

			// assert
			CollectionAssert.AreEqual(expected, array2D.PrintedValues);
		}

		[TestMethod]
		public void PrintSpirally_SquareArray3x3_ShouldBePrinted()
		{
			// arrange
			int[] expected = { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
			const int SIZE = 3;
			int[,] array = new int[SIZE, SIZE] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9} };
			Array2D array2D = new Array2D(ref array, SIZE, SIZE);

			// act
			array2D.PrintSpirally();

			// assert
			CollectionAssert.AreEqual(expected, array2D.PrintedValues);
		}

		[TestMethod]
		public void PrintSpirally_SquareArray2x2_ShouldBePrinted()
		{
			// arrange
			int[] expected = { 1, 2, 4, 3 };
			const int SIZE = 2;
			int[,] array = new int[SIZE, SIZE] { { 1, 2 }, { 3, 4 } };
			Array2D array2D = new Array2D(ref array, SIZE, SIZE);

			// act
			array2D.PrintSpirally();

			// assert
			CollectionAssert.AreEqual(expected, array2D.PrintedValues);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_SingleDimensionalArray1x2_ShouldThrowException()
		{
			// arrange			
			const int BOTTOM = 1;
			const int RIGHT = 2;
			int[,] array = new int[BOTTOM, RIGHT] { {1, 2} };
			Array2D array2D = new Array2D(ref array, RIGHT, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_SingleDimensionalArray2x1_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 1;
			int[,] array = new int[BOTTOM, RIGHT] { {1}, {2} };
			Array2D array2D = new Array2D(ref array, RIGHT, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_SingleDimensionalArray1x1_ShouldThrowException()
		{
			// arrange
			const int SIZE = 1;			
			int[,] array = new int[SIZE, SIZE] { { 1 } };
			Array2D array2D = new Array2D(ref array, SIZE, SIZE);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_NullArray_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = null;
			Array2D array2D = new Array2D(ref array, RIGHT, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_EmptyArray_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[,] {};
			Array2D array2D = new Array2D(ref array, RIGHT, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_HorizontalBoundIsZero_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[BOTTOM, RIGHT] { {1, 2, 3}, {4, 5, 6} };
			Array2D array2D = new Array2D(ref array, 0, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_HorizontalBoundIsNegative_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3 }, { 4, 5, 6 } };
			Array2D array2D = new Array2D(ref array, -1, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_VerticalBoundIsZero_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3 }, { 4, 5, 6 } };
			Array2D array2D = new Array2D(ref array, RIGHT, 0);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_VerticalBoundIsNegative_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3 }, { 4, 5, 6 } };
			Array2D array2D = new Array2D(ref array, RIGHT, -1);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_HorizontalBoundIsGreaterThanArraySize_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3 }, { 4, 5, 6 } };
			Array2D array2D = new Array2D(ref array, 4, BOTTOM);

			// act
			array2D.PrintSpirally();
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void PrintSpirally_VerticalBoundIsGreaterThanArraySize_ShouldThrowException()
		{
			// arrange
			const int BOTTOM = 2;
			const int RIGHT = 3;
			int[,] array = new int[BOTTOM, RIGHT] { { 1, 2, 3 }, { 4, 5, 6 } };
			Array2D array2D = new Array2D(ref array, RIGHT, 3);

			// act
			array2D.PrintSpirally();
		}
	}
}
