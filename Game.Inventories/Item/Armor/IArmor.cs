namespace Game.Inventories
{
    public interface IArmor : IItem, IDurable
    {
        int Defense { get; set; }
        int RequiredLevel { get; set; }
        int RequiredStrength { get; set; }
        int RequiredAgility { get; set; }
        int RequiredIntellect { get; set; }
        int RequiredStamina { get; set; }
    }
}