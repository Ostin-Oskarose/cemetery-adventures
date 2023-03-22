namespace Cemetery_Adventure_Logic.Entity.Character;

public abstract class Character : Entity
{
    protected int HP { get; private set; }
    protected int MaxHP { get; private set; }
    protected int Damage { get; private set; }
    protected int Defense { get; private set; }

    protected List<Item.Item> Inventory = new List<Item.Item>();

    protected Character(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position)
    {
        HP = maxHP;
        MaxHP = maxHP;
        Damage = damage;
        Defense = defense;
    }

    public abstract (int X, int Y) GetMove();

    public virtual void Attack(Character target)
    {
        target.ApplyDamage(Damage);
    }

    public virtual void ApplyDamage(int damage)
    {
        damage -= Defense;
        if (damage < 0) damage = 0;
        HP -= damage;
    }

    public virtual void Move(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }

    
}