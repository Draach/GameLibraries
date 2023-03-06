namespace Game.Inventories
{
    public interface IAccessory : IItem, IDurable, IEquippable
    {
        int Strength { get; }
        int Agility { get; }
        int Intellect { get; }
        int Stamina { get; }
    }
}