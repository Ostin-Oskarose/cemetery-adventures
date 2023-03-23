using System.Xml.Serialization;

namespace Cemetery_Adventure_Logic.Entity.Character.Enemy;

public abstract class Enemy : Character
{
    protected (int X, int Y) LastKnownPosition { get; private set; }
    protected int SightRange { get; private set; }
    protected bool MovingToPlayer = false;

    protected Enemy(string name, (int X, int Y) position, int maxHP, int damage, int defense, int sightRange = 3) : base(name, position, maxHP, damage, defense)
    {
        SightRange = sightRange;
    }

    public override (int X, int Y) GetMove()
    {
        (int X, int Y) move;
        if (MovingToPlayer)
        {
            move = GetMoveTowardsPlayer();
        }
        else
        {
            move = GetRandomMove();
        }
        return move;
    }

    private (int X, int Y) GetMoveTowardsPlayer()
    {
        (int X, int Y) move;
        if (Position.X < LastKnownPosition.X)
        {
            move = (Position.X + 1, Position.Y);
        } else if (Position.X > LastKnownPosition.X)
        {
            move = (Position.X - 1, Position.Y);
        } else if (Position.Y < LastKnownPosition.Y)
        {
            move = (Position.X, Position.Y + 1);
        } else if (Position.Y > LastKnownPosition.Y)
        {
            move = (Position.X, Position.Y - 1);
        }
        else
        {
            move = Position;
            MovingToPlayer = false;
        }
        return move;
    }

    public void SearchForPlayer(Player player)
    {
        var playerPosition = player.Position;
        (int X, int Y) positionDelta = (playerPosition.X - Position.X, playerPosition.Y - Position.Y);
        var distance = Math.Sqrt(Math.Pow(Math.Abs(positionDelta.X), 2) + Math.Pow(Math.Abs(positionDelta.Y), 2));
        if (distance < SightRange)
        {
            LastKnownPosition = playerPosition;
            MovingToPlayer = true;
        }
    }

    private (int X, int Y) GetRandomMove()
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