using System;
using System.Collections.Generic;

namespace DeckOCards
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.Clear();

      Console.WriteLine("Welcome to my Deck of Cards! Let me pick a card for you...");
      Console.WriteLine();

      var suits = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
      var ranks = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      var deck = new List<Card>();
      var playerHand = new List<Card>();

      for (var i = 0; i < suits.Length; i++)
      {
        for (var j = 0; j < ranks.Length; j++)
        {
          var card = new Card();
          card.Rank = ranks[j];
          card.Suit = suits[i];
          deck.Add(card);
        }
      }

      //fisher-yates algorithm 
      for (var i = deck.Count - 1; i >= 1; i--)
      {
        var j = new Random().Next(i);
        var temp = (deck[j]);
        deck[j] = (deck[i]);
        deck[i] = (temp);
      }

      Console.WriteLine($"Your card is the {deck[0].DisplayCard()}");
      Console.WriteLine();

      playerHand.Add(deck[0]);
      deck.RemoveAt(0);


      bool hitMe = false;
      while (!hitMe && deck.Count > 0)
      {
        Console.WriteLine("Would you like to draw the next card or quit?");
        Console.WriteLine();
        var total = 0;

        for (var i = 0; i < playerHand.Count; i++)
        {
          total += playerHand[i].GetCardValue();
        }

        Console.WriteLine($"The current total is {total}");
        Console.WriteLine();


        var userInput = Console.ReadLine().ToLower();
        if (userInput != "next" && userInput != "quit")
        {
          Console.WriteLine("That is not a valid response ...");
          Console.WriteLine();
        }
        if (userInput == "next")
        {
          Console.WriteLine($"Your next card is {deck[0].DisplayCard()}");
          Console.WriteLine();

          playerHand.Add(deck[0]);
          deck.RemoveAt(0);


          Console.WriteLine($"Your hand now consists of ...");
          Console.WriteLine();

          for (var i = 0; i < playerHand.Count; i++)
          {
            Console.WriteLine(playerHand[i].DisplayCard());
          }

          Console.WriteLine();
        }
        else if (userInput == "quit")
        {
          hitMe = true;
        }
      }
    }
  }
}
