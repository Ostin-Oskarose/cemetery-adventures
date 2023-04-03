namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Zombie : Enemy
    {
        public override char Symbol => Name[0];

        public Zombie((int X, int Y) position, int maxHP = 35, int damage = 10, int defense = 10) : base("Zombie", position, maxHP, damage, defense)
        {
        }
    }
}
