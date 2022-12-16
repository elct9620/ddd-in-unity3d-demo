using BattleSystem.Domain;
using NUnit.Framework;

namespace Tests.BattleSystem.Domain
{
    public class ActorTest
    {
        [Test]
        public void Actor_CanBeDamaged()
        {
            var actor = new Actor(100, 100);
            Assert.That(actor.CurrentHp, Is.EqualTo(100));

            actor.Damage(10);
            Assert.That(actor.CurrentHp, Is.EqualTo(90));
        }

        [Test]
        public void Actor_CanBeRecovered()
        {
            var actor = new Actor(50, 100);
            Assert.That(actor.CurrentHp, Is.EqualTo(50));

            actor.Recover(10);
            Assert.That(actor.CurrentHp, Is.EqualTo(60));
        }

        [Test]
        public void Actor_CanRefreshState()
        {
            var actor = new Actor(100, 100);
            Assert.That(actor.State, Is.EqualTo(Actor.ActorState.Alive));

            actor.Damage(100);
            actor.RefreshState();

            Assert.That(actor.State, Is.EqualTo(Actor.ActorState.Dead));
            Assert.That(actor.IsDead, Is.True);
        }
    }
}