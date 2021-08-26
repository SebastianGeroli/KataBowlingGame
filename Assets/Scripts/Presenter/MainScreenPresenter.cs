using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MainScreenPresenter
{
    IMainScreenView mainScreenView;
    private SessionGame sessionGame = new SessionGame();

    public MainScreenPresenter(IMainScreenView mainScreenView)
    {
        this.mainScreenView = mainScreenView;
    }


    public void Shoot()
    {
        sessionGame.Shoot(Random.Range(0, 11));
        _ = sessionGame.Score;
        if (sessionGame.isFinished)
        {
            mainScreenView.ShowEndPanelGame();
        }

        mainScreenView.Refresh();
    }

    public Turn GetTurn(int i)
    {
        var turns = sessionGame.GetTurns().ToArray();
        return turns[i];
    }

    public int GetFinalScore()
    {
        return sessionGame.Score;
    }

    public int GetActualTurnIndex()
    {
        return sessionGame.GetActualTurnIndex;
    }

    public void NewGame()
    {
        sessionGame = new SessionGame();
    }
}