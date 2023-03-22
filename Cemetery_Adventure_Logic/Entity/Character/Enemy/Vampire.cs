namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Vampire : Enemy
    {
        public override char Symbol => Name[0];

        public Vampire((int X, int Y) position, int maxHP = 50, int damage = 15, int defense = 15) : base("Vampire", position, maxHP, damage, defense)
        {
        }

        public override (int X, int Y) GetMove()
        {
            throw new NotImplementedException();
        }
    }
}
