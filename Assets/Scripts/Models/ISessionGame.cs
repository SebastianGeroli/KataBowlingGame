using System.Collections.Generic;

public interface ISessionGame
{
    int Score { get; }
    bool IsFinished { get; }
    int GetActualTurnIndex { get; }
    void Shoot(int amount);
    IEnumerable<Turn> GetTurns();
}