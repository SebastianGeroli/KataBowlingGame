using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

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

    [Test]
    public void Be_Finished_After_All_Turns_Completed_And_Last_One_Is_Not_Strike_Or_Spare()
    {
        //When
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(3);
        _session.Shoot(4);
        //Then
        Assert.IsTrue(_session.IsFinished);
    }
    [Test]
    public void Be_Finished_After_All_Turns_Completed_And_Last_One_Is_Strike()
    {
        //When
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        //Last Turn
        _session.Shoot(10);
        //Bonus Shoots
        _session.Shoot(10);
        _session.Shoot(10);
        //Then
        Assert.IsTrue(_session.IsFinished);
    }
    [Test]
    public void Be_Finished_After_All_Turns_Completed_And_Last_One_Is_Spare()
    {
        //When
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        //Last Turn
        _session.Shoot(3);
        _session.Shoot(7);
        //Bonus Shoot
        _session.Shoot(10);
        //Then
        Assert.IsTrue(_session.IsFinished);
    }

    [Test]
    public void Not_Be_Finished_If_Any_Of_The_Turns_Are_Not_Completed()
    {
        _session.Shoot(10);
        _session.Shoot(3);
        _session.Shoot(4);
        //Then
        Assert.IsFalse(_session.IsFinished);
    }
    [Test]
    public void Not_Be_Finished_If_All_Turns_Completed_And_Last_One_Is_Strike_But_Bonus_Shoots_Have_Not_Been_Completed()
    {
        //When
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        //Last Turn
        _session.Shoot(10);
        //Bonus Shoots
        _session.Shoot(10);
        //Then
        Assert.IsFalse(_session.IsFinished);
    }
    
    [Test]
    public void Not_Be_Finished_If_All_Turns_Completed_And_Last_One_Is_Spare_But_Bonus_Shoot_Has_Not_Been_Made()
    {
        //When
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        _session.Shoot(10);
        //Last Turn
        _session.Shoot(9);
        _session.Shoot(1);
        //Then
        Assert.IsFalse(_session.IsFinished);
    }

}