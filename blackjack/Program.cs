using System;

namespace blackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackjack = new Blackjack(4, 4);
            blackjack.Play();
        }
    }
}
