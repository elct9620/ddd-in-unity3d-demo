using BattleSystem.Domain;
using BattleSystem.Domain.Service;
using NUnit.Framework;

namespace Tests.BattleSystem.Domain.Service
{
    public class DamageCalculatorTest
    {
        public DamageCalculator Calculator;

        [SetUp]
        public void SetupService()
        {
            Calculator = new DamageCalculator();
        }

        [Test]
        public void DamageCalculator_CanCalculateDirectDamageAsPositiveAmount()
        {
            var from = new Actor(100, 100);
            var to = new Actor(100, 100);

            var amount = Calculator.DirectDamage(from, to, 10);
            Assert.That(amount, Is.EqualTo(10));

            to = new Actor(5, 100);
            amount = Calculator.DirectDamage(from, to, 10);
            Assert.That(amount, Is.EqualTo(5));
        }
    }
}