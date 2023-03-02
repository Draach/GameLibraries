using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Game.BattleSystem
{
    public class HitPoints : IHitPoints
    {
        private Subject<IHitPoints> onHitPointsChanged = new Subject<IHitPoints>();
        public IObservable<IHitPoints> OnHitPointsChanged => onHitPointsChanged.AsObservable();
        public uint MaximumHitPoints { get; private set; }
        public uint AvailableHitPoints { get; private set; }

        public HitPoints(uint maximumHitPoints)
        {
            AvailableHitPoints = maximumHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }

        public HitPoints(uint initialAvailableHitPoints, uint maximumHitPoints)
        {
            AvailableHitPoints = initialAvailableHitPoints;
            MaximumHitPoints = maximumHitPoints;
        }

        private void HandleHitPointsSurplus()
        {
            if (AvailableHitPoints > MaximumHitPoints)
                AvailableHitPoints = MaximumHitPoints;
        }

        private void NotifyHitPointsChange()
        {
            onHitPointsChanged.OnNext(this);
        }

        public void AddHitPoints(uint hitPoints,
            HitPointsOperationOptions options = HitPointsOperationOptions.AsMuchAsPossible)
        {
            if (options == HitPointsOperationOptions.AllOrNothing)
            {
                if (AvailableHitPoints + hitPoints <= MaximumHitPoints)
                {
                    AvailableHitPoints += hitPoints;
                    NotifyHitPointsChange();
                }
                else
                {
                    // TODO: Create custom exception.
                    throw new Exception("Cannot replenish that amount of hitpoints.");
                }
            }
            else
            {
                AvailableHitPoints += hitPoints;
                HandleHitPointsSurplus();
                NotifyHitPointsChange();
            }
        }

        private bool CanSubstract(uint hitPoints)
        {
            return hitPoints <= AvailableHitPoints;
        }

        public void SubstractHitPoints(uint hitPoints,
            HitPointsOperationOptions options = HitPointsOperationOptions.AsMuchAsPossible)
        {
            if (CanSubstract(hitPoints))
            {
                AvailableHitPoints -= hitPoints;
                NotifyHitPointsChange();
            }
            else if (options == HitPointsOperationOptions.AsMuchAsPossible)
            {
                AvailableHitPoints = 0;
                NotifyHitPointsChange();
            }
            else
            {
                throw new Exception("Cannot substract that amount of hitpoints.");
            }
        }

        public void IncreaseMaximumHitPoints(uint amountToIncrease)
        {
            MaximumHitPoints += amountToIncrease;
            AvailableHitPoints = MaximumHitPoints;
            NotifyHitPointsChange();
        }
    }
}