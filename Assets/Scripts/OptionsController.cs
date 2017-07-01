using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsController : MonoBehaviour {

    [SerializeField]
    private GameObject easySign, mediumSign, hardSign;

	// Use this for initialization
	void Start () {
        SetDifficulty();

    }

    void SetInitialDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "easy":
                easySign.SetActive(true);
                mediumSign.SetActive(false);
                hardSign.SetActive(false);
                break;

            case "medium":
                easySign.SetActive(false);
                mediumSign.SetActive(true);
                hardSign.SetActive(false);
                break;

            case "hard":
                easySign.SetActive(false);
                mediumSign.SetActive(false);
                hardSign.SetActive(true);
                break;

        }
    }

    void SetDifficulty()
    {
        if(GamePeferences.GetEasyDifficulty() == 1)
        {
            SetInitialDifficulty("easy");
        }

        if (GamePeferences.GetMediumDifficulty() == 1)
        {
            SetInitialDifficulty("medium");
        }

        if (GamePeferences.GetHardDifficulty() == 1)
        {
            SetInitialDifficulty("hard");
        }
    }

    public void EasyDifficulty()
    {
        //Storing data in GamePeferences!!
        GamePeferences.SetEasyDifficulty(1);
        GamePeferences.SetMediuDifficulty(0);
        GamePeferences.SetHardDifficulty(0);

        easySign.SetActive(true);
        mediumSign.SetActive(false);
        hardSign.SetActive(false);
    }

    public void MediumDifficulty()
    {
        //Storing data in GamePeferences!!
        GamePeferences.SetEasyDifficulty(0);
        GamePeferences.SetMediuDifficulty(1);
        GamePeferences.SetHardDifficulty(0);

        easySign.SetActive(false);
        mediumSign.SetActive(true);
        hardSign.SetActive(false);
    }

    public void HardDifficulty()
    {
        //Storing data in GamePeferences!!
        GamePeferences.SetEasyDifficulty(0);
        GamePeferences.SetMediuDifficulty(0);
        GamePeferences.SetHardDifficulty(1);

        easySign.SetActive(false);
        mediumSign.SetActive(false);
        hardSign.SetActive(true);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}
