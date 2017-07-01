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
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Coin")
        {
            coinScore++;
            score += coinValue;
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            //disable coin
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Life")
        {
            lifeScore++;
            score += lifeValue;

            AudioSource.PlayClipAtPoint(lifeSound, transform.position);
            //disable life
            target.gameObject.SetActive(false);
        }

        if(target.tag == "Bounds")
        {
            cameraScript.moveCamera = false;
            coutScore = false;

            lifeScore--;
            //Move player, to make it look like he died.
            transform.position = new Vector3(800, 800, 0);
        }

        if (target.tag == "DeadlyCloud")
        {
            cameraScript.moveCamera = false;
            coutScore = false;

            lifeScore--;
            //Move player, to make it look like he died.
            transform.position = new Vector3(800, 800, 0);
        }
    }
}
