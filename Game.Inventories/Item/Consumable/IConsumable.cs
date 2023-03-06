namespace Game.Inventories
{
    public interface IConsumable : IItem
    {
        bool IsUsable { get; set; }
    }
}