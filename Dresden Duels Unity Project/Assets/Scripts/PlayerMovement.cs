using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float accel = .2f;
    public float deccel = .2f;
    public float grav = .3f;
    public float jumpSpeed = 4;
    public float maxHorizontalMoveSpeed = 15f;
    public float maxVerticalMoveSpeed = 8f;
    public float airControlAmount = .5f;

    //The effective acceleration/Decceleration, after being modified by air control amount
    float effAccel = 0;
    float effDeccel = 0;

    bool grounded = false;
    Vector3 vel = new Vector3(0, 0, 0);
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Player Controlled Movement
        ControlHorizontalMovement();     
        ApplyGravity();
        ControlVerticalMovement();

        controller.Move(vel * Time.deltaTime);
        //transform.position += vel * Time.deltaTime;
    }


    void ControlHorizontalMovement()
    {
        var horizontalMovementDir = Input.GetAxis("Horizontal");
        if(grounded)
        {
            effAccel = accel;
            effDeccel = deccel;
        }
        else
        {
            effAccel = accel * airControlAmount;
            effDeccel = deccel * airControlAmount;
        }

        //acceleration
        if (horizontalMovementDir > 0)
        {
            //moving right
            if (vel.x + effAccel < (maxHorizontalMoveSpeed * horizontalMovementDir))
            {
                vel.x += effAccel;
            }
            else
            {
                vel.x += (maxHorizontalMoveSpeed * horizontalMovementDir) - vel.x;
            }
        }
        else if (horizontalMovementDir < 0)
        {
            //moving left
            if (vel.x - effAccel > (maxHorizontalMoveSpeed * horizontalMovementDir))
            {
                vel.x -= effAccel;
            }
            else
            {
                vel.x += (maxHorizontalMoveSpeed * horizontalMovementDir) - vel.x;
            }
        }

        //decceleration
        if (vel.x > 0 && horizontalMovementDir >= 0 && vel.x > (maxHorizontalMoveSpeed * horizontalMovementDir))
        {
            //reduce right movement
            if ((vel.x - effDeccel) > (maxHorizontalMoveSpeed * horizontalMovementDir))
            {
                vel.x -= effDeccel;
            }
            else
            {
                vel.x = (maxHorizontalMoveSpeed * horizontalMovementDir);
            }
        }
        else if (vel.x < 0 && horizontalMovementDir <= 0 && vel.x < (maxHorizontalMoveSpeed * horizontalMovementDir))
        {
            //reduce left movement
            if ((vel.x + effDeccel) < (maxHorizontalMoveSpeed * horizontalMovementDir))
            {
                vel.x += effDeccel;
            }
            else
            {
                vel.x = (maxHorizontalMoveSpeed * horizontalMovementDir);
            }
        }
    }
    void ControlVerticalMovement()
    {
        if(Input.GetButtonDown("Jump") && grounded)
        {
            vel.y = +jumpSpeed;
        }
    }

    void ApplyGravity()
    {
        //change velocity with grav variable
        vel.y -= grav;

        

        if (controller.isGrounded)
        {
            grounded = true;
        }

        if (controller.isGrounded && vel.y < -.5f)
        {
            vel.y = -.5f;
            grounded = true;
        }

        if (vel.y > 0)
        {
            grounded = false;
        }
    }

    
    public void ApplyKnockback(Vector3 knockbackVec)
    {
        //Call to apply knockback to this player's velocity

    }
}
