using Cemetery_Adventure_Logic;
using Cemetery_Adventure.Outputs;
using Cemetery_Adventure_Logic.Entity.Character;

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
                Output.Init();
                Output.DisplayBoard(game);
                Output.DisplayPlayerInformation(game);
                game.Update();
                if (!game.PlayerIsAlive)
                {
                    Output.PrintGameOver();
                    gameRunning = false;
                }
            }
        }
    }
}