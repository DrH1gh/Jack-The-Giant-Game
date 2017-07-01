using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : Singleton<CollectableScript>  {

    private void OnEnable()
    {
        Invoke("DestryCollectable", 1f);
    }

    private void OnDisable()
    {

    }

    private void DestryCollectable()
    {
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

}
