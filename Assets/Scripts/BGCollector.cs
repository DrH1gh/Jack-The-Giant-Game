using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : Singleton<BGCollector> {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Background")
        {
            target.gameObject.SetActive(false);
            //We don't use this like in the CloudCollector because we have the BG in the scene NOT Instantiate them !!
            //Destroy(target.gameObject);
        }
    }
}
