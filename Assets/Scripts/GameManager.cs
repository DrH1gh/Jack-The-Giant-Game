using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    private Text coinText, scoreText, lifeText;

    [SerializeField]
    private GameObject pausePanel;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void SetCoinScore(int coin_score)
    {
        coinText.text = "x" + coin_score;
    }

    public void SetLifeScore(int life_score)
    {
        lifeText.text = "x" + life_score;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;


        //Destoy all instance. 
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("GameManager"));

        Application.LoadLevel("Menu");
    }
}
