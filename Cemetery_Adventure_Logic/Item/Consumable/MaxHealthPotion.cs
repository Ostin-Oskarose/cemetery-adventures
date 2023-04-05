namespace Cemetery_Adventure_Logic.Item.Consumable
{
    public class MaxHealthPotion : Consumable
    {
        public int IncreaseMaxHP { get; set; }
        public MaxHealthPotion() : base("Max HP Potion")
        {
            IncreaseMaxHP = 5;
        }
    }
}
