using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighScoreController : Singleton<HighScoreController> {

    [SerializeField]
    private Text scoreText, cointText;

    // Use this for initialization
    void Start () {
        SetScoreByDifficulty();
    }

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        cointText.text = coinScore.ToString();
    }

    void SetScoreByDifficulty()
    {
        if(GamePeferences.GetEasyDifficulty() == 1)
        {
            SetScore(GamePeferences.GetEasyDiffScore(), GamePeferences.GetEasyDiffCoinScore());
        }

        if (GamePeferences.GetMediumDifficulty() == 1)
        {
            SetScore(GamePeferences.GetMediumDiffScore(), GamePeferences.GetMediumDiffCoinScore());
        }

        if (GamePeferences.GetHardDifficulty() == 1)
        {
            SetScore(GamePeferences.GetHardDiffScore(), GamePeferences.GetHardDiffCoinScore());
        }
    }
	
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
