namespace Cemetery_Adventure_Logic.Entity.Character;

public class Player : Character
{
    public Player((int X, int Y) position, int hP, int maxHP, int damage, int defense) : base(position, maxHP, damage, defense)
    {
    }

    public override (int X, int Y) GetMove()
    {
        throw new NotImplementedException();
    }

    public void Turn()
    {
        var move = GetMove();
        Move(move.X, move.Y);
    }
}