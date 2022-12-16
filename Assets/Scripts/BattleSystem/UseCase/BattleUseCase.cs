using BattleSystem.Domain;
using BattleSystem.Domain.Service;
using BattleSystem.Result;

namespace BattleSystem.UseCase
{
    public class BattleUseCase
    {
        private readonly IBattleRepository _battles;
        private DamageCalculator _damageCalculator;
        private RecoveryCalculator _recoveryCalculator;

        public BattleUseCase(IBattleRepository battles, DamageCalculator damageCalculator,
            RecoveryCalculator recoveryCalculator)
        {
            _battles = battles;
            _damageCalculator = damageCalculator;
            _recoveryCalculator = recoveryCalculator;
        }

        public BattleInitResult Init()
        {
            Battle battle = _battles.Create();
            return new BattleInitResult(
                battle.ID,
                battle.Player.CurrentHp, battle.Player.MaxHp,
                battle.Enemy.CurrentHp, battle.Enemy.MaxHp
            );
        }

        public AttackResult Attack(int id, int amount)
        {
            Battle battle = _battles.Find(id);
            int calculatedAmount = _damageCalculator.DirectDamage(battle.Player, battle.Enemy, amount);
            battle.Damage(Battle.Role.Enemy, calculatedAmount);
            _battles.SaveHealthPoint(id, Battle.Role.Enemy, battle.Enemy.CurrentHp);

            return new AttackResult(
                battle.Player.CurrentHp, battle.Player.MaxHp,
                battle.Enemy.CurrentHp, battle.Enemy.MaxHp
            );
        }

        public RecoveryResult Recovery(int id, int amount)
        {
            Battle battle = _battles.Find(id);
            int calculatedAmount = _recoveryCalculator.DirectRecovery(battle.Player, amount);
            battle.Recover(Battle.Role.Player, calculatedAmount);
            _battles.SaveHealthPoint(id, Battle.Role.Player, battle.Player.CurrentHp);

            return new RecoveryResult(
                battle.Player.CurrentHp, battle.Player.MaxHp,
                battle.Enemy.CurrentHp, battle.Enemy.MaxHp
            );
        }

        public AttackResult EnemyAction(int id)
        {
            Battle battle = _battles.Find(id);
            int calculatedAmount = _damageCalculator.DirectDamage(battle.Enemy, battle.Player, 5);
            battle.Damage(Battle.Role.Player, calculatedAmount);
            _battles.SaveHealthPoint(id, Battle.Role.Player, battle.Enemy.CurrentHp);

            return new AttackResult(
                battle.Player.CurrentHp, battle.Player.MaxHp,
                battle.Enemy.CurrentHp, battle.Enemy.MaxHp
            );
        }

        public RecoveryResult AutoRecovery(int id)
        {
            Battle battle = _battles.Find(id);

            int calculatedPlayerAmount = _recoveryCalculator.DirectRecovery(battle.Player, 1);
            battle.Recover(Battle.Role.Player, calculatedPlayerAmount);
            _battles.SaveHealthPoint(id, Battle.Role.Player, battle.Player.CurrentHp);

            int calculatedEnemyAmount = _recoveryCalculator.DirectRecovery(battle.Enemy, 1);
            battle.Recover(Battle.Role.Enemy, calculatedEnemyAmount);
            _battles.SaveHealthPoint(id, Battle.Role.Enemy, battle.Enemy.CurrentHp);

            return new RecoveryResult(
                battle.Player.CurrentHp, battle.Player.MaxHp,
                battle.Enemy.CurrentHp, battle.Enemy.MaxHp
            );
        }
    }
}