using System.Linq;
using NUnit.Framework;

public class SessionGameShould
{
    private SessionGame _session;

    [SetUp]
    public void Before()
    {
        _session = new SessionGame();
    }

    [Test]
    public void Have_10_turns_to_be_valid()
    {
        //When
        var turnsCount = _session.GetTurns().ToList().Count();

        //Then
        Assert.AreEqual(10, turnsCount);
    }

    [Test]
    public void ScoreShouldReturn15()
    {
        
        //When
        _session.Shoot(0);
        _session.Shoot(10);
        _session.Shoot(5);
        //Then
        Assert.AreEqual(15, _session.Score);
    }

    [Test]
    public void ScoreShouldReturn20()
    {
        //When
        _session.Shoot(0);
        _session.Shoot(10);
        _session.Shoot(10);
        //Then
        Assert.AreEqual(20, _session.Score);
    }
}