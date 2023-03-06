namespace Game.Inventories
{
    public interface IItem
    {
        public string Name { get; }
        public int ItemLevel { get; }
        public ItemRarity Rarity { get; }
        public int SellPrice { get; }
        public int BuyPrice { get; }
        public string Description { get; }
        public bool IsEquippable { get; }
        public bool IsStackable { get; }
        public int MaxStack { get; }
        public int RequiredLevel { get; }
        public int RequiredStrength { get; }
        public int RequiredAgility { get; }
        public int RequiredIntellect { get; }
        public int RequiredStamina { get; }
        public int AttackPower { get; }
        public int Defense { get; }
        public int Durability { get; }
        public int MaxDurability { get; }
        public int[] StatModifiers { get; } // an array of stats that are modified by the item
        public bool IsUsable { get; }
        public string UseAbility { get; } // the name of the ability granted by using the item
        public int UseAbilityCooldown { get; } // the cooldown time for the use ability
    }
}