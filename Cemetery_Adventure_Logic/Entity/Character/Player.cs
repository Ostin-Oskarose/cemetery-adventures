namespace Cemetery_Adventure_Logic.Entity.Character;

public class Player : Character
{

    public override char Symbol => '@';
    private ConsoleKeyInfo _keyInfo = new ConsoleKeyInfo();
    private ConsoleKey _consoleKey = new ConsoleKey();

    public Player(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position, maxHP, damage, defense)
    {
    }

    public override (int X, int Y) GetMove()
    {
        (int X,int Y) move;
        if (Console.KeyAvailable)
        {
            _keyInfo = Console.ReadKey(true);
            _consoleKey = _keyInfo.Key;
        }
        //ConsoleKeyInfo inputInfo = Console.ReadKey(true);
        //switch (inputInfo.Key)
        switch (_consoleKey)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                move = (Position.X, Position.Y - 1);
                break;
            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                move = (Position.X + 1, Position.Y); 
                break;
            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                move = (Position.X, Position.Y + 1);
                break;
            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                move = (Position.X - 1, Position.Y);
                break;
            default:
                move = Position;
                break;
        }

        _consoleKey = ConsoleKey.X;
        return move;
    }

    public void Turn()
    {
        var move = GetMove();
        Move(move.X, move.Y);
    }
}