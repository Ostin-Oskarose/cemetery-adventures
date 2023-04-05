using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.Item.Equipment.Armor;
using Cemetery_Adventure_Logic.Item.Equipment.Weapon;

namespace Cemetery_Adventure_Logic
{
    public class GameLoading
    {
        public static Game PrepareGame(Dictionary<string, string> loadedGame)
        {
            int floor = int.Parse(loadedGame["floor"]);
            string playerName = loadedGame["player_name"];
            int maxHP = int.Parse(loadedGame["maxHP"]);
            int armorTypeNumber = int.Parse(loadedGame["armor_type"]);
            int weaponTypeNumber = int.Parse(loadedGame["weapon_type"]);
            var player = PreparePlayer(playerName, maxHP, armorTypeNumber, weaponTypeNumber);

            return new Game(player, floor);
        }

        private static Player PreparePlayer(string playerName, int maxHP, int? armorTypeNumber, int? weaponTypeNumber)
        {
            var inventory = new List<Item.Item>();

            if (armorTypeNumber != null)
            {
                var armorType = Enum.GetValues<ArmorTypes>()
                    .FirstOrDefault(armor => (int)armor == armorTypeNumber);
                inventory.Add(GetArmor(armorType));
            }

            if (weaponTypeNumber != null)
            {
                var weaponType = Enum.GetValues<WeaponTypes>()
                    .FirstOrDefault(weapon => (int)weapon == weaponTypeNumber);
                inventory.Add(GetWeapon(weaponType));
            }

            var player = new Player(playerName, (1, 1), maxHP, 5, 0);

            foreach (var item in inventory)
            {
                player.AddItemToInventory(item);
                player.UpdateStatistics(item);
            }

            return player;
        }

        private static Armor GetArmor(ArmorTypes armorType)
        {
            return armorType switch
            {
                ArmorTypes.ArmorOfLeather => new ArmorOfLeather(),
                ArmorTypes.ArmorOfWood => new ArmorOfWood(),
                ArmorTypes.ArmorOfBronze => new ArmorOfBronze(),
                ArmorTypes.ArmorOfSteel => new ArmorOfSteel(),
                ArmorTypes.ArmorOfDiamond => new ArmorOfDiamond(),
            };
        }

        private static Weapon GetWeapon(WeaponTypes weaponType)
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
