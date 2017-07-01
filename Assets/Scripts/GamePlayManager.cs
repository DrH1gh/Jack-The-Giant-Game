using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : Singleton<GamePlayManager> {

    [SerializeField]
    private Text coinText, scoreText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel, readyButton;

    // Use this for initialization
    void Start () {
        //Only when you click ready, game starts!
        Time.timeScale = 0f;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown( KeyCode.Space ) || Input.GetKeyDown(KeyCode.Return)) {
            StartGame();
        }
	}

    public void StartGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
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
        readyButton.SetActive(false);
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
        DestroyAllSingletons();

        SceneManager.LoadScene("Menu");

    }

    public void GameOverShowFinalScore(int coinScore, int score)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = score.ToString();
        gameOverCoinText.text = coinScore.ToString();

        //After 4 seconds, go back to Main Menu
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(4f);

        DestroyAllSingletons();
        SceneManager.LoadScene("Menu");
    }

    public void DestroyAllSingletons()
    {
        //Destoy all instance. 
        Destroy(GameObject.Find("Main Camera"));
        Destroy(GameObject.Find("GamePlayManager"));
        Destroy(GameObject.Find("Player"));
       
    }

    public void PlayerDiedRestartGame()
    {

        StartCoroutine(PlayerDiedRestart());
        
    }

    IEnumerator PlayerDiedRestart()
    {
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene("Game");
        DestroyAllSingletons();
    }
}
