using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : Singleton<PlayerScore> {

    [SerializeField]
    private AudioClip coinSound, lifeSound;

    private CameraScript cameraScript;

    private Vector3 previousPosition;
    private bool coutScore;

    public int score;
    public int lifeScore;
    public int coinScore;

    private int coinValue = 200;
    private int lifeValue = 350;

    void Awake () {
        cameraScript = CameraScript.Instance;
	}
	

	void Start () {
        previousPosition = transform.position;
        coutScore = true;

    }

    void Update()
    {
        CountScore();
    }


    private void CountScore()
    {
        if (coutScore)
        {
            //Current Y position of the Player is "greater" (he's going down - ) then pervious ->> count score
            if(transform.position.y < previousPosition.y)
            {
                score++;
            }
            previousPosition = transform.position;
            GamePlayManager.Instance.SetScore(score);
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Coin")
        {
            coinScore++;
            score += coinValue;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            //disable coin
            target.gameObject.SetActive(false);

            //set score
            GamePlayManager.Instance.SetScore(score);
            GamePlayManager.Instance.SetCoinScore(coinScore);
        }

        if(target.tag == "Life")
        {
            lifeScore++;
            score += lifeValue;

            AudioSource.PlayClipAtPoint(lifeSound, transform.position);
            //disable life
            target.gameObject.SetActive(false);

            //set score
            GamePlayManager.Instance.SetScore(score);
            GamePlayManager.Instance.SetLifeScore(lifeScore);
        }

        if(target.tag == "Bounds")
        {
            //Stop camea
            cameraScript.moveCamera = false;
            coutScore = false;

            lifeScore--;

            //Check If game over
            GameManager.Instance.CheckGameStatus(score, coinScore, lifeScore);

            //Move player, to make it look like he died.
            transform.position = new Vector3(800, 800, 0);
            //Fix
            //Destroy(gameObject);
           
        }

        if (target.tag == "DeadlyCloud")
        {
            //Stop camea
            cameraScript.moveCamera = false;
            coutScore = false;

            
            lifeScore--;

            //Check If game over
            GameManager.Instance.CheckGameStatus(score, coinScore, lifeScore);

            //Move player, to make it look like he died.
            transform.position = new Vector3(800, 800, 0);
            //Fix
            //Destroy(gameObject);
        }
    }
}
