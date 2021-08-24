using System.Collections.Generic;

public class SessionGame
{
    int actualIndexTurn = 0;
    private Turn[] _turns = new Turn[10];
    public int Score => CalculateScore();

    public SessionGame()
    {
        for (int i=0;i<_turns.Length;i++) {
            _turns[i] = new Turn();
        }
    }

    private int CalculateScore()
    {
        int scoreFirstShoot = 0;
        for (int i=0;i<_turns.Length;i++) {
            if (_turns[i].IsSpare) {
                scoreFirstShoot = _turns[i + 1].ScoreFirstShoot;
                return _turns[i].Score + scoreFirstShoot;
            }
            
        }
        return scoreFirstShoot;
    }

    public IEnumerable<Turn> GetTurns()
    {
        return _turns;
    }

    public void Shoot(int amount)
    {
        if (_turns[actualIndexTurn].IsCompleted) {
            actualIndexTurn++;
            Shoot(amount);
            return;
        }
        _turns[actualIndexTurn].Shoot(amount);
    }
}