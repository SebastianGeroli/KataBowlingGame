using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;

public class MainScreenPresenterShould
{
    private MainScreenPresenter _mainScreenPresenter;
    private IMainScreenView _view;
    private ISessionGame _sessionGame;

    [SetUp]
    public void Before()
    {
        _sessionGame = Substitute.For<ISessionGame>();
        _view = Substitute.For<IMainScreenView>();
        _mainScreenPresenter = new MainScreenPresenter(_view, _sessionGame);
    }

    [TestCase(3)]
    [TestCase(6)]
    [TestCase(12)]
    public void Refresh_View_After_Each_Shoot(int expectedCalls)
    {
        //When
        for (int i = 0; i < expectedCalls; i++)
        {
            _mainScreenPresenter.Shoot();
        }

        //Then
        _view.Received(expectedCalls).Refresh();
    }

    [Test]
    public void Call_EndGamePanel_If_Session_Is_Finished()
    {
        //Given
        _sessionGame.IsFinished.Returns(true);
        //When
        _mainScreenPresenter.Shoot();
        //Then
        _view.Received().ShowEndPanelGame();
    }

    [Test]
    public void ReturnSameScoreAsSession()
    {
        //Given
        _sessionGame.Score.Returns(300);

        //Then
        Assert.AreEqual(_sessionGame.Score, _mainScreenPresenter.GetFinalScore());
    }

    [Test]
    public void Return_Always_A_Valid_Turn()
    {
        var turns = new List<Turn>()
        {
            new Turn()
        };

        //Given
        _sessionGame.GetTurns().Returns(turns);

        //When
        var turn1 = _mainScreenPresenter.GetTurn(-1);
        var turn2 = _mainScreenPresenter.GetTurn(0);
        var turn3 = _mainScreenPresenter.GetTurn(1);

        //Then
        Assert.AreNotEqual(null, turn1);
        Assert.AreNotEqual(null, turn2);
        Assert.AreNotEqual(null, turn3);
    }

    [Test]
    public void Clean_The_Screen_When_Creating_A_New_Game()
    {
        //When
        _mainScreenPresenter.NewGame();

        //Then
        _view.Received().CleanScreen();
    }

    [Test]
    public void Return_Same_Index_As_Session()
    {
        //Given
        _sessionGame.GetActualTurnIndex.Returns(3);

        //When
        var index = _mainScreenPresenter.GetActualTurnIndex();

        //Then
        Assert.AreEqual(3, index);
    }
}