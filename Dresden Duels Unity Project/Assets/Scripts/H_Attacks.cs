using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Attacks : AttackScript
{

    public GameObject pfFireball;
    public Transform spellFirePoint;
    Animator H_Animator;
    public float fireballUseTimerMax;
    float fireballUseTimer;
    public override void Start()
    {
        H_Animator = GetComponentInChildren<Animator>();
        fireballUseTimerMax = 0.5f;
        fireballUseTimer = 0;
    }
    public override void Update()
    {
        if (fireballUseTimer > 0)
        {
            fireballUseTimer -= Time.deltaTime;
        }
    }

    public override void UpAttack()
    {
        UnityEngine.Debug.Log("Harry Up Attack");
    }
    public override void DownAttack()
    {
        UnityEngine.Debug.Log("Harry Down Attack");
    }
    public override void LeftAttack()
    {
        UnityEngine.Debug.Log("Harry Left Attack");
        TryToShootFireball();
    }
    public override void RightAttack()
    {
        UnityEngine.Debug.Log("Harry Right Attack");
        TryToShootFireball();
    }

    public void TryToShootFireball()
    {
        //If a fireball has not been fired for a short time (equal to fireballUseTimerMax)
        if (fireballUseTimer <= 0)
        {
            GameObject tempFireBall = Instantiate(pfFireball, spellFirePoint.position, spellFirePoint.rotation);
            Destroy(tempFireBall, .5f);
            fireballUseTimer = fireballUseTimerMax;
        }
    }
}
