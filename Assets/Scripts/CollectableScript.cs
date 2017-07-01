using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : Singleton<CollectableScript>  {

    private void OnEnable()
    {
        //After 7.5 seconds call  DestryCollectable
        Invoke("DestryCollectable", 7.5f);
    }

    private void OnDisable()
    {

    }

    private void DestryCollectable()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

}
