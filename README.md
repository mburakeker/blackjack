In this task, I designed the game following wikipedia guidelines for a blackjack game (without bets) and created a generic french-suited cards for cards with the following properties:

* CardColor enum (Red,Black), 
* CardSuit enum (Clubs, Diamonds, Hearts, Spades), 
* CardNumber enum (Ace,Two..Ten,Jack,Queen,King),
* CardName string : CardColor + CardSuit + CardNumber 

The instructions for the blackjack game are found in Blackjack class and helper extensions can be found in DeckHelper.cs

In constructor of Blackjack class: 
* Players are created and stored in "players" list
* RemainingCards class is instantiated and Cards are created using Generate method in DeckHelper by creating with the combination of CardSuit enum and CardNumber multiplying with the deckCount.
* And then Cards in RemainingCards are shuffled using Shuffle extension located in DeckHelper

In Play method of Blackjack is designed as a kind of an AI or in other words decision trees supported with RNG:
* Cards are dealt for the first round by Popping from Cards stack in RemainingCards and pushing to each Player's hand
* Creating a do while loop with the following instructions:
  *   Calculating the sum of card numbers in a player's hand
  *   Guessing if the player would hit or stand
  *   If players exceed 21, they are removed from the players list.
  *   If players hit 21, they win.
  *   If a player's hand value is not the highest, player is forced to ask for a card.
  *   If the remaining players have the same value and no one hits a card for the round, the round is considered a tie
  *   If only one player left, they are considered winner.
