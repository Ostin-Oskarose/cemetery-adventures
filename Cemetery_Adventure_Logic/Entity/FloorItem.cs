namespace Cemetery_Adventure_Logic.Entity;

public class FloorItem : Entity
{
    public override char Symbol => Name[0];

    protected Item.Item Item { get; init; }

    public FloorItem(Item.Item item, (int X, int Y) position) : base(item.Name, position)
    {
        Item = item;
    }

}