using BlackjackLogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackjackLogicLayer
{
    public class Helper
    {
        /// <summary>
        /// Create 52 card deck
        /// </summary>
        /// <returns>Returns a simple 52 card deck of cards</returns>
        public static List<Card> InitializeDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (var suit in Enum.GetNames(typeof(Suit)))
            {
                foreach (var value in Enum.GetNames(typeof(Value)))
                {
                    deck.Add(
                        new Card()
                        {
                            Suit = (Suit)Enum.Parse(typeof(Suit), suit),
                            Value = (Value)Enum.Parse(typeof(Value), value)
                        }
                        );
                }
            }
            Console.WriteLine("Deck initialized");
            return deck;
        }

        /// <summary>
        /// Shuffle newly initialized deck
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Returns a shuffled deck of 52 cards</returns>
        public static List<Card> ShuffleDeck(List<Card> deck)
        {
            deck = deck.OrderBy(rand => Guid.NewGuid()).ToList();
            return deck;
        }

        /// <summary>
        /// Deal card to Player or Dealer
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Returns a single card</returns>
        public static Card DealCard(List<Card> deck)
        {
            var dealtCard = deck.FirstOrDefault();
            deck.Remove(dealtCard);
            return dealtCard;
        }

        /// <summary>
        /// Get Winner of Blackjack round
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dealer"></param>
        /// <returns>String message to display winner</returns>
        public static string GetWinner(int player, int dealer)
        {
            if(player > dealer)
            {
                return "Player Wins!";
            }
            else
            {
                return "Dealer Wins";
            }
        }

        /// <summary>
        /// Display Blackjack Logo
        /// </summary>
        /// <returns>Blackjack message for header display</returns>
        public static string ShowHeaderDisplay()
        {
            var sb = new StringBuilder();
            sb.AppendLine("================================");
            sb.AppendLine("====♥ ♦ ♣ ♠BlackJack♥ ♦ ♣ ♠=====");
            sb.AppendLine("================================");
            return sb.ToString();
        }

        public static string ShowGameInstructions()
        {
            var sb = new StringBuilder();
            sb.AppendLine("*********************************************************************************");
            sb.AppendLine("Player:");
            sb.AppendLine("---------------------------");
            sb.AppendLine("The player gets dealt cards until the player chooses to stop receiving new cards.");
            sb.AppendLine("As the player receives, each new card, his/her total is added.");
            sb.AppendLine("If the player goes over 21, the player loses.");

            sb.AppendLine("Dealer:");
            sb.AppendLine("---------------------------");
            sb.AppendLine("If the player decides to stop before 21 its the dealers turn to receive cards.");
            sb.AppendLine("The dealer will continue to receive cards until his count is 17 or over.");
            sb.AppendLine("If the dealers count is over 21, he/she loses.");
            sb.AppendLine("*********************************************************************************");
            return sb.ToString();
        }
        public static string DisplayDealtCard(Card card, int playerHandValue, string user)
        {
            var sb = new StringBuilder();
            sb.AppendLine("==========================");
            sb.AppendLine(user+" Dealt:");
            sb.AppendLine("------------------");
            sb.AppendLine(Enum.GetName(typeof(Value), card.Value) + " of " + Enum.GetName(typeof(Suit), card.Suit));
            sb.AppendLine(user+" Current Hand: " + playerHandValue);
            sb.AppendLine("==========================");

            return sb.ToString();
        }

    }
}
