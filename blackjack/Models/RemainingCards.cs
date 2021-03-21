using System;
using System.Collections.Generic;
using System.Text;

namespace Blackjack.Models
{
    class RemainingCards
    {
        private Stack<Card> _Cards { get; set; }
        public Stack<Card> Cards
        {
            get
            {
                return _Cards;
            }
            set
            {
                if (value.Count< 52)
                {
                    throw new Exception("Card count can't be lower than 52");
                }
                else if(value.Count % 52 != 0)
                {
                    throw new Exception("Card count must be multiplier of 52");
                }
                else if (value.Count > 416)
                {
                    throw new Exception("Card count must be lower than eight set of 52-Cards");
                }
                else
                {
                    _Cards = value;
                }
            } 
        }
    
    }
}
