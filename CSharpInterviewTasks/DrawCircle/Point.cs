using System;

namespace DrawCircle
{
	internal class Point
	{
		/// <summary>
		/// Gets or sets the X coordinate
		/// </summary>
		public int X { get; private set; }

		/// <summary>
		/// Gets or sets the Y coordinate
		/// </summary>
		public int Y { get; private set; }

		/// <summary>
		/// Initializes a new object
		/// </summary>
		/// <param name="x">value of X coordinate.</param>
		/// <param name="y">value of X coordinate.</param>
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
