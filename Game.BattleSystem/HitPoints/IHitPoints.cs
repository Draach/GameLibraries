using System;

namespace Game.BattleSystem
{
    public interface IHitPoints
    {
        IObservable<IHitPoints> OnHitPointsChanged { get; }
        uint MaximumHitPoints { get; }
        uint AvailableHitPoints { get; }
        void AddHitPoints(uint hitPoints, HitPointsOperationOptions options);
        void SubstractHitPoints(uint hitPoints, HitPointsOperationOptions options);
        void IncreaseMaximumHitPoints(uint amountToIncrease);
    }
}