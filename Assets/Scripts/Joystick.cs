using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private PlayerMoveJoystick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Player").GetComponent<PlayerMoveJoystick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if(gameObject.name == "Left")
        {
            playerMove.SetMovement(true);
        }else
        {
            playerMove.SetMovement(false);
        }
    }

    public void OnPointerUp (PointerEventData data)
    {
        playerMove.StopMovement();
        
    } 
}
