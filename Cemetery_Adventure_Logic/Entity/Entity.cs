using System.Runtime.CompilerServices;

namespace Cemetery_Adventure_Logic.Entity;

public abstract class Entity
{
    protected (int X, int Y) Position;

    protected Entity((int X, int Y) position)
    {
        Position = position;
    }
}