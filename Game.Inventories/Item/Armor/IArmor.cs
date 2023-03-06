namespace Game.Inventories
{
    public interface IArmor : IItem, IDurable, IEquippable
    {
        ArmorType ArmorType { get; }
        int Defense { get; set; }
    }
}