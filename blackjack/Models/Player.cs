using System;
using System.Collections.Generic;
using System.Text;
namespace Blackjack.Models
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
            Hand = new Stack<Card>();
        }
        public Guid Id { get; set; }
        public Stack<Card> Hand { get; set; }

    }
}
