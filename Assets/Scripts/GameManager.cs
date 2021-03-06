﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {

    [HideInInspector]
    public bool RestartGamePlayerDied, NewGameFomMainMenu;

    [HideInInspector]
    public int sessionScore, sessionCoinScore, sessionLifeScore;

    // Use this for initialization
    void Awake () {
        Instance.RestartGamePlayerDied = false;
        Instance.NewGameFomMainMenu = false;
	}

    void Start()
    {
        InitializeGamePref();
    }

    // Update is called once per frame
    void Update () {


    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 3) //gameplay scene!!
        {
            if (RestartGamePlayerDied)
            {
                GamePlayManager.Instance.SetScore(sessionScore);
                GamePlayManager.Instance.SetCoinScore(sessionCoinScore);
                GamePlayManager.Instance.SetLifeScore(sessionLifeScore);

                PlayerScore.Instance.score = sessionScore;
                PlayerScore.Instance.coinScore = sessionCoinScore;
                PlayerScore.Instance.lifeScore = sessionLifeScore;

            }
            else if (NewGameFomMainMenu)
            {
                PlayerScore.Instance.score = 0;
                PlayerScore.Instance.coinScore = 0;
                PlayerScore.Instance.lifeScore = 2;

                GamePlayManager.Instance.SetScore(PlayerScore.Instance.score);
                GamePlayManager.Instance.SetCoinScore(PlayerScore.Instance.coinScore);
                GamePlayManager.Instance.SetLifeScore(PlayerScore.Instance.lifeScore);
            }

        }
    }


    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        //GameOVER
        if(lifeScore < 0)
        {
            //From Prefeences
            if(GamePeferences.GetEasyDifficulty() == 1)
            {
                int _score = GamePeferences.GetEasyDiffScore();
                int _coin = GamePeferences.GetEasyDiffCoinScore();

                if(_score < score)
                    GamePeferences.SetEasyDiffScore(score);

                if (_coin < coinScore)
                    GamePeferences.SetEasyDiffCoinScore(coinScore);

            }

            if (GamePeferences.GetMediumDifficulty() == 1)
            {
                int _score = GamePeferences.GetMediumDiffScore();
                int _coin = GamePeferences.GetMediumDiffCoinScore();

                if (_score < score)
                    GamePeferences.SetMediumDiffScore(score);

                if (_coin < coinScore)
                    GamePeferences.SetMediumDiffCoinScore(coinScore);

            }

            if (GamePeferences.GetHardDifficulty() == 1)
            {
                int _score = GamePeferences.GetHardDiffScore();
                int _coin = GamePeferences.GetHardDiffCoinScore();

                if (_score < score)
                    GamePeferences.SetHardDiffScore(score);

                if (_coin < coinScore)
                    GamePeferences.SetHardDiffCoinScore(coinScore);

            }

            RestartGamePlayerDied = false;
            NewGameFomMainMenu = false;

            GamePlayManager.Instance.GameOverShowFinalScore(coinScore, score);
        }
        else
        {//Still have lifes
            sessionScore = score;
            sessionCoinScore = coinScore;
            sessionLifeScore = lifeScore;
            
            NewGameFomMainMenu = false;
            RestartGamePlayerDied = true;

            GamePlayManager.Instance.PlayerDiedRestartGame();

        }
    }

    private void InitializeGamePref()
    {
        if (!PlayerPrefs.HasKey("DRH Game Init 1"))
        {
            GamePeferences.SetEasyDifficulty(0);
            GamePeferences.SetEasyDiffScore(0);
            GamePeferences.SetEasyDiffCoinScore(0);
            //Default
            GamePeferences.SetMediuDifficulty(1); // true
            GamePeferences.SetMediumDiffScore(0);
            GamePeferences.SetMediumDiffCoinScore(0);

            GamePeferences.SetHardDifficulty(0);
            GamePeferences.SetHardDiffScore(0);
            GamePeferences.SetHardDiffCoinScore(0);

            GamePeferences.SetMusic(1); //on

            //Il pacalim prin salvaea de cheie
            PlayerPrefs.SetInt("DRH Game Init 1", 1);
        }
    }


}
