namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Zombie : Enemy
    {
        public override char Symbol => Name[0];

        public Zombie((int X, int Y) position, int maxHP = 35, int damage = 7, int defense = 7) : base("Zombie", position, maxHP, damage, defense)
        {
        }
    }
}
