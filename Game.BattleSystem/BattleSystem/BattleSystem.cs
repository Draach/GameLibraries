using System;
using Game.Base;

namespace Game.BattleSystem
{
    public class BattleSystem : BaseClass, IBattleSystem
    {
        private IHealth health;
        public IObservable<IHealth> OnHealthChanged => health.OnHealthPointsChanged;
        public uint MaximumHealthPoints => health.MaximumHealthPoints;
        public uint AvailableHealthPoints => health.AvailableHealthPoints;

        public BattleSystem(IHealth health)
        {
            this.health = health;
        }

        public void RestoreToFullHealth()
        {
            health.RestoreToFullHealth();
        }

        public void Heal(uint healthPoints, HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible)
        {
            health.AddHealthPoints(healthPoints, options);
        }

        public void Hurt(uint healthPoints, HealthPointsOperationOptions options = HealthPointsOperationOptions.AsMuchAsPossible)
        {
            health.SubstractHealthPoints(healthPoints, options);
        }

        public void IncreaseMaximumHealth(uint healthPointsToIncrease)
        {
            health.IncreaseMaximumHealthPoints(healthPointsToIncrease);
        }
    }
}