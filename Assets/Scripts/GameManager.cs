using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    [HideInInspector]
    public bool RestartGamePlayerDied, NewGame;

    [HideInInspector]
    public int sessionScore, sessionCoinScore, sessionLifeScore;

    // Use this for initialization
    void Awake () {
        Instance.RestartGamePlayerDied = false;
        Instance.NewGame = true;
	}

    void Start()
    {
        GamePlay();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void GamePlay()
    {
        if (RestartGamePlayerDied) {
            GamePlayManager.Instance.SetScore(sessionScore);
            GamePlayManager.Instance.SetCoinScore(sessionCoinScore);
            GamePlayManager.Instance.SetLifeScore(sessionLifeScore);

            PlayerScore.Instance.score = sessionScore;
            PlayerScore.Instance.coinScore = sessionCoinScore;
            PlayerScore.Instance.lifeScore = sessionLifeScore;

        }else if (NewGame)
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
