﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class N_Attacks : AttackScript
{
    public Animator N_Animator;
    // Start is called before the first frame update
    public override void Start()
    {
        N_Animator = GetComponentInChildren<Animator>();   
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(GetComponentInChildren<BoxCollider2D>().transform.position, new Vector3(1, 1, 1));
    }
    // Update is called once per frame
    public override void Update()
    {

    }
    public override void UpAttack()
    {
        UnityEngine.Debug.Log("Nico Up Attack");
        N_Animator.Play("N_UpAttack");
    }
    public override void DownAttack()
    {
        UnityEngine.Debug.Log("Nico Down Attack");
        //N_Animator.Play("N_DownAttack");
    }
    public override void LeftAttack()
    {
        UnityEngine.Debug.Log("Nico Left Attack");
        N_Animator.Play("N_BackAttack");
    }
    public override void RightAttack()
    {
        UnityEngine.Debug.Log("Nico Right Attack");
        N_Animator.Play("N_ForwardAttack");
    }

    public override void NeutralAttack()
    {
        UnityEngine.Debug.Log("Nico Neutral Attack");
        N_Animator.Play("N_NeutralAttack");
    }
}
