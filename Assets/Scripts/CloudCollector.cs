﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudCollector : Singleton<CloudCollector> {

    private void OnTriggerEnter2D(Collider2D target)
    {
        if( target.tag == "Cloud" || target.tag == "DeadlyCloud")
        {
            //This works, but its better to destroy the gameObject
            //target.gameObject.SetActive(false);
            Destroy(target.gameObject);
        }
    }
}
