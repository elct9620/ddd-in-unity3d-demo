using BattleSystem.Domain;

namespace BattleSystem.UseCase
{
    public interface IBattleRepository
    {
        public Battle Create();
        public Battle Find(int id);
        public bool SaveHealthPoint(int id, Battle.Role targetRole, int currentHp);
    }
}