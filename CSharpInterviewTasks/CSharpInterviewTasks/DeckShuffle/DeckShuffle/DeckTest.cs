
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeckShuffle
{
	[TestClass]
	public class DeckTest
	{
		// Note: Exceptions and negative cases are not covered due to "hard-coded" Card implementation
		[TestMethod]
		public void ShuffleDeck_SingleShuffle_ShouldChangeCardsPosition()
		{
			// arrange
			Deck deck = new Deck();
			int[] initial = new int[deck.Size];
			for (int i = 0; i < deck.Size; i++)
			{
				initial[i] = deck.Cards[i];
			}
			
			// act
			deck.Shuffle();

			// assert
			for (int i = 0; i < deck.Size; i++)
			{
				Assert.AreNotEqual(initial[i], deck.Cards[i], "Cards are equal at the position {0}", i + 1);
			}

			CollectionAssert.AllItemsAreUnique(deck.Cards);
		}

		[TestMethod]
		public void ShuffleDeck_MultipleShuffles_ShouldChangeCardsPosition()
		{
			// arrange
			Deck deck = new Deck();
			int[] initial = new int[deck.Size];
			deck.Shuffle();
			deck.Shuffle();
			deck.Shuffle();

			for (int i = 0; i < deck.Size; i++)
			{
				initial[i] = deck.Cards[i];
			}

			// act
			deck.Shuffle();

			// assert
			for (int i = 0; i < deck.Size; i++)
			{
				Assert.AreNotEqual(initial[i], deck.Cards[i], "Cards are equal at the position {0}", i + 1);
			}

			CollectionAssert.AllItemsAreUnique(deck.Cards);
		}
	}
}
