// CardLib.cs -- Salem's Card Library, contains deck, cards, and enums for suit and cardvalue
namespace CardLib
{
    // deck of cards, contains deck management methods
    public class Deck
    {
        // initialize variables
        private List<Card> cards;
        private Random random = new Random();

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

        // return and remove first card of deck
        public Card DrawCard()
        {
            Card drawnCard = cards[0];
            cards.Remove(drawnCard);
            return drawnCard;
        }

        // return card to random spot in deck
        public void ReturnCard(Card card)
        {
            int randomIndex = random.Next(0, cards.Count);
            cards.Insert(randomIndex, card);
        }

        // get deck and shuffle
        public void InitializeDeck()
        {
            cards = GetSortedDeck();
            cards.Shuffle();
        }
    }

    // hand of cards
    public class Hand
    {
        public List<Card> cards = new List<Card>();

        // draw card, add to cards, return card name string
        public string DrawCard(Deck deck)
        {
            Card drawnCard = deck.DrawCard();
            cards.Add(drawnCard);
            return (drawnCard.CardToString());
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

        // convert card to string in form '[value] of [suit]'
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

