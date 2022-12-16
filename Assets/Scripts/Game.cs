// Hardcode DI container

using BattleSystem.Domain;
using BattleSystem.Domain.Service;
using BattleSystem.Repository;
using BattleSystem.UseCase;

public class Game
{
    private BattleUseCase _battleUseCase;
    private IBattleRepository _battles;
    private DamageCalculator _damageCalculator;
    private RecoveryCalculator _recoveryCalculator;

    private static Game _instance;

    public static Game Instance => _instance ??= new Game();

    public BattleUseCase BattleUseCase =>
        _battleUseCase ??= new BattleUseCase(_battles, _damageCalculator, _recoveryCalculator);

    private Game()
    {
        _battles = new InMemoryBattleStore();
        _damageCalculator = new DamageCalculator();
        _recoveryCalculator = new RecoveryCalculator();
    }
}