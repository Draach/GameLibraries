using System;

namespace Game.BattleSystem
{
    public interface IHealth
    {
        IObservable<IHealth> OnHealthPointsChanged { get; }
        uint MaximumHealthPoints { get; }
        uint AvailableHealthPoints { get; }

        void AddHealthPoints(uint healthPoints,
            HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible);

        void SubstractHealthPoints(uint healthPoints,
            HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible);

        void IncreaseMaximumHealthPoints(uint amountToIncrease);
    }
}