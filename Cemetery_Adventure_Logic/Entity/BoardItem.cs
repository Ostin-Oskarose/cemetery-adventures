namespace Cemetery_Adventure_Logic.Entity
{
    public class BoardItem : Entity
    {

        public override char Symbol => Name[0];

        public BoardItem((int X, int Y) position, string name) : base(name, position)
        {
        }
    }
}
