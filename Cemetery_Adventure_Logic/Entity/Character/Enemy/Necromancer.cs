namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Necromancer : Enemy
    {
        public override char Symbol => Name[0];

        public Necromancer((int X, int Y) position, int maxHP = 70, int damage = 15, int defense = 12) : base("Necromancer", position, maxHP, damage, defense)
        {
        }
    }
}
