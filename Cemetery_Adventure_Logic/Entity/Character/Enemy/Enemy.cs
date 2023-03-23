namespace Cemetery_Adventure_Logic.Entity.Character.Enemy;

public abstract class Enemy : Character
{
    protected (int X, int Y) LastKnownPosition;

    protected Enemy(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position, maxHP, damage, defense)
    {
    }

    public override (int X, int Y) GetMove()
    {
        (int X, int Y) move;
        int direction = new Random().Next(0, 4);

        switch (direction)
        {
            case 0:
                move = (Position.X, Position.Y - 1);
                break;
            case 1:
                move = (Position.X + 1, Position.Y);
                break;
            case 2:
                move = (Position.X, Position.Y + 1);
                break;
            case 3:
                move = (Position.X - 1, Position.Y);
                break;
            default:
                move = Position;
                break;
        }
        return move;
    }
}