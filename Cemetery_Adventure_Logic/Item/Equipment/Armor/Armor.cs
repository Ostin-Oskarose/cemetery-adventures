namespace Cemetery_Adventure_Logic.Item.Equipment.Armor;

public abstract class Armor : Equipment
{
    public int Defense { get; init; }
    public int TypeNumber { get; init; }

    protected Armor(string name, int defense, int typeNumber) : base(name)
    {
        Defense = defense;
        TypeNumber = typeNumber;
    }
}