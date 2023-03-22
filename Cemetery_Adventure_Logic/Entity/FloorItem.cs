namespace Cemetery_Adventure_Logic.Entity;

public class FloorItem : Entity
{
    protected Item.Item Item { get; init; }

    public FloorItem(Item.Item item, (int X, int Y) position) : base(item.Name, position)
    {
        Item = item;
    }

}