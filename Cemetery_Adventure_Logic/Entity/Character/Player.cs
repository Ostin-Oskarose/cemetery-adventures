using Cemetery_Adventure_Logic.Item.Consumable;
using Cemetery_Adventure_Logic.Item.Equipment.Armor;
using Cemetery_Adventure_Logic.Item.Equipment.Weapon;

namespace Cemetery_Adventure_Logic.Entity.Character;

public class Player : Character
{

    public override char Symbol => '@';
    public Direction Direction { get; set; }

    public Player(string name, (int X, int Y) position, int maxHP, int damage, int defense) : base(name, position, maxHP, damage, defense)
    {
    }

    public override (int X, int Y) GetMove()
    {
        (int X, int Y) move;
        switch (Direction)
        {
            case Direction.Up:
                move = (Position.X, Position.Y - 1);
                break;
            case Direction.Right:
                move = (Position.X + 1, Position.Y);
                break;
            case Direction.Down:
                move = (Position.X, Position.Y + 1);
                break;
            case Direction.Left:
                move = (Position.X - 1, Position.Y);
                break;
            default:
                move = Position;
                break;
        }
        return move;
    }

    public bool CheckForKey()
    {
        return Inventory.Any(item => item.Name == "Key");
    }

    public bool SameTypeItem(Item.Item item)
    {
        foreach (var inventoryItem in Inventory)
        {
            if (((inventoryItem is Consumable) && (item is Consumable))
                || (inventoryItem is Armor) && (item is Armor)
                || (inventoryItem is Weapon) && (item is Weapon))
            {
                return true;
            }
        }

        return false;
    }

    public Item.Item WorstItem(Item.Item item)
    {
        Item.Item worstItem = item;
        foreach (var inventoryItem in Inventory)
        {
            if (inventoryItem.Name != "Key"
                && ((item is Armor armor && inventoryItem is Armor armorInventoryItem && CompareArmors(armorInventoryItem, armor))
                    || (item is Weapon weapon && inventoryItem is Weapon weaponInventoryItem && CompareWeapons(weaponInventoryItem, weapon))))
            {
                worstItem = inventoryItem;
            }
        }

        return worstItem;
    }

    private bool CompareArmors(Armor inventoryArmor, Armor floorArmor)
    {
        return inventoryArmor.Defense < floorArmor.Defense;
    }

    private bool CompareWeapons(Weapon inventoryWeapon, Weapon floorWeapon)
    {
        return inventoryWeapon.Damage < floorWeapon.Damage;
    }

    public void UpdateStatistics(Item.Item item)
    {
        if (item is Armor armor)
        {
            DefenseFromItem(armor.Defense);
            return;
        }

        if (item is Weapon weapon)
        {
            DamageFromItem(weapon.Damage);
            return;
        }

        if (item is HealthPotion healthPotion)
        {
            RestoreHealth(healthPotion.RestorePoints);
        }
        else if (item is MaxHealthPotion maxHealthPotion)
        {
            IncreaseMaxHP(maxHealthPotion.IncreaseMaxHP);
        }

        RemoveItemFromInventory(item.Name);
    }
}