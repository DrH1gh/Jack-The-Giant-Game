using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLimits : MonoBehaviour {

    private float minX, maxX;


	// Use this for initialization
	void Start () {
        SetMinMax();
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.x < minX)
        {
            Vector3 playerPos = transform.position;
            playerPos.x = minX;
            transform.position = playerPos;
        }

        if(transform.position.x > maxX)
        {
            Vector3 playerPos = transform.position;
            playerPos.x = maxX;
            transform.position = playerPos;
        }
    }

    private void SetMinMax()
    {
        Vector3 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxX = cameraBounds.x - 0.4f; 
        minX = -cameraBounds.x + 0.4f;
    }

}
