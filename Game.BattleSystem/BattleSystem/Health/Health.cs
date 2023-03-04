using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Game.Base;

namespace Game.BattleSystem
{
    public class Health : BaseClass, IHealth
    {
        private Subject<IHealth> onHealthChanged = new Subject<IHealth>();
        public IObservable<IHealth> OnHealthPointsChanged => onHealthChanged.AsObservable();
        public uint MaximumHealthPoints { get; private set; }
        public uint AvailableHealthPoints { get; private set; }

        public Health(uint maximumHealthPoints)
        {
            AvailableHealthPoints = maximumHealthPoints;
            MaximumHealthPoints = maximumHealthPoints;
        }

        public Health(uint initialAvailableHealthPoints, uint maximumHealthPoints)
        {
            AvailableHealthPoints = initialAvailableHealthPoints;
            MaximumHealthPoints = maximumHealthPoints;
        }

        public void RestoreToFullHealth()
        {
            AvailableHealthPoints = MaximumHealthPoints;
        }

        private void HandleHealthPointsSurplus()
        {
            if (AvailableHealthPoints > MaximumHealthPoints)
                AvailableHealthPoints = MaximumHealthPoints;
        }

        private void NotifyHealthPointsChange()
        {
            onHealthChanged.OnNext(this);
        }

        public void AddHealthPoints(uint healthPoints,
            HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible)
        {
            if (options == HealthPointsOperationOptions.AllOrNothing)
            {
                AddAllOrNothing(healthPoints);
            }
            else
            {
                AvailableHealthPoints += healthPoints;
                HandleHealthPointsSurplus();
                NotifyHealthPointsChange();
            }
        }

        private void AddAllOrNothing(uint healthPoints)
        {
            if (CanAdd(healthPoints))
            {
                AvailableHealthPoints += healthPoints;
                NotifyHealthPointsChange();
            }
            else
            {
                // TODO: Create custom exception.
                throw new Exception("Cannot replenish that amount of health points.");
            }
        }

        private bool CanAdd(uint healthPoints)
        {
            return AvailableHealthPoints + healthPoints <= MaximumHealthPoints;
        }

        // TODO: Review if we should be able to lower the HealthPoints to 0. (Aka kill the character). <=
        private bool CanSubstract(uint healthPoints)
        {
            return healthPoints < AvailableHealthPoints;
        }

        public void SubstractHealthPoints(uint healthPoints,
            HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible)
        {
            if (CanSubstract(healthPoints))
            {
                AvailableHealthPoints -= healthPoints;
                NotifyHealthPointsChange();
            }
            else if (options == HealthPointsOperationOptions.AsMuchAsPossible)
            {
                AvailableHealthPoints = 0;
                NotifyHealthPointsChange();
            }
            else
            {
                throw new Exception("Cannot substract that amount of health points.");
            }
        }

        public void IncreaseMaximumHealthPoints(uint amountToIncrease)
        {
            MaximumHealthPoints += amountToIncrease;
            AvailableHealthPoints = MaximumHealthPoints;
            NotifyHealthPointsChange();
        }
    }
}