using BattleSystem.Domain;
using NUnit.Framework;

namespace Tests.BattleSystem.Domain
{
    public class BattleTest
    {
        [Test]
        public void Battle_CanDamageSpecifyTarget()
        {
            var battle = new Battle(1);
            Assert.That(battle.Player.CurrentHp, Is.EqualTo(100));
            Assert.That(battle.Enemy.CurrentHp, Is.EqualTo(100));

            battle.Damage(Battle.Role.Enemy, 10);
            Assert.That(battle.Player.CurrentHp, Is.EqualTo(100));
            Assert.That(battle.Enemy.CurrentHp, Is.EqualTo(90));

            battle.Damage(Battle.Role.Player, 10);
            Assert.That(battle.Player.CurrentHp, Is.EqualTo(90));
            Assert.That(battle.Enemy.CurrentHp, Is.EqualTo(90));

            battle.Damage(Battle.Role.Enemy, 90);
            Assert.That(battle.Enemy.State, Is.EqualTo(Actor.ActorState.Dead));
            Assert.That(battle.Enemy.IsDead, Is.True);
        }

        [Test]
        public void Battle_CanRecoverSpecifyTarget()
        {
            var battle = new Battle(1);
            Assert.That(battle.Player.CurrentHp, Is.EqualTo(100));
            Assert.That(battle.Enemy.CurrentHp, Is.EqualTo(100));

            battle.Damage(Battle.Role.Player, 10);
            battle.Damage(Battle.Role.Enemy, 10);

            battle.Recover(Battle.Role.Player, 5);
            Assert.That(battle.Player.CurrentHp, Is.EqualTo(95));
            Assert.That(battle.Enemy.CurrentHp, Is.EqualTo(90));

            battle.Recover(Battle.Role.Enemy, 5);
            Assert.That(battle.Player.CurrentHp, Is.EqualTo(95));
            Assert.That(battle.Enemy.CurrentHp, Is.EqualTo(95));
        }
    }
}