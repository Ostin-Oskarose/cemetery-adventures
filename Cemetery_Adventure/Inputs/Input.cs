using Cemetery_Adventure_Logic;

namespace Cemetery_Adventure.Inputs;

public static class Input
{

    public static Direction GetMovementDirection()
    {
        if (Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(true);
            var consoleKey = keyInfo.Key;
            switch (consoleKey)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    return Direction.Up;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    return Direction.Right;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    return Direction.Down;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    return Direction.Left;
                default:
                    return Direction.None;
            }
        }
        else
        {
            return Direction.None;
        }
    }

    public static string GetPlayerName()
    {
        Console.CursorVisible = true;
        var name = Console.ReadLine();
        Console.CursorVisible = false;
        return name;
    }

    public static MainMenuOption GetMainMenuOption()
    {
        while (true)
        {
            Console.CursorVisible = true;
            var input = Console.ReadLine();
            if (int.TryParse(input, out int selection))
            {
                var option = (MainMenuOption)selection;
                Console.CursorVisible = false;
                return option;
            }
        }
    }

    public static void WaitForInput()
    {
        Console.ReadLine();
    }

    internal static int GetGameIdToLoad()
    {
        while (true)
        {
            Console.CursorVisible = true;
            var input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                Console.CursorVisible = false;
                return id;
            }
        }
    }

    internal static bool PlayerSaveGame()
    {
        if (Console.KeyAvailable)
        {
            var keyInfo = Console.ReadKey(true);
            var consoleKey = keyInfo.Key;
            switch (consoleKey)
            {
                case ConsoleKey.F5:
                    return true;
            }
        }

        return false;
    }
}