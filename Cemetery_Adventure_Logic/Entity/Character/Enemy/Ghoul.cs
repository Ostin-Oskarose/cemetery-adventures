namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Ghoul : Enemy
    {
        public override char Symbol => Name[0];

        public Ghoul((int X, int Y) position, int maxHP = 25, int damage = 5, int defense = 5) : base("Ghoul", position, maxHP, damage, defense)
        {
        }
    }
}
