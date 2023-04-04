namespace Cemetery_Adventure_Logic.Item.Consumable
{
    public class HealthPotion : Consumable
    {
        public int RestorePoints { get; set; }

        public HealthPotion(string name) : base(name)
        {
            RestorePoints = 20;
        }
    }
}
