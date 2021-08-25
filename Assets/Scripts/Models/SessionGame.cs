using System.Collections.Generic;
using log4net.Util;

public class SessionGame
{
    int actualIndexTurn = 0;
    private Turn[] _turns = new Turn[10];
    private int _firstBonusShoot = 0;
    private int _secondBonusShoot = 0;
    public int Score => CalculateScore();

    public SessionGame()
    {
        for (int i = 0; i < _turns.Length; i++)
        {
            _turns[i] = new Turn();
        }
    }

    private int CalculateScore()
    {
        int score = 0;
        for (int i = 0; i < _turns.Length; i++)
        {
            score += GetTurnScore(i);
        }

        return score;
    }

    private int GetTurnScore(int i)
    {
        if (!_turns[i].IsCompleted) return 0;

        if (_turns[i].IsSpare)
        {
            if (i == _turns.Length - 1)
            {
                return _turns[i].Score + _firstBonusShoot;
            }

            return _turns[i].Score + _turns[i + 1].ScoreFirstShoot;
        }

        if (_turns[i].IsStrike)
        {
            if (i == _turns.Length - 1)
            {
                return _turns[i].Score + _firstBonusShoot + _secondBonusShoot;
            }

            if (_turns[i + 1].IsStrike)
            {
                if (i < _turns.Length - 2)
                {
                    return _turns[i + 2].IsCompleted
                        ? _turns[i].Score + _turns[i + 1].Score + _turns[i + 2].ScoreFirstShoot
                        : 0;
                }

                return _turns[i].Score + _turns[i + 1].Score + _firstBonusShoot;
            }

            return _turns[i + 1].IsCompleted ? _turns[i].Score + _turns[i + 1].Score : 0;
        }

        return _turns[i].Score;
    }

    public IEnumerable<Turn> GetTurns()
    {
        return _turns;
    }

    public void Shoot(int amount)
    {
        if (actualIndexTurn == 10)
        {
            actualIndexTurn++;
            _firstBonusShoot = amount;
            return;
        }

        if (actualIndexTurn == 11)
        {
            actualIndexTurn++;
            _secondBonusShoot = amount;
            return;
        }

        if (_turns.Length <= actualIndexTurn) return;

        if (_turns[actualIndexTurn].IsCompleted)
        {
            actualIndexTurn++;
            Shoot(amount);
            return;
        }

        _turns[actualIndexTurn].Shoot(amount);
    }
}