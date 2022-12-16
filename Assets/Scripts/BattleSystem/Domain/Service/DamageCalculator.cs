using System;

namespace BattleSystem.Domain.Service
{
    public class DamageCalculator
    {
        public int DirectDamage(Actor from, Actor to, int referenceBase)
        {
            if (to.CurrentHp - referenceBase <= 0) return Math.Max(0, to.CurrentHp);

            return Math.Min(referenceBase, to.MaxHp);
        }
    }
}