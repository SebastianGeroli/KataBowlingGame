using System.Linq;
using NUnit.Framework;

public class SessionGameShould
{

    [Test]
    public void Have_10_turns_to_be_valid()
    {
        //Given
        var session = new SessionGame();
        //When
        var turnsCount = session.GetTurns().ToList().Count();
        
        //Then
        Assert.AreEqual(10, turnsCount);
    }
    //
    // [Test]
    // public void 
}