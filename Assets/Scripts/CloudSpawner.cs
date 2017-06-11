using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : Singleton<CloudSpawner> {

    [SerializeField]
    private GameObject[] clouds;

    private float distanceBetweenClouds = 3f;

    private float minCloudPositionX, maxCloudPositionX;

    private float lastCoudPositionY;

    [SerializeField]
    private GameObject[] collectables;

    private float controlCloudPositionX;

    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
