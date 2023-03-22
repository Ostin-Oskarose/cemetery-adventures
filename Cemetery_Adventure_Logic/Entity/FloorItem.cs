namespace Cemetery_Adventure_Logic.Entity;

public class FloorItem : Entity
{
    public FloorItem(Item.Item item, (int X, int Y) position) : base(item.Name, position)
    {
    }

}