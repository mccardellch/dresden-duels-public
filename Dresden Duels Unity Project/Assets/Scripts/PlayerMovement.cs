using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    //Uses the axes set up in Input Manager (In Unity: Edit -> Project Settings -> Input Manager)
    public string axisNameExtension; //Input Manager input axis name extension. Values can be KB, KBLeft, KBRight, Controller1, or Controller2.
    //Different input key maps work by changing the input axis (or keys/joystick) that is being checked.
    protected string vAxis, hAxis, attackAxis;
    string[] axisNames;
    public TMP_Dropdown controlDropDown;
    float horizontalMovementDir;
    float verticalMovementDir;
    float attackAxisDir;
    AttackScript attackScript;

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

    //variables to determine if the jump key is pressed or held
    bool jumpKey = false;
    bool jumpKeyLast = false;

    bool grounded = false;
    Vector3 vel = new Vector3(0, 0, 0);
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        vAxis = "Vertical" + axisNameExtension;
        hAxis = "Horizontal" + axisNameExtension;
        attackAxis = "Attack" + axisNameExtension;
        //spriteRenderer = GetComponent<SpriteRenderer>();
        attackScript = GetComponent<AttackScript>();

        axisNames = new string[5];
        axisNames[0] = "KBLeft";
        axisNames[1] = "KBRight";
        axisNames[2] = "KB";
        axisNames[3] = "Controller1";
        axisNames[4] = "Controller2";
    }

    void FixedUpdate()
    {
        horizontalMovementDir = Input.GetAxis(hAxis);
        verticalMovementDir = Input.GetAxis(vAxis);
        attackAxisDir = Input.GetAxis(attackAxis);

        
        if (Input.GetAxis(vAxis) > 0)
        {
            jumpKey = true;
        }
        else
        {
            jumpKey = false;
        }

        //Player Controlled Movement
        ControlHorizontalMovement();     
        ApplyGravity();
        ControlVerticalMovement();

        //Check if any attacks should be launched
        TryToLaunchAttacks();

        controller.Move(vel * Time.fixedDeltaTime);

        jumpKeyLast = jumpKey;
    }



    void ControlHorizontalMovement()
    {
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
            spriteRenderer.flipX = true;
            //spriteRenderer.gameObject.GetComponent<Animation>().transform.localScale.Set(1, 1, 1);

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
            spriteRenderer.flipX = false;
            //spriteRenderer.gameObject.GetComponent<Animation>().transform.localScale.Set(-1, 1, 1);
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
        if(jumpKey && !jumpKeyLast && grounded)
        {
            vel.y = jumpSpeed;
 
        }
        if(!jumpKey && vel.y > 0)
        {
            vel.y *= .1f;
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

    public void TryToLaunchAttacks()
    {
        if (attackAxisDir != 0)
        {
            if (horizontalMovementDir < 0)
            {
                attackScript.tryAttack(3);
            }
            else if (horizontalMovementDir > 0)
            {
                attackScript.tryAttack(1);
            }
            else if (verticalMovementDir < 0)
            {
                attackScript.tryAttack(2);
            }
            else if (verticalMovementDir > 0)
            {
                attackScript.tryAttack(0);
            }
            else attackScript.tryAttack(4);
        }
    }

    public void ChangeAxisName(int value)
    {
        UnityEngine.Debug.Log(value);
        //0: WASD + Space. 1: Arrows + Right Ctrl. 2: Arrow Keys + ZX. 3: Controller 1. 4: Controller 2.
        axisNameExtension = axisNames[value];
        vAxis = "Vertical" + axisNameExtension;
        hAxis = "Horizontal" + axisNameExtension;
        attackAxis = "Attack" + axisNameExtension;
        //controlDropDown.ClearOptions();
    }
}
