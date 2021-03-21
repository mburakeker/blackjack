using Blackjack.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace blackjack
{
    public class Blackjack
    {
        private List<Player> players;
        private RemainingCards cards;
        private Random rng;
        public Blackjack(int playerCount, int deckCount)
        {
            rng = new Random();
            players = Enumerable.Range(0, playerCount).Select(x => new Player()).ToList();
            Console.WriteLine($"Players are {string.Join(",", players.Select(player=>player.Id))}");
            cards = new RemainingCards { Cards = DeckHelper.Generate(deckCount) };
            cards.Cards = cards.Cards.Shuffle();
            Console.WriteLine("Cards are shuffled.");
        }

        public void Play()
        {
            //Dealer deals cards for the first round.
            foreach (var player in players)
            {
                var card = cards.Cards.Pop();
                player.Hand.Push(card);
                Console.WriteLine($"Dealer dealt a {card.CardName} to {player.Id}");
            }
            Console.WriteLine("First round of cards are dealt!");

            do
            {
                var playersCurrentRound = players.ToList();
                var actionTaken = false;
                foreach (var player in playersCurrentRound)
                {
                    var sumOfCardNumbers = player.GetSumOfCardNumbers();
                    bool playerWouldNeverLoseOnNextCard = (sumOfCardNumbers < 12);
                    bool playerWantsAnotherCard = ((double)(21 - sumOfCardNumbers) / 21) > rng.NextDouble();
                    if (playerWouldNeverLoseOnNextCard || playerWantsAnotherCard || sumOfCardNumbers < players.Max(player => player.GetSumOfCardNumbers()))
                    {
                        Console.WriteLine($"Player {player.Id} hits.");
                        actionTaken = true;
                        var card = cards.Cards.Pop();
                        player.Hand.Push(card);
                        sumOfCardNumbers = player.GetSumOfCardNumbers();
                        Console.WriteLine($"Player {player.Id} has been dealt a {card.CardName}");
                        Console.WriteLine($"Player {player.Id}'s hand has a value of {sumOfCardNumbers}");
                        Console.WriteLine("Player's hand: ");
                        Console.WriteLine(string.Join(",",player.Hand.Select(card=>card.CardName)));
                    }
                    if (sumOfCardNumbers > 21)
                    {
                        Console.WriteLine($"Player {player.Id} has exceeded 21 and is now removed from the game!");
                        players.Remove(player);
                        playersCurrentRound = players.ToList();
                    }
                    else if (sumOfCardNumbers == 21)
                    {
                        Console.WriteLine($"Player {player.Id} blackjacks!");
                        players = new List<Player>() { player };
                        Console.WriteLine($"Winner is {player.Id}");
                        break;
                    }
                }
                if (actionTaken == false)
                {
                    Console.WriteLine("It's a tie.");
                    break;
                }
                if (players.Count == 1)
                {
                    var lastPlayer = players.FirstOrDefault();
                    Console.WriteLine($"Only one player left. The winner is {lastPlayer.Id}");
                }
            }
            while (players.Count() > 1 && cards.Cards.Count() > 0);
        }
        
    }
}
