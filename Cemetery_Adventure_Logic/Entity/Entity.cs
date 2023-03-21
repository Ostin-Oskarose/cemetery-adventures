using System.Runtime.CompilerServices;

namespace Cemetery_Adventure_Logic.Entity;

public abstract class Entity
{
    protected int X { get; private set; }
    protected int Y { get; private set; }
    protected int HP { get; private set; }
    protected int MaxHP { get; private set; }
    protected int Damage { get; private set; }
    protected int Defense { get; private set; }

    public virtual void Move(int x, int y)
    {
        X = x; 
        Y = y;
    }
}