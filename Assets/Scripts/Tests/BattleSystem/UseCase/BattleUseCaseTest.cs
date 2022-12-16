using BattleSystem.Domain.Service;
using BattleSystem.Repository;
using BattleSystem.UseCase;
using NUnit.Framework;
using UnityEngine.UIElements;

namespace Tests.BattleSystem.UseCase
{
    public class BattleUseCaseTest
    {
        public BattleUseCase UseCase;
        
        [SetUp]
        public void SetupUseCase()
        {
            var store = new InMemoryBattleStore();
            var damageService = new DamageCalculator();
            var recoveryService = new RecoveryCalculator();
            
            UseCase = new BattleUseCase(store, damageService, recoveryService);
        }

        [Test]
        public void BattleUseCase_CanCreateANewBattle()
        {
            var res = UseCase.Init();
            Assert.That(res.id, Is.EqualTo(1));
            Assert.That(res.playerHP, Is.EqualTo(100));
            Assert.That(res.playerMaxHP, Is.EqualTo(100));
            Assert.That(res.enemyHP, Is.EqualTo(100));
            Assert.That(res.enemyMaxHP, Is.EqualTo(100));
        }

        [Test]
        public void BattleUseCase_CanAttackEnemyWithFixAmount()
        {
            UseCase.Init();
            var res = UseCase.Attack(1, 10);
            Assert.That(res.playerHP, Is.EqualTo(100));
            Assert.That(res.enemyHP, Is.EqualTo(90));
        }

        [Test]
        public void BattleUseCase_CanRecoveryPlayerHP()
        {
            UseCase.Init();
            UseCase.EnemyAction(1);
            
            var res = UseCase.Recovery(1, 1);
            Assert.That(res.playerHP, Is.EqualTo(96));
            Assert.That(res.enemyHP, Is.EqualTo(100));
        }

        [Test]
        public void BattleUseCase_CanProcessAutoRecovery()
        {
            UseCase.Init();
            UseCase.Attack(1, 10);
            UseCase.EnemyAction(1);

            var res = UseCase.AutoRecovery(1);
            Assert.That(res.playerHP, Is.EqualTo(96));
            Assert.That(res.enemyHP, Is.EqualTo(91));
        }
    }
}