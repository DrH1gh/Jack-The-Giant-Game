using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : Singleton<MainMenuController> {

    // Use this for initialization
    void Start () {
        //Using Instance, activate the singleton pattern.
       // Instance.StartGame();
	}
	
	
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void HighScore()
    {
        SceneManager.LoadScene("Highscore");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }

    public void Music()
    {
        
    }
}
