namespace Game.Inventories
{
    public interface IDurable
    {
        int Durability { get; set; }
        int MaxDurability { get; set; }
    }
}