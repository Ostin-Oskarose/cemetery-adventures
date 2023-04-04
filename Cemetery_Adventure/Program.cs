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
            while (true)
            {
                Output.DisplayMainMenu();
                var menuOption = Input.GetMainMenuOption();
                switch (menuOption)
                {
                    case MainMenuOption.NewGame:
                        var game = NewGame();
                        StartGame(game);
                        break;
                    case MainMenuOption.LoadGame:
                        throw new NotImplementedException();
                        break;
                    case MainMenuOption.Exit:
                        return;
                }
            }
        }

        private static Game NewGame()
        {
            Output.DisplayPlayerNamePrompt();
            var playerName = Input.GetPlayerName();
            var game = new Game(playerName);
            return game;
        }

        private static void StartGame(Game game)
        {
            var gameRunning = true;

            while (gameRunning)
            {
                Output.Init();
                Output.DisplayBoard(game);
                Output.DisplayMessageBuffer(game);
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