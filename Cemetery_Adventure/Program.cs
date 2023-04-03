using Cemetery_Adventure.Inputs;
using Cemetery_Adventure_Logic;
using Cemetery_Adventure.Outputs;
using Cemetery_Adventure_Logic.Entity.Character;

namespace Cemetery_Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Output.DisplayPlayerNamePrompt();
            var playerName = Input.GetPlayerName();
            var game = new Game(playerName);
            var gameRunning = true;

            while (gameRunning)
            {
                Output.Init();
                Output.DisplayBoard(game);
                Output.DisplayPlayerInformation(game);
                var playerDirection = Input.GetMovementDirection();
                game.Player.Direction = playerDirection;
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