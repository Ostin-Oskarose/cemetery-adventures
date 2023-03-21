namespace Cemetery_Adventure_Logic.Entity.Character.Enemy;

public abstract class Enemy : Character
{
    protected (int X, int Y) LastKnownPosition;

    protected Enemy((int X, int Y) position, int maxHP, int damage, int defense) : base(position, maxHP, damage, defense)
    {
    }
}