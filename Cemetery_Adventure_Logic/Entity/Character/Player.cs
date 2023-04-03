namespace Cemetery_Adventure_Logic.Entity.Character;

public class Player : Character
{

    public override char Symbol => '@';
    public Direction Direction { get; set; }

    public Player(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position, maxHP, damage, defense)
    {
    }

    public override (int X, int Y) GetMove()
    {
        (int X,int Y) move;
        switch (Direction)
        {
            case Direction.Up:
                move = (Position.X, Position.Y - 1);
                break;
            case Direction.Right:
                move = (Position.X + 1, Position.Y); 
                break;
            case Direction.Down:
                move = (Position.X, Position.Y + 1);
                break;
            case Direction.Left:
                move = (Position.X - 1, Position.Y);
                break;
            default:
                move = Position;
                break;
        }
        return move;
    }

    public bool CheckForKey()
    {
        return Inventory.Any(item => item.Name == "Key");
    }
}