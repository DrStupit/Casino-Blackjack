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
            Console.BackgroundColor = ConsoleColor.Gray;
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
    }
}
