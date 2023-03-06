namespace Game.Inventories
{
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public int ItemLevel { get; set; }
        public ItemRarity Rarity { get; }
        public ItemKey ItemKey { get; }
        public int SellPrice { get; set; }
        public int BuyPrice { get; set; }
        public string Description { get; set; }
        public bool IsUnique { get; set; }
        public bool IsEquippable { get; set; }
        public bool IsStackable { get; set; }
        public int MaxStack { get; set; }
    }
}