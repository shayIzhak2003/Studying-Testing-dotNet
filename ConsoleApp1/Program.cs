using StudyingTesting.game_area;
using StudyingTesting.poker_hands;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting test...");
        // Uncomment to run MyTesting, if you want to test poker hands
        MyTesting.RunMe();
        GameSystem.DemoMain();  // Calls the DemoMain method from GameSystem
    }
}
