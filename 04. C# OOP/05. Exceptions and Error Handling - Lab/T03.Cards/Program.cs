using System;
using System.Collections.Generic;
using System.Linq;

namespace T03.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] deckOfCards = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            var cards = new List<Card>();

            foreach (var card in deckOfCards)
            {
                string[] cardData = card
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    cards.Add(CreateCard(cardData[0], cardData[1]));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(' ', cards));
        }

        static Card CreateCard(string face, string suit)
        {
            string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            string[] validSuits = { "S", "H", "D", "C" };

            if (!validFaces.Contains(face) || !validSuits.Contains(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            return new Card(face, suit);
        }
    }

    class Card
    {
        public Card(string face, string suit)
        {
            this.Face = face;

            if (suit == "S") this.Suit = "\u2660";
            else if (suit == "H") this.Suit = "\u2665";
            else if (suit == "D") this.Suit = "\u2666";
            else if (suit == "C") this.Suit = "\u2663";
        }

        public string Face { get; }

        public string Suit { get; }

        public override string ToString()
        {
            return $"[{this.Face}{this.Suit}]";
        }
    }
}
