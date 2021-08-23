using System.Collections.Generic;

public class SessionGame
{
    private Turn[] _turns = new Turn[10];
    public int Score => CalculateScore();

    private int CalculateScore()
    {
        return 15;
    }

    public IEnumerable<Turn> GetTurns()
    {
        return _turns;
    }

    public void Shoot(int amount)
    {
        //
    }
}