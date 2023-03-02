using System;

namespace Game.BattleSystem
{
    public interface IBattleSystem
    {
        IObservable<IHealth> OnHealthChanged { get; }
        uint MaximumHealthPoints { get; }
        uint AvailableHealthPoints { get; }
        void RestoreToFullHealth();
        void Heal(uint healthPoints);
        void Hurt(uint healthPoints);
        void IncreaseMaximumHealth(uint healthPointsToIncrease);
    }
}