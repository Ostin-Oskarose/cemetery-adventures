namespace Cemetery_Adventure_Logic.Entity.Character.Enemy;

public class Skeleton : Enemy
{
    public override char Symbol => Name[0];

    public Skeleton((int X, int Y) position, int maxHP = 20, int damage = 3, int defense = 5) : base("Skeleton", position, maxHP, damage, defense)
    {
    }
}