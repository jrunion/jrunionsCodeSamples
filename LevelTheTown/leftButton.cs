using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftButton : MonoBehaviour {
    private bool moveLeft;
    private bool moveRight;

    private float forwardSpeed = 100;

    private Rigidbody2D playerRigid;

    void Update()
    {
        playerRigid = GetComponent<Rigidbody2D>();
        if (moveLeft && !moveRight)
            playerRigid.AddForce(Vector2.right * -forwardSpeed);

        if (moveRight && !moveLeft)
            playerRigid.AddForce(Vector2.right * forwardSpeed);
    }

    public void MoveMeLeft()
    {
        moveLeft = true;
    }

    public void StopMeLeft()
    {
        moveLeft = false;
    }

    public void MoveMeRight()
    {
        moveRight = true;
    }

    public void StopMeRight()
    {
        moveRight = false;
    }
}
