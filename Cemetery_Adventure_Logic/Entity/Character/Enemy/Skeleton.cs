﻿using System.Security.Principal;

namespace Cemetery_Adventure_Logic.Entity.Character.Enemy;

public class Skeleton : Enemy
{

    public override char Symbol => Name[0];

    public override (int X, int Y) GetMove()
    {
        throw new NotImplementedException();
    }

    public Skeleton((int X, int Y) position, int maxHP, int damage, int defense) : base("Skeleton", position, maxHP, damage, defense)
    {
    }
}