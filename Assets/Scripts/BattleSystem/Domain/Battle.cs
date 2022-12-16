using System;

namespace BattleSystem.Domain
{
    [Serializable]
    public class Battle
    {
        public enum Role
        {
            Player,
            Enemy
        }

        public Battle(int id)
        {
            ID = id;
            Player = new Actor(100, 100);
            Enemy = new Actor(100, 100);
        }

        public int ID { get; }

        public Actor Player { get; }

        public Actor Enemy { get; }

        public void Damage(Role targetRole, int amount)
        {
            var target = targetRole == Role.Player ? Player : Enemy;
            target.Damage(amount);
            target.RefreshState();
        }

        public void Recover(Role targetRole, int amount)
        {
            var target = targetRole == Role.Player ? Player : Enemy;
            target.Recover(amount);
        }
    }
}