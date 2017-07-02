using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : Singleton<MainMenuController> {


    [SerializeField]
    private Button musicButton;

    [SerializeField]
    private Sprite[] musicIcons;


    // Use this for initialization
    void Start () {
        //Using Instance, activate the singleton pattern.
        // Instance.StartGame();
        CheckToPlayMusic();
	}
	
    void CheckToPlayMusic()
    {
        if(GamePeferences.GetMusic() == 1)
        {
            MusicManager.Instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }else
        {
            MusicManager.Instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }
	
    public void StartGame()
    {
        GameManager.Instance.NewGameFomMainMenu = true;
        //SceneManager.LoadScene("Game");
        SceneFaderScript.Instance.LoadLevel("Game");
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
        if(GamePeferences.GetMusic() == 0)
        {
            GamePeferences.SetMusic(1);
            MusicManager.Instance.PlayMusic(true);
            musicButton.image.sprite = musicIcons[1];
        }else
        {
            GamePeferences.SetMusic(0);
            MusicManager.Instance.PlayMusic(false);
            musicButton.image.sprite = musicIcons[0];
        }
    }
}
