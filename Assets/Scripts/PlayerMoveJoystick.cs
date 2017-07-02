using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour {

    private float speed = 8f;
    private float maxVelocity = 4f;

    private Rigidbody2D playerBody;
    private Animator anim;

    private bool moveLeft, moveRight;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (moveLeft)
        {
            MoveLeft();
        }
        if (moveRight)
        {
            MoveRight();
        }
    }

    public void SetMovement(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }
    public void StopMovement()
    {
        moveLeft = moveRight = false;
        anim.SetBool("isWalking", false);
    }

    void MoveLeft()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x); // Abs - always positive number

        if (velocity < maxVelocity)
            forceX = -speed;

        //Rotate player
        Vector3 temp = transform.localScale;
        temp.x = -1f;
        transform.localScale = temp;

        anim.SetBool("isWalking", true);

        playerBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x); // Abs - always positive number

        if (velocity < maxVelocity)
            forceX = speed;

        //Rotate player
        Vector3 temp = transform.localScale;
        temp.x = 1f;
        transform.localScale = temp;

        anim.SetBool("isWalking", true);

        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
