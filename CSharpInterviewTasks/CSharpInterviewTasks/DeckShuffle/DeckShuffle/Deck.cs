
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
			Random random = new Random();
			/*
			for (int i = _size - 1; i >= 0; i--)
			{
				int randomIndex = random.Next(i + 1);
				Swap(randomIndex, i);
			}
			*/

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
}
