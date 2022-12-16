using BattleSystem.Domain;
using BattleSystem.Domain.Service;
using NUnit.Framework;

namespace Tests.BattleSystem.Domain.Service
{
    public class RecoveryCalculatorTest
    {
        public RecoveryCalculator Calculator;

        [SetUp]
        public void SetupService()
        {
            Calculator = new RecoveryCalculator();
        }

        [Test]
        public void RecoveryCalculator_CanCalculateDirectRecoveryAsPositiveAmount()
        {
            var target = new Actor(5, 100);

            var amount = Calculator.DirectRecovery(target, 10);
            Assert.That(amount, Is.EqualTo(10));

            target = new Actor(95, 100);
            amount = Calculator.DirectRecovery(target, 10);
            Assert.That(amount, Is.EqualTo(5));
        }
    }
}