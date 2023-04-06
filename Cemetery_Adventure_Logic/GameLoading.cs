using Cemetery_Adventure_Logic.Entity.Character;
using Cemetery_Adventure_Logic.Item.Equipment.Armor;
using Cemetery_Adventure_Logic.Item.Equipment.Weapon;
using static Cemetery_Adventure_Logic.Item.ItemGenerator;

namespace Cemetery_Adventure_Logic
{
    public class GameLoading
    {
        public static Game PrepareGame(Dictionary<string, string> loadedGame)
        {
            int floor = int.Parse(loadedGame["floor"]);
            string playerName = loadedGame["player_name"];
            int maxHP = int.Parse(loadedGame["maxHP"]);
            int? armorTypeNumber = ConvertStringToInt(loadedGame["armor_type"]);
            int? weaponTypeNumber = ConvertStringToInt(loadedGame["weapon_type"]);
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
                inventory.Add(GenerateArmorItem(armorType));
            }

            if (weaponTypeNumber != null)
            {
                var weaponType = Enum.GetValues<WeaponTypes>()
                    .FirstOrDefault(weapon => (int)weapon == weaponTypeNumber);
                inventory.Add(GenerateWeaponItem(weaponType));
            }

            var player = new Player(playerName, (1, 1), maxHP, 5, 0);

            foreach (var item in inventory)
            {
                player.AddItemToInventory(item);
                player.UpdateStatistics(item);
            }

            return player;
        }

        private static int? ConvertStringToInt(string text)
        {
            return string.IsNullOrEmpty(text) ? null : int.Parse(text);
        }
    }
}
