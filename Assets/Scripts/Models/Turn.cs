using System;
using UnityEngine.Networking;

public class Turn
{
    private int _shootNumber = 0;

    private int[] _shoots = new int[2];
    public bool IsStrike => GetIsStrike();
    public bool IsSpare => GetIsSpare();

    public int Score => Result();
    public int ScoreFirstShoot => _shoots[0];
    public bool IsCompleted => CheckCompleted();
    public int ScoreSecondShoot => _shoots[1];

    public int CalculatedScore { get; set; } = 0;

    private bool CheckCompleted()
    {
        if (_shootNumber > 1) return true;
        return IsStrike;
    }

    public void Shoot(int amountOfPinesFallen)
    {
        if (amountOfPinesFallen > 10) return;
        if (amountOfPinesFallen < 0) return;
        if (_shootNumber >= _shoots.Length) return;
        if (_shootNumber == 1)
        {
            if (_shoots[0] + amountOfPinesFallen <= 10)
            {
                _shoots[_shootNumber] = amountOfPinesFallen;
            }
            else
            {
                _shoots[_shootNumber] = 10 - _shoots[0];
            }
        }
        else
        {
            _shoots[_shootNumber] = amountOfPinesFallen;
        }

        _shootNumber++;
    }

    private bool GetIsSpare()
    {
        if (IsStrike) return false;
        return (_shoots[0] + _shoots[1]) == 10;
    }

    private bool GetIsStrike()
    {
        return _shoots[0] == 10;
    }

    private int Result()
    {
        return (_shoots[0] + _shoots[1]) > 10 ? 10 : (_shoots[0] + _shoots[1]);
    }
}