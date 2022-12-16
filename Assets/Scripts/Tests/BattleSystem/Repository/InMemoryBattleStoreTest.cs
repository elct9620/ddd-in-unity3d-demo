using BattleSystem.Repository;
using NUnit.Framework;

namespace Tests.BattleSystem.Repository
{
    public class InMemoryBattleStoreTest
    {
        public InMemoryBattleStore Store;
        
        [SetUp]
        public void SetupStore()
        {
            Store = new InMemoryBattleStore();
        }
        
        [Test]
        public void InMemoryBattleStore_CanCreateNewBattle()
        {
            var battle = Store.Create();
            Assert.That(battle.ID, Is.EqualTo(1));

            battle = Store.Create();
            Assert.That(battle.ID, Is.EqualTo(2));
        }

        [Test]
        public void InMemoryBattleStore_CanFindBattle()
        {
            var battle = Store.Find(1);
            Assert.That(battle, Is.Null);

            Store.Create();
            battle = Store.Find(1);
            Assert.That(battle.ID, Is.EqualTo(1));

        }
    }
}