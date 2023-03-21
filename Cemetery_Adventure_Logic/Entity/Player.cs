namespace Cemetery_Adventure_Logic.Entity;

public class Player : Entity
{
    public (int X, int Y) GetMove()
    {
        throw new NotImplementedException();
    }

    public void Turn()
    {
        var move = GetMove();
        Move(move.X, move.Y);
    }
}