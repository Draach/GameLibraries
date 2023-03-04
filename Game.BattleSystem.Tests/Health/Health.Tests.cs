using System;
using NUnit.Framework;

namespace Game.BattleSystem.Tests
{
    [TestFixture]
    public class Health_Tests
    {
        private IHealth health;
        private uint healthPointsToRefill;
        private uint initialAvailableHealthPointsAmount;
        private uint maximumHealthPointsAmount;

        [SetUp]
        public void SetUp()
        {
            initialAvailableHealthPointsAmount = 70;
            maximumHealthPointsAmount = 100;
            health = new Health(70, 100);
        }

        [Test]
        public void HealthPoints_Create()
        {
            health = new Health(maximumHealthPointsAmount);
            Assert.AreEqual(maximumHealthPointsAmount, health.MaximumHealthPoints);
            Assert.AreEqual(maximumHealthPointsAmount, health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_RestoreToFullHealth()
        {
            health.RestoreToFullHealth();

            Assert.AreEqual(health.MaximumHealthPoints, health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_OnHealthPointsChanged()
        {
            IHealth newHealth = null;
            health.OnHealthPointsChanged.Subscribe(hps => { newHealth = hps; });
            health.AddHealthPoints(1, HealthPointsOperationOptions.AsMuchAsPossible);
            Assert.IsNotNull(newHealth);
        }

        [Test]
        public void HealthPoints_AddHealthPointsAllOrNothing()
        {
            healthPointsToRefill = maximumHealthPointsAmount - initialAvailableHealthPointsAmount;
            health.AddHealthPoints(healthPointsToRefill, HealthPointsOperationOptions.AllOrNothing);
            Assert.AreEqual(initialAvailableHealthPointsAmount + healthPointsToRefill, health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_AddHealthPointsAllOrNothingException()
        {
            healthPointsToRefill = maximumHealthPointsAmount - initialAvailableHealthPointsAmount + 10;
            Assert.Catch<Exception>(() =>
                health.AddHealthPoints(healthPointsToRefill, HealthPointsOperationOptions.AllOrNothing));
        }

        [Test]
        public void HealthPoints_AddHealthPointsAsMuchAsPossible()
        {
            healthPointsToRefill = maximumHealthPointsAmount - initialAvailableHealthPointsAmount + 10;
            health.AddHealthPoints(healthPointsToRefill, HealthPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(health.AvailableHealthPoints, health.MaximumHealthPoints);
        }

        // TODO: Find a proper name for this test.
        [Test]
        public void HealthPoints_AddHalfOfRemainingHealthPointsAsMuchAsPossible()
        {
            healthPointsToRefill = (maximumHealthPointsAmount - initialAvailableHealthPointsAmount) / 2;
            health.AddHealthPoints(healthPointsToRefill, HealthPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(initialAvailableHealthPointsAmount + healthPointsToRefill, health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_SubstractAllHealthPointsOrNothing()
        {
            health.SubstractHealthPoints(initialAvailableHealthPointsAmount, HealthPointsOperationOptions.AllOrNothing);
            Assert.AreEqual(initialAvailableHealthPointsAmount - initialAvailableHealthPointsAmount,
                health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_SubstractAllHealthPointsOrNothingException()
        {
            Assert.Catch<Exception>(() =>
                health.SubstractHealthPoints(initialAvailableHealthPointsAmount + 1,
                    HealthPointsOperationOptions.AllOrNothing));
        }

        [Test]
        public void HealthPoints_SubstractHealthPointsAsMuchAsPossible()
        {
            health.SubstractHealthPoints(initialAvailableHealthPointsAmount,
                HealthPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(initialAvailableHealthPointsAmount - initialAvailableHealthPointsAmount,
                health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_SubstractHealthPointsAsMuchAsPossibleWithSurplus()
        {
            uint surplus = 5;
            health.SubstractHealthPoints(initialAvailableHealthPointsAmount + surplus,
                HealthPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(0,
                health.AvailableHealthPoints);
        }

        [Test]
        public void HealthPoints_IncreaseMaximumHealthPoints()
        {
            uint healthPointsToIncrease = 50;
            health.IncreaseMaximumHealthPoints(healthPointsToIncrease);
            Assert.AreEqual(maximumHealthPointsAmount + healthPointsToIncrease, health.MaximumHealthPoints);
            Assert.AreEqual(maximumHealthPointsAmount + healthPointsToIncrease, health.AvailableHealthPoints);
        }
    }
}