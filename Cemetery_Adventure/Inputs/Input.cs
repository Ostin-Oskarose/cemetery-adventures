using Cemetery_Adventure_Logic;

namespace Cemetery_Adventure.Inputs;

public static class Input
{
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

    internal static ConsoleKey? GetKeyPressed()
    {
        if (!Console.KeyAvailable) return null;
        var keyInfo = Console.ReadKey(true);
        var consoleKey = keyInfo.Key;
        return consoleKey;
    } 
}