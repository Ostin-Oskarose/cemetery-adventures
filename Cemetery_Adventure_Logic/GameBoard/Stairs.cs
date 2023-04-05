using Cemetery_Adventure_Logic.Entity;

namespace Cemetery_Adventure_Logic.GameBoard;

public class Stairs : Obstacle
{
    public int LevelNumber { get; }

    public Stairs((int X, int Y) position, int levelNumber)
        : base(position, ">")
    {
        LevelNumber = levelNumber;
    }
}