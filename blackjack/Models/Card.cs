using System;

namespace Blackjack.Models
{
    public class Card
    {
        public Card(CardNumber cardNumber, CardSuit cardSuit)
        {
            CardNumber = cardNumber;
            CardSuit = cardSuit;
        }
        public CardNumber CardNumber { get; set; }
        public CardSuit CardSuit { get; set; }
        public CardColor CardColor { get
            {
                return CardSuit switch
                {
                    CardSuit.Clubs => CardColor.Black,
                    CardSuit.Spades => CardColor.Black,
                    CardSuit.Hearts => CardColor.Red,
                    CardSuit.Diamonds => CardColor.Red,
                    _ => throw new NotImplementedException()
                };
            } }
        public string CardName => $"{Enum.GetName(typeof(CardColor), CardColor)} {Enum.GetName(typeof(CardSuit), CardSuit)} {Enum.GetName(typeof(CardNumber), CardNumber)}";
    }

}
