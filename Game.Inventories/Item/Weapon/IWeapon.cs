namespace Game.Inventories
{
    public interface IWeapon : IItem, IDurable, IEquippable
    {
        int AttackPower { get; set; }
    }
}