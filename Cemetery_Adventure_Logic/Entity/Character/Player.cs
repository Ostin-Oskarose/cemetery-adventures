namespace Cemetery_Adventure_Logic.Entity.Character;

public class Player : Character
{

    public override char Symbol => '@';

    public Player(string name, (int X, int Y) position, int hP, int maxHP, int damage, int defense) : base(name, position, maxHP, damage, defense)
    {
    }

    public override (int X, int Y) GetMove()
    {
        (int X,int Y) move;
        //TODO implement input
        var input = "w";
        switch (input)
        {
            case "w":
                move = (Position.X, Position.Y - 1);
                break;
            case "a":
                move = (Position.X - 1, Position.Y); 
                break;
            case "s":
                move = (Position.X, Position.Y + 1);
                break;
            case "d":
                move = (Position.X + 1, Position.Y);
                break;
            default:
                move = Position;
                break;
        }
        return move;
    }

    public void Turn()
    {
        var move = GetMove();
        Move(move.X, move.Y);
    }
}