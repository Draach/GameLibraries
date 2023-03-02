using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Moq;
using NUnit.Framework;

namespace Game.BattleSystem.Tests
{
    // TODO: Review if I'm moving lambdas to named methods.
    [TestFixture]
    public class BattleSystem_Test
    {
        private uint initialAvailableHealthPoints;
        private uint initialMaximumHealthPoints;
        private Mock<IHealth> healthMock;
        private IBattleSystem battleSystem;

        [SetUp]
        public void SetUp()
        {
            initialAvailableHealthPoints = 70;
            initialMaximumHealthPoints = 100;
            healthMock = new Mock<IHealth>();
            healthMock.Setup(x => x.AvailableHealthPoints).Returns(initialAvailableHealthPoints);
            healthMock.Setup(x => x.MaximumHealthPoints).Returns(initialMaximumHealthPoints);
            battleSystem = new BattleSystem(healthMock.Object);
        }

        [Test]
        public void BattleSystem_Heal()
        {
            uint amountToHeal = 5;
            healthMock.Setup(x => x.AddHealthPoints(It.IsAny<uint>(), It.IsAny<HealthPointsOperationOptions>()))
                .Callback(
                    () =>
                    {
                        healthMock.Setup(x => x.AvailableHealthPoints)
                            .Returns(initialAvailableHealthPoints + amountToHeal);
                    });
            battleSystem.Heal(amountToHeal);

            Assert.AreEqual(initialAvailableHealthPoints + amountToHeal, battleSystem.AvailableHealthPoints);
        }

        [Test]
        public void BattleSystem_Hurt()
        {
            uint amountToHurt = 5;
            healthMock.Setup(x => x.SubstractHealthPoints(It.IsAny<uint>(), It.IsAny<HealthPointsOperationOptions>()))
                .Callback(
                    () =>
                    {
                        healthMock.Setup(x => x.AvailableHealthPoints)
                            .Returns(initialAvailableHealthPoints - amountToHurt);
                    });
            battleSystem.Hurt(amountToHurt);

            Assert.AreEqual(initialAvailableHealthPoints - amountToHurt, battleSystem.AvailableHealthPoints);
        }

        [Test]
        public void BattleSystem_IncreaseMaximumHeart()
        {
            uint amountToIncrese = 10;
            healthMock.Setup(x => x.IncreaseMaximumHealthPoints(It.IsAny<uint>())).Callback(() =>
            {
                healthMock.Setup(x => x.MaximumHealthPoints).Returns(initialMaximumHealthPoints + amountToIncrese);
                healthMock.Setup(x => x.AvailableHealthPoints).Returns(initialMaximumHealthPoints + amountToIncrese);
            });
            battleSystem.IncreaseMaximumHealth(amountToIncrese);

            Assert.AreEqual(initialMaximumHealthPoints + amountToIncrese, battleSystem.AvailableHealthPoints);
            Assert.AreEqual(initialMaximumHealthPoints + amountToIncrese, battleSystem.MaximumHealthPoints);
        }

        [Test]
        public void BattleSystem_OnHealthChanged()
        {
            Subject<IHealth> healthSubject = new Subject<IHealth>();
            IObservable<IHealth> healthObservable = healthSubject.AsObservable();

            healthMock.Setup(x => x.OnHealthPointsChanged).Returns(healthObservable);
            healthMock.Setup(x => x.AddHealthPoints(It.IsAny<uint>(), It.IsAny<HealthPointsOperationOptions>()))
                .Callback(
                    () => { healthSubject.OnNext(new Health(0)); });

            IHealth receivedHealth = null;
            battleSystem.OnHealthChanged.Subscribe(health => { receivedHealth = health; });
            battleSystem.Heal(1);

            Assert.IsNotNull(receivedHealth);
        }
    }
}