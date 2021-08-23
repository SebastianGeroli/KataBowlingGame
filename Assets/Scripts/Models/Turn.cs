using UnityEngine.Networking;

public class Turn
{
    private int _shootNumber = 0;

    private int[] _shoots = new int[2];

    public int Score => Result();

    public void Shoot(int amountOfPinesFallen)
    {
        if (amountOfPinesFallen < 0) return;
        if (_shootNumber >= _shoots.Length) return;
        _shoots[_shootNumber] = amountOfPinesFallen;
        _shootNumber++;
    }

    public bool IsStrike => GetIsStrike();
    public bool IsSpare => GetIsSpare();

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