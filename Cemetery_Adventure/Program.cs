using Cemetery_Adventure_Logic;
using Cemetery_Adventure.Outputs;

namespace Cemetery_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Adventurer!");
            var game = new Game();

            var gameRunning = true;
            while (gameRunning)
            {
                Output.DisplayBoard(game);
                game.Update();
            }
        }
    }
}