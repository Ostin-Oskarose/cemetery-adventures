namespace Cemetery_Adventure_Logic.Item.Equipment.Weapon;

public abstract class Weapon : Equipment
{
    public int Damage { get; init; }

    protected Weapon(string name, int damage) : base(name)
    {
        Damage = damage;
    }
}