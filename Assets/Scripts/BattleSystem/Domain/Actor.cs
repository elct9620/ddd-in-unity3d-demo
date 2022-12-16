using System;

namespace BattleSystem.Domain
{
    [Serializable]
    public class Actor
    {
        public enum ActorState
        {
            Alive,
            Dead
        }


        public Actor(int currentHp, int maxHp)
        {
            CurrentHp = currentHp;
            MaxHp = maxHp;
        }

        public int CurrentHp { get; private set; }

        public int MaxHp { get; }

        public ActorState State { get; private set; } = ActorState.Alive;

        public bool IsDead => State == ActorState.Dead;

        public void Damage(int amount)
        {
            if (IsDead) return;

            CurrentHp -= amount;
        }

        public void Recover(int amount)
        {
            if (IsDead) return;

            CurrentHp += amount;
        }

        public void RefreshState()
        {
            if (CurrentHp > 0) return;

            State = ActorState.Dead;
        }
    }
}