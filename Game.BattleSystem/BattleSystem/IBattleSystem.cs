using System;

namespace Game.BattleSystem
{
    public interface IBattleSystem
    {
        IObservable<IHealth> OnHealthChanged { get; }
        uint MaximumHealthPoints { get; }
        uint AvailableHealthPoints { get; }
        void RestoreToFullHealth();
        void Heal(uint healthPoints, HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible);
        void Hurt(uint healthPoints, HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible);
        void IncreaseMaximumHealth(uint healthPointsToIncrease);
    }
}