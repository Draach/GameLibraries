using System;
using NUnit.Framework;

namespace Game.BattleSystem.Tests
{
    [TestFixture]
    public class HitPoints_Tests
    {
        private IHitPoints hitPoints;
        private uint hitPointsToRefill;
        private uint initialAvailableHitPointsAmount;
        private uint maximumHitPointsAmount;

        [SetUp]
        public void SetUp()
        {
            initialAvailableHitPointsAmount = 70;
            maximumHitPointsAmount = 100;
            hitPoints = new HitPoints(70, 100);
        }

        [Test]
        public void HitPoints_Create()
        {
            hitPoints = new HitPoints(maximumHitPointsAmount);
            Assert.AreEqual(maximumHitPointsAmount, hitPoints.MaximumHitPoints);
            Assert.AreEqual(maximumHitPointsAmount, hitPoints.AvailableHitPoints);
        }

        [Test]
        public void HitPoints_OnHitPointsChanged()
        {
            IHitPoints newHitPoints = null;
            hitPoints.OnHitPointsChanged.Subscribe(hps => { newHitPoints = hps; });
            hitPoints.AddHitPoints(1, HitPointsOperationOptions.AsMuchAsPossible);
            Assert.IsNotNull(newHitPoints);
        }

        [Test]
        public void HitPoints_AddHitPointsAllOrNothing()
        {
            hitPointsToRefill = maximumHitPointsAmount - initialAvailableHitPointsAmount;
            hitPoints.AddHitPoints(hitPointsToRefill, HitPointsOperationOptions.AllOrNothing);
            Assert.AreEqual(initialAvailableHitPointsAmount + hitPointsToRefill, hitPoints.AvailableHitPoints);
        }

        [Test]
        public void HitPoints_AddHitPointsAllOrNothingException()
        {
            hitPointsToRefill = maximumHitPointsAmount - initialAvailableHitPointsAmount + 10;
            Assert.Catch<Exception>(() =>
                hitPoints.AddHitPoints(hitPointsToRefill, HitPointsOperationOptions.AllOrNothing));
        }

        [Test]
        public void HitPoints_AddHitPointsAsMuchAsPossible()
        {
            hitPointsToRefill = maximumHitPointsAmount - initialAvailableHitPointsAmount + 10;
            hitPoints.AddHitPoints(hitPointsToRefill, HitPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(hitPoints.AvailableHitPoints, hitPoints.MaximumHitPoints);
        }

        // TODO: Find a proper name for this test.
        [Test]
        public void HitPoints_AddHalfOfRemainingHitPointsAsMuchAsPossible()
        {
            hitPointsToRefill = (maximumHitPointsAmount - initialAvailableHitPointsAmount) / 2;
            hitPoints.AddHitPoints(hitPointsToRefill, HitPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(initialAvailableHitPointsAmount + hitPointsToRefill, hitPoints.AvailableHitPoints);
        }

        [Test]
        public void HitPoints_SubstractAllHitPointsOrNothing()
        {
            hitPoints.SubstractHitPoints(initialAvailableHitPointsAmount, HitPointsOperationOptions.AllOrNothing);
            Assert.AreEqual(initialAvailableHitPointsAmount - initialAvailableHitPointsAmount,
                hitPoints.AvailableHitPoints);
        }

        [Test]
        public void HitPoints_SubstractAllHitPointsOrNothingException()
        {
            Assert.Catch<Exception>(() =>
                hitPoints.SubstractHitPoints(initialAvailableHitPointsAmount + 1,
                    HitPointsOperationOptions.AllOrNothing));
        }

        [Test]
        public void HitPoints_SubstractHitPointsAsMuchAsPossible()
        {
            hitPoints.SubstractHitPoints(initialAvailableHitPointsAmount, HitPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(initialAvailableHitPointsAmount - initialAvailableHitPointsAmount,
                hitPoints.AvailableHitPoints);
        }
        
        [Test]
        public void HitPoints_SubstractHitPointsAsMuchAsPossibleWithSurplus()
        {
            uint surplus = 5;
            hitPoints.SubstractHitPoints(initialAvailableHitPointsAmount + surplus, HitPointsOperationOptions.AsMuchAsPossible);
            Assert.AreEqual(0,
                hitPoints.AvailableHitPoints);
        }

        [Test]
        public void HitPoints_IncreaseMaximumHitPoints()
        {
            uint hitPointsToIncrease = 50;
            hitPoints.IncreaseMaximumHitPoints(hitPointsToIncrease);
            Assert.AreEqual(maximumHitPointsAmount + hitPointsToIncrease, hitPoints.MaximumHitPoints);
            Assert.AreEqual(maximumHitPointsAmount + hitPointsToIncrease, hitPoints.AvailableHitPoints);
        }
    }
}