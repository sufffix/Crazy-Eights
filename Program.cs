// Salem's Crazy Eights
using CardLib;

namespace CrazyEights
{
    public class Program
    {
        // global variables
        public static int numOfPlayers = 2;
        public static Deck deck = new Deck();
        public static List<Player> players = new List<Player>();

        public static void Main()
        {
            // initialize deck and players
            deck.InitializeDeck();
            for (int n = 1; n <= numOfPlayers; n++)
            {
                players.Add(new Player());
            }

            Console.Clear();
            Console.WriteLine("Crazy Eights! \n");
            DealCards();
            Console.WriteLine();

            Console.WriteLine("Starter card: " + PlayPile.cards.Last().CardToString());
        }

        // deal 
        public static void DealCards()
        {
            for (int c = 1; c <= 5; c++)
            {
                for (int i = 0; i < numOfPlayers; i++)
                {
                    // writes cards drawn for testing, to remove
                    string newCard = players[i].hand.DrawCard(deck);
                    Console.WriteLine($"Player {i + 1} drew a {newCard}.");
                }
            }
            PlayPile.DrawStarter(deck);
        }
    }

    public class Player
    {
        public int score;
        public Hand hand = new Hand();
    }

    public static class PlayPile
    {
        public static List<Card> cards = new List<Card>();

        public static void DrawStarter(Deck deck)
        {
            Card drawnCard = deck.DrawCard();

            if (drawnCard.value == CardValue.Eight)
            {
                deck.ReturnCard(drawnCard);
                DrawStarter(deck);
            }
            else
            {
                cards.Add(drawnCard);
            }
        }
    }
}