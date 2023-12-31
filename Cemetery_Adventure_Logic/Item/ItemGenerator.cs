﻿using Cemetery_Adventure_Logic.Entity.Character.Enemy;
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
                    itemToAdd = GenerateConsumableItem(GetRandomConsumableItem(random));
                    break;

                case ItemTypes.Armor:
                    itemToAdd = GenerateArmorItem(GetRandomArmorType(random));
                    break;

                case ItemTypes.Weapon:
                    itemToAdd = GenerateWeaponItem(GetRandomWeaponType(random));
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

        private static ConsumableTypes GetRandomConsumableItem(Random random)
        {
            int consumableTypesAmount = Enum.GetNames(typeof(ConsumableTypes)).Length;
            return Enum.GetValues<ConsumableTypes>()
                .FirstOrDefault(consumable => (int)consumable == random.Next(0, consumableTypesAmount));
        }

        private static ArmorTypes GetRandomArmorType(Random random)
        {
            int armorTypesAmount = Enum.GetNames(typeof(ArmorTypes)).Length;
            return Enum.GetValues<ArmorTypes>()
                .FirstOrDefault(
                    armor => (int)armor == random.Next(0, armorTypesAmount));
        }

        private static WeaponTypes GetRandomWeaponType(Random random)
        {
            int weaponTypesAmount = Enum.GetNames(typeof(WeaponTypes)).Length;
            return Enum.GetValues<WeaponTypes>()
                .FirstOrDefault(weapon => (int)weapon == random.Next(0, weaponTypesAmount));
        }

        public static Item GenerateConsumableItem(ConsumableTypes consumableType)
        {
            return consumableType switch
            {
                ConsumableTypes.HealthPotion => new HealthPotion(),
                ConsumableTypes.MaxHealthPotion => new MaxHealthPotion()
            };
        }

        public static Item GenerateArmorItem(ArmorTypes armorType)
        {
            return armorType switch
            {
                ArmorTypes.ArmorOfLeather => new ArmorOfLeather(),
                ArmorTypes.ArmorOfWood => new ArmorOfWood(),
                ArmorTypes.ArmorOfBronze => new ArmorOfBronze(),
                ArmorTypes.ArmorOfSteel => new ArmorOfSteel(),
                ArmorTypes.ArmorOfDiamond => new ArmorOfDiamond()
            };
        }

        public static Item GenerateWeaponItem(WeaponTypes weaponType)
        {
            return weaponType switch
            {
                WeaponTypes.WeaponOfWood => new WeaponOfWood(),
                WeaponTypes.WeaponOfBronze => new WeaponOfBronze(),
                WeaponTypes.WeaponOfSteel => new WeaponOfSteel(),
                WeaponTypes.WeaponOfDiamond => new WeaponOfDiamond()
            };
        }
    }
}
