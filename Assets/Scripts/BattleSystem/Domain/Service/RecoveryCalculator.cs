namespace BattleSystem.Domain.Service
{
    public class RecoveryCalculator
    {
        public int DirectRecovery(Actor target, int referenceBase)
        {
            if (target.CurrentHp + referenceBase >= target.MaxHp) return target.MaxHp - target.CurrentHp;

            return referenceBase;
        }
    }
}