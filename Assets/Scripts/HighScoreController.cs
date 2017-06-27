using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreController : Singleton<HighScoreController> {

    // Use this for initialization
    void Start () {
		
	}
	
    public void GoBack()
    {
        Application.LoadLevel(0);
    }
}
