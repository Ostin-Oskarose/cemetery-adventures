﻿namespace Cemetery_Adventure_Logic.Entity.Character;

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