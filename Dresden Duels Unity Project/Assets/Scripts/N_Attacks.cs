using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class N_Attacks : AttackScript
{
    public Animator N_Animator;
    public SFX sfx;
    // Start is called before the first frame update
    public override void Start()
    {
        N_Animator = GetComponentInChildren<Animator>();   
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(GetComponentInChildren<BoxCollider2D>().transform.position, new Vector3(1, 1, 1));
    }
    public override void UpAttack()
    {
        UnityEngine.Debug.Log("Nico Up Attack");
        N_Animator.Play("N_UpAttack");
        GameObject tempHitbox = Instantiate(upHitbox);
        tempHitbox.transform.parent = transform;
        tempHitbox.GetComponent<HitBox>().creator = GetComponentInParent<Player>();
        Destroy(tempHitbox, upLag);
        sfx.play = true;
        //hitBox.damage = 8;
    }
    public override void DownAttack()
    {
        UnityEngine.Debug.Log("Nico Down Attack");
        N_Animator.Play("N_DownAttack");
    }
    public override void LeftAttack()
    {
        UnityEngine.Debug.Log("Nico Left Attack");
        N_Animator.Play("N_ForwardAttack");
        sfx.play = true;
        GameObject tempHitbox = Instantiate(leftHitbox);
        tempHitbox.transform.parent = transform;
        tempHitbox.GetComponent<HitBox>().creator = GetComponentInParent<Player>();
        Destroy(tempHitbox, leftLag);
        //hitBox.damage = 10;
    }
    public override void RightAttack()
    {
        UnityEngine.Debug.Log("Nico Right Attack");
        N_Animator.Play("N_BackAttack");
        sfx.play = true;
        GameObject tempHitbox = Instantiate(rightHitbox, transform.position, transform.rotation);
        tempHitbox.transform.parent = GetComponentInParent<Player>().transform;
        tempHitbox.GetComponent<HitBox>().creator = GetComponentInParent<Player>();
        Destroy(tempHitbox, rightLag);
        //hitBox.damage = 12;
    }

    public override void NeutralAttack()
    {
        UnityEngine.Debug.Log("Nico Neutral Attack");
        N_Animator.Play("N_NeutralAttack");
        //hitBox.damage = 4;
    }
}
