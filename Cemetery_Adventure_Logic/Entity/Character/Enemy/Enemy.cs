namespace Cemetery_Adventure_Logic.Entity.Character.Enemy;

public abstract class Enemy : Character
{
    protected (int X, int Y) LastKnownPosition;

    protected Enemy(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position, maxHP, damage, defense)
    {
    }
}