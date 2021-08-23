using System.Collections.Generic;

public class SessionGame
{
    private Turn[] _turns = new Turn[10];
    
    public IEnumerable<Turn> GetTurns()
    {
        return _turns;
    }
}