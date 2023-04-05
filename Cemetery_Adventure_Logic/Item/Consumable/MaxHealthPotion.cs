namespace Cemetery_Adventure_Logic.Item.Consumable
{
    public class MaxHealthPotion : Consumable
    {
        public int IncreseMaxHP { get; set; }
        public MaxHealthPotion(string name) : base(name)
        {
            IncreseMaxHP = 5;
        }
    }
}
