namespace Cemetery_Adventure_Logic.Item.Consumable
{
    public class HealthPotion : Consumable
    {
        public int RestorePoints { get; set; }

        public HealthPotion() : base("Health Potion")
        {
            RestorePoints = 20;
        }
    }
}
