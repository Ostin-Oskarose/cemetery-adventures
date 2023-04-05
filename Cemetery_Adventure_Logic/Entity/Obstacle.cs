namespace Cemetery_Adventure_Logic.Entity
{
    public class Obstacle : Entity
    {

        public override char Symbol => Name[0];

        public Obstacle((int X, int Y) position, string name) : base(name, position)
        {
        }
    }
}
