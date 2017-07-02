using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : Singleton<MainMenuController> {


    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;


    // Use this for initialization
    void Start () {
        //Using Instance, activate the singleton pattern.
       // Instance.StartGame();
	}
	
    void CheckToPlayMusic()
    {
        if(GamePeferences.GetMusic() == 1)
        {
            MusicManager.Instance.PlayMusic(true);
        }
    }
	
    public void StartGame()
    {
        GameManager.Instance.NewGameFomMainMenu = true;
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
