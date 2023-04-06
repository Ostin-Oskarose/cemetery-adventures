namespace Cemetery_Adventure_Logic.Item.Equipment.Weapon;

public abstract class Weapon : Equipment
{
    public int Damage { get; init; }
    public int TypeNumber { get; init; }

    protected Weapon(string name, int damage, int typeNumber) : base(name)
    {
        Damage = damage;
        TypeNumber = typeNumber;
    }
}