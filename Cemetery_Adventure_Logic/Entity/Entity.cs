namespace Cemetery_Adventure_Logic.Entity;

public abstract class Entity
{
    public string Name { get; private set; }
    public abstract char Symbol { get; }
    public (int X, int Y) Position;

    protected Entity(string name, (int X, int Y) position)
    {
        Name = name;
        Position = position;
    }
}