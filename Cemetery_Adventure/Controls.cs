using Cemetery_Adventure_Logic;
using Cemetery_Adventure_Logic.Item.Equipment;

namespace Cemetery_Adventure;

public static class Controls
{
    internal static bool BackToMenu(ConsoleKey? key)
    {
        return (key == ConsoleKey.Escape);
    }
    public static Direction GetMovementDirection(ConsoleKey? key)
    {
        switch (key)
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

    internal static bool PlayerSaveGame(ConsoleKey? key)
    {
        return (key == ConsoleKey.F5);
    }
}