using System;

namespace DrawCircle
{
	/// <summary>
	/// 40.	Write a routine to draw a circle (x ** 2 + y ** 2 = r ** 2) without making use of any floating point computations at all.
	/// </summary>
	class DrawCircle
	{
		static void Main(string[] args)
		{
			try
			{
				Circle circle = new Circle(3);
				circle.DrawInConsole();
			}
			catch (ArgumentException e)
			{
				Console.WriteLine(e.Message);
			}
		}
	}
}
