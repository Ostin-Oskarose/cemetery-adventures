using System.Text;
using Cemetery_Adventure_Logic;

namespace Cemetery_Adventure.Outputs
{
    public class Output
    {
        public static void Init()
        {
            Console.CursorVisible = false;
        }

        public static void DisplayBoard(Game game)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"Floor {game.Floor}");
            for (int i = 0; i < game.GameBoard.BoardArray.GetLength(0); i++)
            {
                for (int j = 0; j < game.GameBoard.BoardArray.GetLength(1); j++)
                {
                    if (game.GameBoard.BoardArray[i, j] == null)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    Console.Write($"{game.GameBoard.BoardArray[i, j].Symbol} ");
                }
                Console.WriteLine();
            }
        }

        public static void DisplayMessageBuffer(Game game)
        {
            for (var index = 0; index < game.MessageBuffer.Size; index++)
            {
                ClearCurrentConsoleLine();
                Console.WriteLine(game.MessageBuffer.Messages.ElementAtOrDefault(index));
            }
        }

        public static void PrintGameOver()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER");
            Console.WriteLine("You died!");
            Console.WriteLine("(Press enter to continue)");
        }

        internal static void DisplayPlayerInformation(Game game)
        {
            Console.WriteLine(game.Player.Name);
            Console.WriteLine($"HP: {$"{game.Player.HP}/{game.Player.MaxHP}", -7} Defense: {$"{game.Player.Defense}", -5} Damage: {$"{game.Player.Damage}",-5}");
            if (game.Player.GetInventory().Count > 0)
            {
                Console.Write("Inventory: ");
                foreach (var item in game.Player.GetInventory())
                {
                    Console.Write($" {item.Name} ");
                }
            }
            else
            {
                Console.WriteLine($"{new string(' ',30)}");
            }
        }

        public static void DisplayPlayerNamePrompt()
        {
            Console.Clear();
            Console.WriteLine("Enter player name: ");
        }

        public static void DisplayMainMenu()
        {
            Console.Clear();
            var options = Enum.GetValues(typeof(MainMenuOption)).Cast<MainMenuOption>().ToList();
            options.ForEach(option => Console.WriteLine($"({(int)option}) {Enum.GetName(option)}"));
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        internal static void InitGameStart()
        {
            Console.Clear();
        }

        internal static void DisplayAllSavedGames(List<Dictionary<string, string>> savedGamesList)
        {
            Console.Clear();
            foreach (var savedGame in savedGamesList)
            {
                var sb = new StringBuilder()
                    .Append($"Id - {savedGame["id"]} ")
                    .Append($"Save time - {savedGame["save_time"]} ")
                    .Append($"Player Name - {savedGame["player_name"]} ")
                    .Append($"Floor - {savedGame["floor"]}");
                Console.WriteLine(sb);
            }
        }

        internal static void DisplayLoadGamePrompt()
        {
            Console.WriteLine("\nEnter game ID to load: ");
        }
    }
}
