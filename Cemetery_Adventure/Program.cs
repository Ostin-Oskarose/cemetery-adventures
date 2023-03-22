using Cemetery_Adventure_Logic;

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
                Output.GameBoard.DisplayBoard.Display(game);
                game.Update();
            }
        }
    }
}