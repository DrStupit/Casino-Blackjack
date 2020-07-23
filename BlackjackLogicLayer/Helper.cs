using BlackjackLogicLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
        public static void GetWinner(int player, int dealer)
        {
            if (dealer > 21)
            {
                Console.WriteLine("Dealer bust! - Player Wins!");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            if (dealer == 21)
            {
                Console.WriteLine("Dealer Wins!");
                Console.ForegroundColor = ConsoleColor.Black;
            }

            else
            {
                if (player > dealer)
                {
                    Console.WriteLine("Player Wins!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if (player == dealer)
                {
                    Console.WriteLine("Ended in a Tie!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else if(dealer > player && dealer < 21)
                {
                    Console.WriteLine("Dealer Wins!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
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
        /// <summary>
        /// Game Display for Instructions on Console
        /// </summary>
        /// <returns>String of Instructions</returns>
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
        /// <summary>
        /// Display Dealt card to Player & Dealer
        /// </summary>
        /// <param name="card"></param>
        /// <param name="playerHandValue"></param>
        /// <param name="user"></param>
        /// <returns>Returns a string for dealt card</returns>
        public static string DisplayDealtCard(Card card, int playerHandValue, string user)
        {
            var suitImg = "";

            if (Enum.GetName(typeof(Suit), card.Suit).Equals("Hearts"))
            {
                suitImg = "♥";
            }
            else if (Enum.GetName(typeof(Suit), card.Suit).Equals("Spades"))
            {
                suitImg = "♠";
            }
            else if (Enum.GetName(typeof(Suit), card.Suit).Equals("Diamonds"))
            {
                suitImg = "♦";
            }
            else if (Enum.GetName(typeof(Suit), card.Suit).Equals("Clubs"))
            {
                suitImg = "♣";
            }

            var sb = new StringBuilder();
            sb.AppendLine("==========================");
            sb.AppendLine("Dealt to "+user);
            sb.AppendLine("------------------");
            sb.AppendLine(Enum.GetName(typeof(Value), card.Value) + " of " + suitImg);
            sb.AppendLine(user + " Current Hand: " + playerHandValue);
            sb.AppendLine("==========================");

            return sb.ToString();
        }
        /// <summary>
        /// Run the game loop - To let user hit or surrender
        /// </summary>
        /// <param name="deck"></param>
        public static void Play(List<Card> deck)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            var playerHandValue = 0;
            var dealerHandValue = 0;
            string playerChoice;

            var firstCard = Helper.DealCard(deck);
            playerHandValue += (int)firstCard.Value;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Helper.DisplayDealtCard(firstCard, playerHandValue, "Player"));
            Console.ForegroundColor = ConsoleColor.Green;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Press (H) hit\nPress (S) to stop");
                playerChoice = Console.ReadLine().ToLower();
                if (playerChoice.Equals("h"))
                {
                    var card = Helper.DealCard(deck);
                    playerHandValue += (int)card.Value;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Helper.DisplayDealtCard(card, playerHandValue, "Player"));
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (playerHandValue > 21)
                {
                    Console.WriteLine("Player Bust - Dealer Wins!");
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                if (playerHandValue == 21)
                {
                    Console.WriteLine("Player Wins!");
                    Console.ForegroundColor = ConsoleColor.Black;

                }
            }
            while (!playerChoice.Equals("s") && playerChoice.Equals("h") && (playerHandValue < 21));

            if (playerChoice.Equals("s"))
            {
                while (dealerHandValue <= 17)
                {
                    var card = Helper.DealCard(deck);
                    dealerHandValue += (int)card.Value;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Helper.DisplayDealtCard(card, dealerHandValue, "Dealers"));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Thread.Sleep(500);
                }
                GetWinner(playerHandValue, dealerHandValue);
            }
        }

    }
}
