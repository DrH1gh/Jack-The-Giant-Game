using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreController : Singleton<HighScoreController> {

    // Use this for initialization
    void Start () {
		
	}
	
    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
