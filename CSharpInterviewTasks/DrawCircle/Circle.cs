using System;

namespace DrawCircle
{
	public class Circle
	{
		private int _radius;

		/// <summary>
		/// Initializes a circle
		/// </summary>
		/// <param name="radius">The circle radius.</param>
		public Circle(int radius)
		{
			// TODO: Figure out if zero radius considered as a circle
			// TODO: Figure out the "exception" behavior
			if (radius <= 0)
			{
				throw new ArgumentException("Radius value is invalid. Make sure radius is greater than 0");
			}

			_radius = radius;
		}

		/// <summary>
		/// "Draws" a circle
		///  </summary>
		/// <returns>Array of dots and spaces to draw a pseudo-graphic circle.</returns>
		public char[,] Draw()
		{
			int size = 2 * _radius + 1;
			char [,] marks = new char[size, size];

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					int x = i - _radius;
					int y = j - _radius;
					Point point = new Point(x, y);
					marks[i, j] = Contains(point) ? '.' : ' ';
				}				
			}

			return marks;			
		}

		/// <summary>
		/// Draws a circle in console. Implemented for test purposes.
		/// </summary>
		public void DrawInConsole()
		{
			char[,] squareText = Draw();
			int size = 2 * _radius + 1;

			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					Console.Write(squareText[i,j]);
				}
				Console.WriteLine("");
			}
		}

		/// <summary>
		/// Checks whether circle contains a point or not
		/// </summary>
		/// <param name="point">An instance of <see cref="Point"/> object</param>
		/// <returns>True/False</returns>
		private bool Contains(Point point)
		{
			return (point.X * point.X + point.Y * point.Y) <= (_radius * _radius);
		}
	}
}
