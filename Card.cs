using System;
using System.Collections.Generic;


namespace DeckOCards
{
  public class Card
  {

    //rank
    public string Rank { get; set; }
    //suit
    public string Suit { get; set; }
    //color
    public string Color { get; set; }

    //method
    public string DisplayCard()
    {
      return $"{Rank} of {Suit}";
    }

    public int GetCardValue()
    {
      if (Rank == "ace")
      {
        return 11;
      }
      else if (Rank == "queen" || Rank == "king" || Rank == "jack")
      {
        return 10;
      }
      else
      {
        return int.Parse(Rank);
      }


    }
  }
}

