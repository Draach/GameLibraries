namespace Game.Inventories
{
    public interface IAccessory : IItem, IDurable
    {
        int RequiredLevel { get; set; }
        int Strength { get; }
        int Agility { get; }
        int Intellect { get; }
        int Stamina { get; }
    }
}