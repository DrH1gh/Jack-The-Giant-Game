using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePlayManager : Singleton<GamePlayManager> {

    [SerializeField]
    private Text coinText, scoreText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel, readyButton, pauseButton, mainCanvas;

    // Use this for initialization
    void Start () {
        //Only when you click ready, game starts!
        //THIS afects animations, and fade screen!
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
        pauseButton.SetActive(false);
        mainCanvas.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        mainCanvas.SetActive(true);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        pauseButton.SetActive(false);
        mainCanvas.SetActive(false);
        //Destoy all instance. 
        DestroyAllSingletons();

        //SceneManager.LoadScene("Menu");
        SceneFaderScript.Instance.LoadLevel("Menu");

    }

    public void GameOverShowFinalScore(int coinScore, int score)
    {
        gameOverPanel.SetActive(true);
        pauseButton.SetActive(false);
        mainCanvas.SetActive(false);
        gameOverScoreText.text = score.ToString();
        gameOverCoinText.text = coinScore.ToString();

        //After 4 seconds, go back to Main Menu
        StartCoroutine(GameOverLoadMainMenu());
    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(4f);
        gameOverPanel.SetActive(false);
        
        DestroyAllSingletons();
        //SceneManager.LoadScene("Menu");
        SceneFaderScript.Instance.LoadLevel("Menu");
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
        yield return new WaitForSeconds(0.5f);
        pauseButton.SetActive(false);
        mainCanvas.SetActive(false);
        //SceneManager.LoadScene("Game");
        SceneFaderScript.Instance.LoadLevel("Game");
        DestroyAllSingletons();

        yield return new WaitForSeconds(0.7f);
        pauseButton.SetActive(true);
        mainCanvas.SetActive(true);
    }
}
