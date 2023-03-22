namespace Cemetery_Adventure_Logic.Entity
{
    public class BoardItem : Entity
    {
        public BoardItem((int X, int Y) position, string name) : base(name, position)
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
