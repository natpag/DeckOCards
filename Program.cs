using System;
using System.Collections.Generic;

namespace DeckOCards
{
  class Program
  {
    static void Main(string[] args)
    {

      Console.WriteLine("Welcome to my Deck of Cards! Let me pick a card for you...");
      var suit = new string[] { "Clubs", "Diamonds", "Hearts", "Spades" };
      var value = new string[] { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
      var card = "";
      var deck = new List<string>();

      for (var i = 0; i < suit.Length; i++)
      {
        for (var j = 0; j < value.Length; j++)
        {
          card = ($"{value[j]} of {suit[i]}");
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

      Console.WriteLine($"Your card is the {deck[0]}");
      deck.RemoveAt(0);



      bool hitMe = false;
      while (!hitMe)
      {
        Console.WriteLine("Would you like to draw the next card or quit?");
        Console.WriteLine("Please select: Next or Quit...");
        var userInput = Console.ReadLine().ToLower();
        if (userInput == "next")
        {
          Console.WriteLine($"Your next card is {deck[0]}");
          deck.RemoveAt(0);
        }
        else if (userInput == "quit")
        {
          hitMe = true;
        }
      }





    }
  }
}
