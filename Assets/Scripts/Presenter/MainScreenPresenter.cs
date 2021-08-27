using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainScreenPresenter
{
    private readonly IMainScreenView _mainScreenView;
    private ISessionGame _sessionGame = new SessionGame();

    public MainScreenPresenter(IMainScreenView mainScreenView)
    {
        _mainScreenView = mainScreenView;
        _mainScreenView.CleanScreen();
    }

    public MainScreenPresenter(IMainScreenView mainScreenView, ISessionGame sessionGame) : this(mainScreenView)
    {
        _sessionGame = sessionGame;
    }


    public void Shoot()
    {
        _sessionGame.Shoot(Random.Range(0, 11));
        if (_sessionGame.IsFinished)
        {
            _mainScreenView.ShowEndPanelGame();
        }

        _mainScreenView.Refresh();
    }

    public Turn GetTurn(int i)
    {
        var turns = _sessionGame.GetTurns().ToArray();

        if (i < 0 || i >= turns.Length) return new Turn();

        return turns[i];
    }

    public int GetFinalScore()
    {
        return _sessionGame.Score;
    }

    public int GetActualTurnIndex()
    {
        return _sessionGame.GetActualTurnIndex;
    }

    public void NewGame()
    {
        _sessionGame = new SessionGame();
        _mainScreenView.CleanScreen();
    }
}