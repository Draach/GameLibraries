namespace Game.Inventories
{
    public interface IWeapon : IItem, IDurable
    {
        int AttackPower { get; set; }
        int RequiredLevel { get; set; }
        int RequiredStrength { get; set; }
        int RequiredAgility { get; set; }
        int RequiredIntellect { get; set; }
        int RequiredStamina { get; set; }
    }
}