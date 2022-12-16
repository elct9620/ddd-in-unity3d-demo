using System;

namespace BattleSystem.Result
{
    [Serializable]
    public readonly struct BattleInitResult
    {
        public readonly int enemyHP;
        public readonly int enemyMaxHP;
        public readonly int id;

        public readonly int playerHP;
        public readonly int playerMaxHP;

        public BattleInitResult(int newId, int newPlayerHP, int newPlayerMaxHP, int newEnemyHP, int newEnemyMaxHP)
        {
            id = newId;
            playerHP = newPlayerHP;
            playerMaxHP = newPlayerMaxHP;
            enemyHP = newEnemyHP;
            enemyMaxHP = newEnemyMaxHP;
        }
    }
}