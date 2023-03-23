namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Ghoul : Enemy
    {
        public override char Symbol => Name[0];

        public Ghoul((int X, int Y) position, int maxHP = 25, int damage = 7, int defense = 7) : base("Ghoul", position, maxHP, damage, defense)
        {
        }

        public override (int X, int Y) GetMove()
        {
            throw new NotImplementedException();
        }
    }
}
