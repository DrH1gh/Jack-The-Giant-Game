﻿using System.Collections;
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

	void Awake () {
        controlCloudPositionX = 0;

        //Set bordes of the screen, where you can spawn clouds.
        SetMinMax_CloudPosition();

        //Creat Clouds
        CreateClouds();

        //Set Player GameObject
        player = GameObject.Find("Player");

        /* NOT NEEDED when using prefabs
        for(int i =0; i< collectables.Length; i++)
        {
            collectables[i].SetActive(false);
        }
        */
    }

    void Start()
    {
        //Position Player on game start
        PositionThePlayer();
    }
    
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D target)
    {

        //Respawn new clouds (Instantiate)
        if (target.tag == "Cloud" || target.tag == "DeadlyCloud")
        {
            //lastCoudPositionY - is set on CreatCloud for loop
            if (target.transform.position.y == lastCoudPositionY)
            {
                ShuffleClouds(clouds);
                ShuffleClouds(collectables);

                Vector3 temp = target.transform.position;
                //same logic as in CreatCloud
                for(int i =0; i < clouds.Length; i++)
                {
                    //Only to those not active 
                    if (!clouds[i].activeInHierarchy)
                    {
                        if (controlCloudPositionX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxCloudPositionX);
                            controlCloudPositionX = 1;
                        }
                        else if (controlCloudPositionX == 1)
                        {
                            temp.x = Random.Range(0.0f, minCloudPositionX);
                            controlCloudPositionX = 2;
                        }
                        else if (controlCloudPositionX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxCloudPositionX);
                            controlCloudPositionX = 3;
                        }
                        else if (controlCloudPositionX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minCloudPositionX);
                            controlCloudPositionX = 0;
                        }

                        //set new postion
                        temp.y -= distanceBetweenClouds;
                        //Reasign last position
                        lastCoudPositionY = temp.y;

                        clouds[i].transform.position = temp;
                        

                        //Instantiate cloud from prefab and set parent
                        GameObject instanceOfCloud = Instantiate(clouds[i]);
                        instanceOfCloud.transform.parent = GameObject.Find("Clouds").transform;

                        clouds[i].SetActive(true);

                        //****************************
                        //COINS/LIFE
                        //****************************
                        int randomIndex = Random.Range(0, collectables.Length);

                        if(clouds[i].tag != "DeadlyCloud")
                        {

                            //A bit more randomly
                            int generateCoins = Random.Range(1, 9);
                            if (generateCoins == 3 || generateCoins == 6 || generateCoins == 9 || generateCoins == 7) return;

                            if (!collectables[randomIndex].activeInHierarchy)
                            {
                                Vector3 tempCloud = clouds[i].transform.position;
                                tempCloud.y += 0.7f; //set coins/life above cloud


                                //Instantiate Coins/Life fom prefabs and set parent
                                GameObject instanceCoinsLife = Instantiate(collectables[randomIndex]);
                                instanceCoinsLife.transform.parent = GameObject.Find("Collectables").transform;
                                collectables[randomIndex].SetActive(false); //disable them befour deciding what to do!

                                if (collectables[randomIndex].tag == "Life")
                                {
                                    //Set max PLAYER LIFE
                                    if(PlayerScore.Instance.lifeScore < 2)
                                    {
                                        collectables[randomIndex].transform.position = tempCloud;
                                        collectables[randomIndex].SetActive(true);
                                    }else
                                    {
                                        collectables[randomIndex].SetActive(false);
                                    }
                                }
                                else
                                {
                                    collectables[randomIndex].transform.position = tempCloud;
                                    collectables[randomIndex].SetActive(true);
                                }
                            }
                        }else
                        {
                            //Don't know why, but sometimes..coins get on DeadlyClouds
                            collectables[randomIndex].SetActive(false);
                        }

                    }


                    
                }

                


            }
        }
    }

    private void SetMinMax_CloudPosition()
    {
        Vector3 cameraBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        maxCloudPositionX = cameraBounds.x - 0.5f; //-.5 = half of the cloud
        minCloudPositionX = -cameraBounds.x + 0.5f;
    }

    private void ShuffleClouds(GameObject[] arrayToShuffle)
    {
        for(int i =0; i< arrayToShuffle.Length; i += 1)
        {
            GameObject temp = arrayToShuffle[i];
            int random = Random.Range(i, arrayToShuffle.Length);

            arrayToShuffle[i] = arrayToShuffle[random];
            arrayToShuffle[random] = temp;
        }
    }

    private void CreateClouds()
    {
        //Shuffle Clouds order in array
        ShuffleClouds(clouds);

        float positionCloudY = 0f;

        for(int i = 0; i < clouds.Length; i += 1)
        {
            
            Vector3 temp = clouds[i].transform.position;
            temp.y = positionCloudY;
           
            //Control Cloud Position
            //This will set clounds more predictable 
            //If you comment this, clouds will be random (example: left right - left left - right center)
            if(controlCloudPositionX == 0)
            {
                temp.x = Random.Range(0.0f, maxCloudPositionX);
                controlCloudPositionX = 1;
            }else if(controlCloudPositionX == 1)
            {
                temp.x = Random.Range(0.0f, minCloudPositionX);
                controlCloudPositionX = 2;
            }
            else if (controlCloudPositionX == 2)
            {
                temp.x = Random.Range(1.0f, maxCloudPositionX);
                controlCloudPositionX = 3;
            }
            else if (controlCloudPositionX == 3)
            {
                temp.x = Random.Range(-1.0f, minCloudPositionX);
                controlCloudPositionX = 0;
            }

            lastCoudPositionY = positionCloudY;

            clouds[i].transform.position = temp;
            positionCloudY -= distanceBetweenClouds;
            
            //Instantiate cloud from prefab and set parent
            GameObject instanceOfCloud = Instantiate(clouds[i]);
            instanceOfCloud.transform.parent = GameObject.Find("Clouds").transform;
        }
    }

    private void PositionThePlayer()
    {
        GameObject[] darkClouds = GameObject.FindGameObjectsWithTag("DeadlyCloud");
        GameObject[] cloudsInGame = GameObject.FindGameObjectsWithTag("Cloud");
        //DarkCloud Fix!
        for(int i= 0; i <darkClouds.Length; i++)
        {
            //If darkCloud is the first one, change position!
            if(darkClouds[i].transform.position.y == 0f)
            {
                Vector3 oldDarkPosition = darkClouds[i].transform.position;
                darkClouds[i].transform.position = new Vector3(cloudsInGame[0].transform.position.x, cloudsInGame[0].transform.position.y, cloudsInGame[0].transform.position.z);
                cloudsInGame[0].transform.position = oldDarkPosition;
            }
        }

        //PlayerPosition
        Vector3 firstCloud = cloudsInGame[0].transform.position;

        for(int i = 1; i < cloudsInGame.Length; i++)
        {
            if(firstCloud.y < cloudsInGame[i].transform.position.y)
            {
                firstCloud = cloudsInGame[i].transform.position;
            }
        }
        firstCloud.y += 1f;
        player.transform.position = firstCloud;
    }

   
}
