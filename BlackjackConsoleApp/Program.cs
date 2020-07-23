using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using BlackjackLogicLayer;
using BlackjackLogicLayer.Enums;

namespace BlackjackConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write(Helper.ShowHeaderDisplay());
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Helper.ShowGameInstructions());
            Console.ForegroundColor = ConsoleColor.Blue;

            var deck = Helper.InitializeDeck();
            deck = Helper.ShuffleDeck(deck);

            Helper.Play(deck);
        }

        //private static void Play(List<Card> deck)
        //{
        //    var playerHandValue = 0;
        //    var dealerHandValue = 0;
        //    string playerChoice;

        //    do
        //    {
        //        Console.ForegroundColor = ConsoleColor.Blue;
        //        Console.WriteLine("Press (H) hit\nPress (S) to stop");
        //        playerChoice = Console.ReadLine().ToLower();
        //        if (playerChoice.Equals("h"))
        //        {
        //            var card = Helper.DealCard(deck);
        //            playerHandValue += (int)card.Value;
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine(Helper.DisplayDealtCard(card, playerHandValue, "Player"));
        //            Console.ForegroundColor = ConsoleColor.Green;
        //        }

        //        if (playerHandValue > 21)
        //        {
        //            Console.WriteLine("Player Bust - Dealer Wins!");
        //            Console.ForegroundColor = ConsoleColor.Black;
        //        }
        //        if (playerHandValue == 21)
        //        {
        //            Console.WriteLine("Player Wins!");
        //            Console.ForegroundColor = ConsoleColor.Black;

        //        }
        //    }
        //    while (!playerChoice.Equals("s") && playerChoice.Equals("h") && (playerHandValue < 21));

        //    if (playerChoice.Equals("s"))
        //    {
        //        while (dealerHandValue <= 17)
        //        {
        //            var card = Helper.DealCard(deck);
        //            dealerHandValue += (int)card.Value;
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine(Helper.DisplayDealtCard(card, dealerHandValue, "Dealer"));
        //            Console.ForegroundColor = ConsoleColor.Green;
        //            Thread.Sleep(500);
        //        }

        //        if (dealerHandValue > 21)
        //        {
        //            Console.WriteLine("Dealer bust! - Player Wins!");
        //            Console.ForegroundColor = ConsoleColor.Black;
        //        }

        //        if (dealerHandValue == 21)
        //        {
        //            Console.WriteLine("Dealer Wins!");
        //            Console.ForegroundColor = ConsoleColor.Black;
        //        }

        //        else
        //        {
        //            if (playerHandValue > dealerHandValue)
        //            {
        //                Console.WriteLine("Player Wins!");
        //                Console.ForegroundColor = ConsoleColor.Black;
        //            }
        //            else if (playerHandValue == dealerHandValue)
        //            {
        //                Console.WriteLine("Ended in a Tie!");
        //                Console.ForegroundColor = ConsoleColor.Black;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Dealer Wins!");
        //                Console.ForegroundColor = ConsoleColor.Black;
        //            }
        //        }
        //    }
        //}
    }
}
