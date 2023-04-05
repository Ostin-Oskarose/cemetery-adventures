namespace Cemetery_Adventure_Logic.Entity.Character;

public abstract class Character : Entity
{
    public int HP { get; private set; }
    public int MaxHP { get; private set; }
    public int Damage { get; private set; }
    public int Defense { get; private set; }

    protected List<Item.Item> Inventory = new List<Item.Item>();

    public bool IsAlive => HP > 0;

    protected Character(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position)
    {
        HP = maxHP;
        MaxHP = maxHP;
        Damage = damage;
        Defense = defense;
    }

    public abstract (int X, int Y) GetMove();

    public virtual int Attack(Character target)
    {
        return target.ApplyDamage(Damage);
    }

    public virtual int ApplyDamage(int damage)
    {
        damage -= Defense;
        if (damage <= 0) damage = 1;
        HP -= damage;
        return damage;
    }

    public virtual void Move(int x, int y)
    {
        Position.X = x;
        Position.Y = y;
    }

    public void AddItemToInventory(Item.Item item)
    {
        Inventory.Add(item);
    }

    public List<Item.Item> GetInventory()
    {
        return Inventory;
    }

    public void RemoveItemFromInventory(string itemName)
    {
        Inventory.RemoveAll(item => item.Name == itemName);
    }

    public void DamageFromItem(int damage)
    {
        Damage = damage;
    }

    public void DefenseFromItem(int defense)
    {
        Defense = defense;
    }

    public void RestoreHealth(int healthPoints)
    {
        HP += healthPoints;
        if (HP > MaxHP) HP = MaxHP;
    }

    public void IncreaseMaxHP(int maxHP)
    {
        MaxHP += maxHP;
    }
}