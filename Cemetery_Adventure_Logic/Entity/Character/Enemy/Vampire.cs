namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Vampire : Enemy
    {
        public override char Symbol => Name[0];

        public Vampire((int X, int Y) position, int maxHP = 50, int damage = 12, int defense = 10) : base("Vampire", position, maxHP, damage, defense)
        {
        }
    }
}
