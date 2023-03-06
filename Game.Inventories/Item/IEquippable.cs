namespace Game.Inventories
{
    public interface IEquippable
    {
        int RequiredLevel { get; }
        int RequiredStrength { get; set; }
        int RequiredAgility { get; set; }
        int RequiredIntellect { get; set; }
        int RequiredStamina { get; set; }
    }
}