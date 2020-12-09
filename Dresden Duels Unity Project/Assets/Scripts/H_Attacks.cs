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
    public Animator anim;

    public SFX sfx;

    public override void Start()
    {
        H_Animator = GetComponentInChildren<Animator>();
        fireballUseTimerMax = 0.5f;
        fireballUseTimer = 0;
        upLag = .5f;
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
        //H_Animator.Play("H_UpAttack");
        //anim.SetTrigger("Attack");
        GameObject tempHitbox = Instantiate(upHitbox, transform.position, transform.rotation);
        tempHitbox.transform.parent = GetComponentInParent<Player>().transform;
        tempHitbox.GetComponent<HitBox>().creator = GetComponentInParent<Player>();
        Destroy(tempHitbox, upLag);
        sfx.play = true;

        hitBox.damage = 12;
    }
    public override void DownAttack()
    {
        UnityEngine.Debug.Log("Harry Down Attack");
        //anim.SetTrigger("Attack");
        sfx.play = true;
    }
    public override void LeftAttack()
    {
        UnityEngine.Debug.Log("Harry Left Attack");
        ShootFireball(0);
        //anim.SetTrigger("Attack");
        sfx.play = true;
        hitBox.damage = 8;
    }
    public override void RightAttack()
    {
        UnityEngine.Debug.Log("Harry Right Attack");
        ShootFireball(1);
        //anim.SetTrigger("Attack");
        sfx.play = true;
        hitBox.damage = 8;
    }
    public override void NeutralAttack()
    {
        UnityEngine.Debug.Log("Harry Neutral Attack");
        sr.sprite = neutralSprite;
        GameObject tempHitbox = Instantiate(neutralHitbox, transform.position, transform.rotation);
        tempHitbox.transform.parent = GetComponentInParent<Player>().transform;
        tempHitbox.GetComponent<HitBox>().creator = GetComponentInParent<Player>();
        Destroy(tempHitbox, neutralLag);
        hitBox.damage = 4;
    }

    public void ShootFireball(int dir)
    {
        GameObject tempFireBall = Instantiate(pfFireball, spellFirePoint.position, spellFirePoint.rotation);
        tempFireBall.GetComponent<FireballHitbox>().creator = GetComponentInParent<Player>();
        tempFireBall.GetComponent<Spells>().dir = dir;
        Destroy(tempFireBall, .5f);
        fireballUseTimer = fireballUseTimerMax;
    }
}
