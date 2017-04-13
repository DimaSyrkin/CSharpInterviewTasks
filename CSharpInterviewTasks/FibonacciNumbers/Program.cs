using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FibonacciNumbers
{
	class Program
	{
		/// <summary>
		/// Write a program that prints Fibonacci series up to N number.
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			Fibonacci.SetTestMode(true);
			Fibonacci.Print(47);
			//Fibonacci.Print(0);
		}
	}
}
