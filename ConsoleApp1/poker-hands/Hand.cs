using StudyingTesting.poker_hands;
using System;

public class Hand
{
    public Card[] Cards { get; private set; } = new Card[5];

    public Hand(string handString)
    {
        string[] cardStrings = handString.Split(' ');  // Split string by spaces to separate cards
        if (cardStrings.Length != 5)
        {
            throw new ArgumentException("A hand must contain exactly 5 cards.");
        }

        for (int i = 0; i < cardStrings.Length; i++)
        {
            Cards[i] = ParseCard(cardStrings[i]);
        }
    }

    private Card ParseCard(string cardString)
    {
        if (cardString.Length < 2 || cardString.Length > 3)
        {
            throw new ArgumentException($"Invalid card format: {cardString}");
        }

        // Check for two-character ranks (e.g., 10)
        string rankPart = cardString.Substring(0, cardString.Length - 1);
        char suitChar = cardString[cardString.Length - 1];

        // Handle two-character rank (e.g., "10")
        int rank;
        if (rankPart.Length == 2 && int.TryParse(rankPart, out rank))
        {
            // Valid two-digit rank, e.g., "10"
        }
        else
        {
            // Handle single-character ranks like "A", "K", "Q", "J", "T"
            rank = rankPart switch
            {
                "2" => 2,
                "3" => 3,
                "4" => 4,
                "5" => 5,
                "6" => 6,
                "7" => 7,
                "8" => 8,
                "9" => 9,
                "10" => 10,
                "J" => 11,
                "Q" => 12,
                "K" => 13,
                "A" => 14,
                _ => throw new ArgumentException($"Invalid rank: {rankPart}")
            };
        }

        Suit suit = suitChar switch
        {
            'C' => Suit.CLUBS,
            'D' => Suit.DIAMONDS,
            'H' => Suit.HEARTS,
            'S' => Suit.SPADES,
            _ => throw new ArgumentException($"Invalid suit: {suitChar}")
        };

        return new Card(rank, suit);
    }

    public void Sort()
    {
        Array.Sort(Cards);
    }
}
