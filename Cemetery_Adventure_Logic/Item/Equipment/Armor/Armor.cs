namespace Cemetery_Adventure_Logic.Item.Equipment.Armor;

public abstract class Armor : Equipment
{
    public int Defense { get; init; }

    protected Armor(string name, int defense) : base(name)
    {
        Defense = defense;
    }
}