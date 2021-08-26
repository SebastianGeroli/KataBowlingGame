using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Views;


public class MainScreenView : MonoBehaviour, IMainScreenView
{
    private MainScreenPresenter mainScreenPresenter;
    private TextMeshProUGUI txtFirstShootScore;
    [SerializeField] private TurnView[] turns = new TurnView[10];
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TextMeshProUGUI finalScore;

    public void Awake()
    {
        mainScreenPresenter = new MainScreenPresenter(this);
        CleanScreen();
    }

    private void CleanScreen()
    {
        for (int i = 0; i < turns.Length; i++)
        {
            turns[i].SetFirstShootScore("");
            turns[i].SetSecondShootScore("");
            turns[i].SetFinalScore("");
        }
    }

    public void Shoot()
    {
        mainScreenPresenter.Shoot();
    }

    public void ShowEndPanelGame()
    {
        endGamePanel.SetActive(true);
        finalScore.text = "Your final score is: " + mainScreenPresenter.GetFinalScore().ToString();
    }

    public void Refresh()
    {
        for (int i = 0; i < turns.Length; i++)
        {
            Turn turn = mainScreenPresenter.GetTurn(i);
            if (turn.IsStrike)
            {
                turns[i].SetFirstShootScore("X");
                turns[i].SetSecondShootScore("");
            }
            else if (turn.IsSpare)
            {
                turns[i].SetFirstShootScore(turn.ScoreFirstShoot.ToString());
                turns[i].SetSecondShootScore("/");
            }
            else
            {
                turns[i].SetFirstShootScore(turn.ScoreFirstShoot.ToString());
                turns[i].SetSecondShootScore(turn.ScoreSecondShoot.ToString());
            }

            if (mainScreenPresenter.GetActualTurnIndex() >= i)
                turns[i].SetFinalScore(turn.CalculatedScore.ToString());
        }
    }
}