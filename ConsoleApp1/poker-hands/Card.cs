
using StudyingTesting.poker_hands;

public class Card : IComparable<Card>
{
    public int Number { get; set; }
    public Suit Suit { get; set; }

    public Card(int number, Suit suit)
    {
        Number = number;
        Suit = suit;
    }

    public override string ToString()
    {
        return Suit + "-" + Number;
    }

    public int CompareTo(Card other)
    {
        return Number.CompareTo(other.Number);
    }
}