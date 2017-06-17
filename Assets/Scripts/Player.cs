using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
    [SerializeField]
    private float speed = 8f;
    [SerializeField]
    private float maxVelocity = 4f;

    private Rigidbody2D playerBody;
    private Animator anim;

    public float Speed { get { return speed; } }
    public float MaxVelocity { get { return maxVelocity; } }

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}

    /* FixedUpdate should be used instead of Update when dealing with Rigidbody. For example when adding a force to a rigidbody, you have to apply the force every fixed frame inside FixedUpdate instead of every frame inside Update. */
	void FixedUpdate() {
        PlayerMove();
    }

    private void PlayerMove()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x); // Abs - always positive number

        float h = Input.GetAxisRaw("Horizontal"); // -1 0 1 (A D or < >)
        if(h > 0)
        {
            Debug.Log("Going right");
            if (velocity < maxVelocity)
                forceX = speed;

            //Rotate player
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;

            anim.SetBool("isWalking", true);
        }
        else if (h < 0)
        {
            Debug.Log("Going left");
            if (velocity < maxVelocity)
                forceX = -speed;
            
            //Rotate player
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;

            anim.SetBool("isWalking", true);
        }
        else
            anim.SetBool("isWalking", false);


        playerBody.AddForce(new Vector2(forceX, 0));
    }
}
