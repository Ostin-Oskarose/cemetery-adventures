using Cemetery_Adventure_Logic.Entity.Character.Enemy;
using Cemetery_Adventure_Logic.Item.Consumable;
using Cemetery_Adventure_Logic.Item.Equipment.Armor;
using Cemetery_Adventure_Logic.Item.Equipment.Weapon;

namespace Cemetery_Adventure_Logic.Item
{
    public static class ItemGenerator
    {
        public static void GenerateItemToEnemy(Enemy enemy, int itemDropChance)
        {
            Random random = new Random();
            Item itemToAdd = null;

            switch (GetRandomItemType())
            {
                case ItemTypes.Consumable:
                    itemToAdd = GenerateConsumableItem(random);
                    break;

                case ItemTypes.Armor:
                    itemToAdd = GenerateArmorItem(random);
                    break;

                case ItemTypes.Weapon:
                    itemToAdd = GenerateWeaponItem(random);
                    break;
            }

            if (itemDropChance >= random.Next(0, 101)) enemy.AddItemToInventory(itemToAdd);
        }

        private static ItemTypes GetRandomItemType()
        {
            Random random = new Random();
            int itemTypeLength = Enum.GetNames(typeof(ItemTypes)).Length;
            return Enum.GetValues<ItemTypes>()
                .FirstOrDefault(type => (int)type == random.Next(0, itemTypeLength));
        }

        private static Item GenerateConsumableItem(Random random)
        {
            int consumableTypesAmount = Enum.GetNames(typeof(ConsumableTypes)).Length;
            var consumableType = Enum.GetValues<ConsumableTypes>()
                .FirstOrDefault(consumable => (int)consumable == random.Next(0, consumableTypesAmount));
            return consumableType switch
            {
                ConsumableTypes.HealthPotion => new HealthPotion("Health potion"),
                ConsumableTypes.MaxHealthPotion => new MaxHealthPotion("Increase Max HP")
            };
        }

        private static Item GenerateArmorItem(Random random)
        {
            int armorTypesAmount = Enum.GetNames(typeof(ArmorTypes)).Length;
            var armorType = Enum.GetValues<ArmorTypes>()
                .FirstOrDefault(
                    armor => (int)armor == random.Next(0, armorTypesAmount));
            return armorType switch
            {
                ArmorTypes.ArmorOfLeather => new ArmorOfLeather("Armor of leather"),
                ArmorTypes.ArmorOfWood => new ArmorOfWood("Armor of wood"),
                ArmorTypes.ArmorOfBronze => new ArmorOfBronze("Armor of bronze"),
                ArmorTypes.ArmorOfSteel => new ArmorOfSteel("Armor of steel"),
                ArmorTypes.ArmorOfDiamond => new ArmorOfDiamond("Armor of diamond")
            };
        }

        private static Item GenerateWeaponItem(Random random)
        {
            int weaponTypesAmount = Enum.GetNames(typeof(WeaponTypes)).Length;
            var weaponType = Enum.GetValues<WeaponTypes>()
                .FirstOrDefault(weapon => (int)weapon == random.Next(0, weaponTypesAmount));
            return weaponType switch
            {
                WeaponTypes.WeaponOfWood => new WeaponOfWood("Weapon of wood"),
                WeaponTypes.WeaponOfBronze => new WeaponOfBronze("Weapon of bronze"),
                WeaponTypes.WeaponOfSteel => new WeaponOfSteel("Weapon of steel"),
                WeaponTypes.WeaponOfDiamond => new WeaponOfDiamond("Weapon of diamond")
            };
        }
    }
}
