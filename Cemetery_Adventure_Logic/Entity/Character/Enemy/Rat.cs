namespace Cemetery_Adventure_Logic.Entity.Character.Enemy
{
    public class Rat : Enemy
    {
        public override char Symbol => Name[0];

        public Rat((int X, int Y) position, int maxHP = 5, int damage = 1, int defense = 0) : base("Rat", position, maxHP, damage, defense)
        {
        }

        public override (int X, int Y) GetMove()
        {
            throw new NotImplementedException();
        }
    }
}
