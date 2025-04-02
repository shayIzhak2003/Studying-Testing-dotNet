using StudyingTesting.poker_hands;
using System;

public class MyTesting
{
    public static void RunMe()
    {
        // Provide a valid hand string instead of "Example"
        string handString = "5D 7H 2H AH 10S";

        // Create the Hand object using the valid hand string
        Hand hand = new Hand(handString);

        Console.WriteLine("Before sorting:");
        foreach (Card c in hand.Cards)
        {
            Console.WriteLine(c);
        }

        hand.Sort();

        Console.WriteLine("After sorting:");
        foreach (Card c in hand.Cards)
        {
            Console.WriteLine(c);
        }
    }
}
