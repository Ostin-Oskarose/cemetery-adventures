using Cemetery_Adventure_Logic;
using Cemetery_Adventure.Outputs;

namespace Cemetery_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();

            var gameRunning = true;
            while (gameRunning)
            {
                Output.DisplayBoard(game);
                game.Update();
                game.EnemiesTurn();
                Console.SetCursorPosition(0,0);
            }
        }
    }
}