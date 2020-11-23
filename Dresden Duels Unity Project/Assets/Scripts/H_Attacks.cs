using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Attacks : AttackScript
{

    public GameObject pfFireball;
    public Transform spellFirePoint;
    public Animator H_Animator;
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
    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(GetComponentInChildren<BoxCollider2D>().transform.position, new Vector3(1, 1, 1));
    }
    public override void UpAttack()
    {
        UnityEngine.Debug.Log("Harry Up Attack");
        H_Animator.Play("H_UpAttack");
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
    public override void NeutralAttack()
    {
        UnityEngine.Debug.Log("Harry Neutral Attack");
        H_Animator.Play("H_NeutralAttack");
    }

    public void TryToShootFireball()
    {
        //If a fireball has not been fired for a short time (equal to fireballUseTimerMax)
        if (fireballUseTimer <= 0)
        {
            GameObject tempFireBall = Instantiate(pfFireball, spellFirePoint.position, spellFirePoint.rotation);
            tempFireBall.GetComponent<HitBox>().creator = GetComponentInParent<Player>();
            Destroy(tempFireBall, .5f);
            fireballUseTimer = fireballUseTimerMax;
        }
    }
}
