using Cemetery_Adventure.Inputs;
using Cemetery_Adventure.Outputs;
using Cemetery_Adventure_DB.Manager;
using Cemetery_Adventure_Logic;

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
                Game game;
                switch (menuOption)
                {
                    case MainMenuOption.NewGame:
                        game = NewGame();
                        StartGame(game);
                        break;
                    case MainMenuOption.LoadGame:
                        game = LoadGame();
                        StartGame(game);
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

        private static Game LoadGame()
        {
            Dictionary<string, string> loadedGame;

            do
            {
                Output.DisplayAllSavedGames(DBManager.GetAllSavedGames());
                Output.DisplayLoadGamePrompt();
                loadedGame = DBManager.LoadGame(Input.GetGameIdToLoad());
            } while (loadedGame.Count == 0);

            return GameLoading.PrepareGame(loadedGame);
        }

        private static void StartGame(Game game)
        {
            Output.InitGameStart();
            var gameRunning = true;

            while (gameRunning)
            {
                Output.DrawUi(game);
                var key = Input.GetKeyPressed();
                var playerDirection = Controls.GetMovementDirection(key);
                if (Controls.PlayerSaveGame(key)) SaveGame(game);
                if (Controls.BackToMenu(key)) gameRunning = false;
                game.Player.Direction = playerDirection;
                game.Update();
                if (!game.PlayerIsAlive)
                {
                    Output.PrintGameOver();
                    Input.WaitForInput();
                    gameRunning = false;
                }
            }
        }

        private static void SaveGame(Game game)
        {
            var armorTypeNumber = game.Player.GetArmorTypeNumberFromInventory();
            var weaponTypeNumber = game.Player.GetWeaponTypeNumberFromInventory();
            DBManager.SaveGame(game.Floor, game.Player.Name, game.Player.MaxHP, armorTypeNumber, weaponTypeNumber);
        }
    }
}