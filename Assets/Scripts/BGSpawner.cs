using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : Singleton<BGSpawner> {

    private GameObject[] backgrounds;
    private float lastY;

    void Start()
    {
        GetBacgroundsAndSetY();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Background")
        {
            //If it's the last background
            if(target.transform.position.y == lastY)
            {
                Vector3 lastBg = target.transform.position;
                float height = (target as BoxCollider2D).size.y; //we are using the height of the BoxCollider (in our case it's 8)

                for (int i = 0; i < backgrounds.Length; i += 1)
                {
                    //If not active
                    if (!backgrounds[i].activeInHierarchy)
                    {
                        lastBg.y -= height;
                        lastY = lastBg.y;

                        backgrounds[i].transform.position = lastBg;
                        //Set BG active after we set the new position
                        backgrounds[i].SetActive(true);

                    }
                }
            } 
        }
    }

    void GetBacgroundsAndSetY()
    {
        //Set array with backgrounds
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
        lastY = backgrounds[0].transform.position.y;

        for(int i= 1; i < backgrounds.Length; i += 1)
        {
            if(lastY > backgrounds[i].transform.position.y) // > becouse we are goint down the axes -2 > -4 ;)
                lastY = backgrounds[i].transform.position.y;
            
        }
    }
}
