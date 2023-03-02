using System;

namespace Game.BattleSystem
{
    public class BattleSystem : IBattleSystem
    {
        private IHealth health;
        public IObservable<IHealth> OnHealthChanged => health.OnHealthPointsChanged;
        public uint MaximumHealthPoints => health.MaximumHealthPoints;
        public uint AvailableHealthPoints => health.AvailableHealthPoints;

        public BattleSystem(IHealth health)
        {
            this.health = health;
        }

        public void Heal(uint healthPoints)
        {
            health.AddHealthPoints(healthPoints);
        }

        public void Hurt(uint healthPoints)
        {
            health.SubstractHealthPoints(healthPoints);
        }

        public void IncreaseMaximumHealth(uint healthPointsToIncrease)
        {
            health.IncreaseMaximumHealthPoints(healthPointsToIncrease);
        }
    }
}