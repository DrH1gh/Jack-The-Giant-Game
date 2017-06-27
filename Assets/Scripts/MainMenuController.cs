using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : Singleton<MainMenuController> {

    // Use this for initialization
    void Start () {
        //Using Instance, activate the singleton pattern.
       // Instance.StartGame();
	}
	
	
    public void StartGame()
    {
        Application.LoadLevel("Game");
    }

    public void HighScore()
    {
        Application.LoadLevel("Highscore");
    }

    public void Options()
    {
        Application.LoadLevel("Options");
    }

    public void Music()
    {
        
    }
}
