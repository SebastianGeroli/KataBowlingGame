using System.Collections.Generic;
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

    
    [TestCase(70,3,4,3,4,3,4,3,4,3,4,3,4,3,4,3,4,3,4,3,4)]
    [TestCase(190,9,1,9,1,9,1,9,1,9,1,9,1,9,1,9,1,9,1,9,1,9)]
    [TestCase(237,10,10,10,10,10,10,10,10,9,0,0,0)]
    [TestCase(257,10,10,10,10,10,10,10,10,9,0,10,9,1)]
    [TestCase(264,10,10,10,10,10,10,10,10,10,8,0)]
    [TestCase(300,10,10,10,10,10,10,10,10,10,10,10,10)]
    public void ReturnCorrectScoreWithShootsTaken(int expected, params int[] shoots)
    {
        //When
        foreach (var shoot in shoots)
        {
            _session.Shoot(shoot);
        }

        //Then
        Assert.AreEqual(expected, _session.Score);
    }
}