// Cards.cs -- contains deck and cards
#nullable disable

namespace CardLib
{
    // deck of cards, contains deck management methods
    public class Deck
    {
        // initialize variables
        private List<Card> cards;

        // get sorted deck of all cards
        public List<Card> GetSortedDeck()
        {
            List<Card> sortedDeck = new List<Card>();
            // loop through all suits and card values, add to sorted deck
            for (int s = 0; s < 4; s++)
            {
                for (int v = 1; v <= 13; v++)
                {
                    sortedDeck.Add(new Card((Suit)s, (CardValue)v));
                }
            }
            return sortedDeck;
        }

        // display all cards in deck -- probably delete at some point?
        public void DisplayDeck()
        {
            List<string> displayDeck = new List<string>();
            foreach (Card card in cards)
            {
                displayDeck.Add(card.CardToString());
            }
            string result = string.Join(", ", displayDeck);
            Console.WriteLine(result);
        }

        // return and remove last card of deck
        public Card DrawCard()
        {
            Card lastCard = cards.Last();
            cards.Remove(lastCard);
            return lastCard;
        }

        // get deck and shuffle
        public void InitializeDeck()
        {
            cards = GetSortedDeck();
            cards.Shuffle();
        }
    }

    // singular card, contains single card methods
    public class Card
    {
        public Suit suit;
        public CardValue value;

        public Card(Suit cardSuit, CardValue cardValue)
        {
            suit = cardSuit;
            value = cardValue;
        }

        // convert card to string
        public string CardToString()
        {
            string cardString = $"{this.value} of {this.suit}";
            return cardString;
        }
    }

    // Enums
    public enum Suit { Hearts, Diamonds, Spades, Clubs };
    public enum CardValue { Ace = 1, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King };
}

