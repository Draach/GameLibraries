namespace Game.Inventories
{
    public interface IItem
    {
        string Name { get; }
        int ItemLevel { get; }
        ItemRarity Rarity { get; }
        ItemKey ItemKey { get; }
        int SellPrice { get; }
        int BuyPrice { get; }
        string Description { get; }
        bool IsUnique { get; set; }
        bool IsEquippable { get; }
        bool IsStackable { get; }
        int MaxStack { get; }
    }
}

/*
public interface IItem
{
    string Name { get; set; }
    int ItemLevel { get; set; }
    RarityType Rarity { get; set; }
    int SellPrice { get; set; }
    int BuyPrice { get; set; }
    string Description { get; set; }
    bool IsUnique { get; set; }
    bool IsEquippable { get; set; }
    bool IsStackable { get; set; }
    int MaxStack { get; set; }
}

public interface IWeapon : IItem
{
    int AttackPower { get; set; }
    int Durability { get; set; }
    int MaxDurability { get; set; }
    int RequiredLevel { get; set; }
    int RequiredStrength { get; set; }
    int RequiredAgility { get; set; }
    int RequiredIntellect { get; set; }
    int RequiredStamina { get; set; }
}

public interface IArmor : IItem
{
    int Defense { get; set; }
    int Durability { get; set; }
    int MaxDurability { get; set; }
    int RequiredLevel { get; set; }
    int RequiredStrength { get; set; }
    int RequiredAgility { get; set; }
    int RequiredIntellect { get; set; }
    int RequiredStamina { get; set; }
}

public interface IConsumable : IItem
{
    bool IsUsable { get; set; }
    string UseAbility { get; set; }
    int UseAbilityCooldown { get; set; }
}

public abstract class Item : IItem
{
    public string Name { get; set; }
    public int ItemLevel { get; set; }
    public RarityType Rarity { get; set; }
    public int SellPrice { get; set; }
    public int BuyPrice { get; set; }
    public string Description { get; set; }
    public bool IsUnique { get; set; }
    public bool IsEquippable { get; set; }
    public bool IsStackable { get; set; }
    public int MaxStack { get; set; }
}

public class Weapon : Item, IWeapon
{
    public int AttackPower { get; set; }
    public int Durability { get; set; }
    public int MaxDurability { get; set; }
    public int RequiredLevel { get; set; }
    public int RequiredStrength { get; set; }
    public int RequiredAgility { get; set; }
    public int RequiredIntellect { get; set; }
    public int RequiredStamina { get; set; }
}

public class Armor : Item, IArmor
{
    public int Defense { get; set; }
    public int Durability { get; set; }
    public int MaxDurability { get; set; }
    public int RequiredLevel { get; set; }
    public int RequiredStrength { get; set; }
    public int RequiredAgility { get; set; }
    public int RequiredIntellect { get; set; }
    public int RequiredStamina { get; set; }
}

public class Consumable : Item, IConsumable
{
    public bool IsUsable { get; set; }
    public string UseAbility { get; set; }
    public int UseAbilityCooldown { get; set; }
}*/