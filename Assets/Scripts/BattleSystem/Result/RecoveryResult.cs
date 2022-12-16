using System;

namespace BattleSystem.Result
{
    [Serializable]
    public readonly struct RecoveryResult
    {
        public readonly int enemyHP;
        public readonly int enemyMaxHP;
        public readonly int playerHP;
        public readonly int playerMaxHP;

        public RecoveryResult(int newPlayerHP, int newPlayerMaxHP, int newEnemyHP, int newEnemyMaxHP)
        {
            playerHP = newPlayerHP;
            playerMaxHP = newPlayerMaxHP;
            enemyHP = newEnemyHP;
            enemyMaxHP = newEnemyMaxHP;
        }
    }
}