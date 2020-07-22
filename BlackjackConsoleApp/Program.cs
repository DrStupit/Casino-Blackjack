using System;
using System.Collections.Generic;
using System.Text;
using BlackjackLogicLayer;
using BlackjackLogicLayer.Enums;

namespace BlackjackConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerHandValue = 0;
            //var dealerHandValue = 0;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write(Helper.ShowHeaderDisplay());
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Helper.ShowGameInstructions());
            Console.ForegroundColor = ConsoleColor.Green;

            var deck = Helper.InitializeDeck();
            deck = Helper.ShuffleDeck(deck);

            Console.Write("Take Another Card - 1\nStop - 2");
            string userChoice = Console.ReadLine();
            
            while (playerHandValue <= 21)
            {
                var card = Helper.DealCard(deck);
                playerHandValue += (int)card.Value;
                Console.WriteLine("Player Dealt:");
                Console.WriteLine(Enum.GetName(typeof(Value), card.Value) + " of " + Enum.GetName(typeof(Suit), card.Suit));
                Console.WriteLine("Players Current Hand: " + playerHandValue);
                userChoice = "";
                if(playerHandValue > 21)
                {
                    Console.Write("Player lost");
                }
            }
            //ToDO:
            //For Some Pizaz.
            // System.Threading.Sleep(few millseconds)
        }
    }
}
