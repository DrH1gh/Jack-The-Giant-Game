using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : Singleton<CollectableScript>  {

    private void OnEnable()
    {
        //After 6 seconds call  DestryCollectable
        Invoke("DestryCollectable", 6f);
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
