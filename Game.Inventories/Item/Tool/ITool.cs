namespace Game.Inventories
{
    public interface ITool
    {
        int RequiredLevel { get; set; }
        int RequiredStrength { get; set; }
        int RequiredAgility { get; set; }
        int RequiredIntellect { get; set; }
        int RequiredStamina { get; set; }
    }
}