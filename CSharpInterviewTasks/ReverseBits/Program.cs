using System;

namespace ReverseBits
{
	class Program
	{
		static void Main(string[] args)
		{
			for (int i = 0; i < 100; i++)
			{
				UnsignedInt number = new UnsignedInt((uint)i);
				Console.WriteLine("{0} - {1}", i, number.Reverse());
			}

			UnsignedInt max = new UnsignedInt(2147483648);
			Console.WriteLine(max.Reverse());
		}
	}
}
