using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFaderScript : Singleton<SceneFaderScript> {

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnime;

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        fadeAnime.Play("FadeIn");

        //yield return new WaitForSeconds(1f); //ATENTION! this not work because we have Time.timeScale = 0f; on gamestat ---- this affects animations.
        //Workaound, my own coroutine.
        yield return StartCoroutine(DRHCoroutine.WaitForRealSeconds(1f));

        SceneManager.LoadScene(level);
        fadeAnime.Play("FadeOut");

        //yield return new WaitForSeconds(0.5f);
        yield return StartCoroutine(DRHCoroutine.WaitForRealSeconds(0.5f));

        fadePanel.SetActive(false);
    }
}
