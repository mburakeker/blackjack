using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace blackjack
{
    public static class DeckHelper
    {
        private static Random rng = new Random();
        public static Stack<T> Shuffle<T>(this Stack<T> stack)
        {
            return new Stack<T>(stack.OrderBy(x => rng.Next()));
        }
        public static Stack<Card> Generate(int deckCount)
        {
            var stack = new Stack<Card>();
            for(int i = 0; i<deckCount; i++)
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
                {
                    foreach (CardNumber number in Enum.GetValues(typeof(CardNumber)))
                    {
                        stack.Push(new Card(number, suit));
                    }
                }
            }
            return stack;
        }
        public static int GetSumOfCardNumbers(this Player player)
        {
            var sum = 0;
            foreach(var card in player.Hand)
            {
                if(card.CardNumber == CardNumber.Jack || card.CardNumber == CardNumber.Queen || card.CardNumber == CardNumber.King)
                {
                    sum += 10;
                }
                else if (card.CardNumber!=CardNumber.Ace)
                {
                    sum += (int)card.CardNumber;
                }
            }
            var aces = player.Hand.Where(card => card.CardNumber == CardNumber.Ace);
            foreach(var ace in aces)
            {
                if (sum + 11 <= 21)
                {
                    sum += 11;
                }
                else
                {
                    sum += 1;
                }
            }
            return sum;
        }
    }
}
