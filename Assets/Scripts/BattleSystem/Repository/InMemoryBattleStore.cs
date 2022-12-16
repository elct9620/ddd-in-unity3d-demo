using System.Collections.Generic;
using BattleSystem.Domain;
using BattleSystem.UseCase;

namespace BattleSystem.Repository
{
    public class InMemoryBattleStore : IBattleRepository
    {
        private readonly Dictionary<int, Battle> _battles = new();
        private int _nextID = 1;

        public Battle Create()
        {
            var battle = new Battle(_nextID);
            _battles.Add(_nextID, battle);
            _nextID += 1;
            return battle;
        }

        public Battle Find(int id)
        {
            return _battles.ContainsKey(id) ? _battles[id] : null;
        }

        public bool SaveHealthPoint(int id, Battle.Role targetRole, int currentHp)
        {
            // InMemory store always synced
            return true;
        }
    }
}