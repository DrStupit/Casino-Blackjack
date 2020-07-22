using Casino_Assesment_July2020.Enums;
using Casino_Assesment_July2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Casino_Assesment_July2020
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = new List<Card>();
            List<Card> deck = InitializeDeck();
            deck = ShuffleDeck(deck);
            var dealtCard = DealCard(deck);
            Console.WriteLine(Enum.GetName(typeof(Value), dealtCard.Value) + " of " + Enum.GetName(typeof(Suit), dealtCard.Suit));
            Console.WriteLine(deck.Count);
        }

        private static void PrintDeck(List<Card> deck)
        {
            foreach (var card in deck)
            {
                Console.WriteLine(Enum.GetName(typeof(Value), card.Value)  + " of " + Enum.GetName(typeof(Suit), card.Suit));
            }
        }

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

        private static List<Card> ShuffleDeck(List<Card> deck)
        {
            deck = deck.OrderBy(rand => Guid.NewGuid()).ToList();
            return deck;
        }

        private static Card DealCard(List<Card> deck)
        {
            var dealtCard = deck.FirstOrDefault();
            deck.Remove(dealtCard);
            return dealtCard;
        }



    }
}
