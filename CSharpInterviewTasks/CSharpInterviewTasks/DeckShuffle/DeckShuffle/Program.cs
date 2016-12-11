using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeckShuffle
{
	/// <summary>
	/// Write an efficient algorithm to shuffle a pack of cards this one was a feedback process until we came up with one with no extra storage. 
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			
			Deck deck = new Deck();
			int[] initial = new int[deck.Size];
			for (int i = 0; i < deck.Size; i++)
			{
				initial[i] = deck.Cards[i];
			}

			deck.Shuffle();

			for (int i = 0; i < deck.Size; i++)
			{
				Console.WriteLine("{0} - {1}", initial[i], deck.Cards[i]);
			}					
		}
	}
}
