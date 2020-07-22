using BlackjackLogicLayer;
using Casino_Assesment_July2020.Enums;
using Casino_Assesment_July2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Card = BlackjackLogicLayer.Card;

namespace Casino_Assesment_July2020
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerHandValue = 0;
            //var dealerHandValue = 0;

            _ = new List<Card>();
            List<Card> deck = Helper.InitializeDeck();
            deck = Helper.ShuffleDeck(deck);
            Console.WriteLine("Take Another Card - 1 \nStop - 2");
            string userChoice = Console.ReadLine();
            while (userChoice.Equals("1") && playerHandValue <= 21)
            {
                var card = Helper.DealCard(deck);
                playerHandValue += (int)card.Value;
                Console.WriteLine("Player Dealt:");
                Console.WriteLine(Enum.GetName(typeof(Value), card.Value) + " of " + Enum.GetName(typeof(Suit), card.Suit));
                Console.WriteLine("Players Current Hand: " + playerHandValue);
                userChoice = "";
            }


        }
        //public static List<Card> InitializeDeck()
        //{
        //    List<Card> deck = new List<Card>();
        //    foreach (var suit in Enum.GetNames(typeof(Suit)))
        //    {
        //        foreach (var value in Enum.GetNames(typeof(Value)))
        //        {
        //            deck.Add(
        //                new Card()
        //                {
        //                    Suit = (Suit)Enum.Parse(typeof(Suit), suit),
        //                    Value = (Value)Enum.Parse(typeof(Value), value)
        //                }
        //                );
        //        }
        //    }
        //    Console.WriteLine("Deck initialized");
        //    return deck;
        //}
        //private static List<Card> ShuffleDeck(List<Card> deck)
        //{
        //    deck = deck.OrderBy(rand => Guid.NewGuid()).ToList();
        //    return deck;
        //}
        //private static Card DealCard(List<Card> deck)
        //{
        //    var dealtCard = deck.FirstOrDefault();
        //    deck.Remove(dealtCard);
        //    return dealtCard;
        //}
    }
}
