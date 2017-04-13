
using System;

namespace DeckShuffle
{
	public class Deck
	{		
		public readonly int Size = 52;
		public int[] Cards { get; private set; }

		public Deck()
		{
			Cards = new int[Size];
			Init();
		}

		public void Shuffle()
		{
			MyRandom random = new MyRandom();

			for (int i = 0; i < Size - 1; i++)
			{
				int randomIndex = random.Next(i + 1, Size);
				Swap(i, randomIndex);
			}
		}

		private void Init()
		{
			for (int i = 0; i < Size; i++)
			{
				Cards[i] = i + 1;
			}
		}

		private void Swap(int firstIndex, int secondIndex)
		{
			int temp = Cards[firstIndex];
			Cards[firstIndex] = Cards[secondIndex];
			Cards[secondIndex] = temp;
		}
	}

	public class MyRandom
	{
		public int Seed;

		public MyRandom()
		{
			Seed = Environment.TickCount;
		}

		public int Next(int minValue, int maxValue)
		{
			if (maxValue < minValue)
			{
				throw new ArgumentOutOfRangeException("Random range is not valid.");
			}

			Seed += Environment.TickCount*123456789;

			if (Seed < 0)
			{
				Seed *= -1;
			}
			return Seed%(maxValue - minValue) + minValue;
		}
	}
}
