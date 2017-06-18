using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : Singleton<CameraScript> {

    private float speed = 1f;
    private float acceleration = 0.2f;
    private float maxSpeed = 3.2f;

    [HideInInspector]
    public bool moveCamera;

	// Use this for initialization
	void Start () {
        moveCamera = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (moveCamera)
        {
            MoveCamera();
        }
	}

    private void MoveCamera()
    {
        Vector3 cameraOriginPosition = transform.position;
        float oldCamY = cameraOriginPosition.y;
        float newCamY = cameraOriginPosition.y - (speed * Time.deltaTime);
        
        //set camera postion Y between old cam y and nex cam y !
        cameraOriginPosition.y = Mathf.Clamp(cameraOriginPosition.y, oldCamY, newCamY);
        
        //Reasign camera position
        transform.position = cameraOriginPosition;
        
        //Incrase camera speed over time
        speed += acceleration * Time.deltaTime;
        
        //Fix camera speed (Controling camera speed)
        if (speed > maxSpeed) speed = maxSpeed;
    }
}
