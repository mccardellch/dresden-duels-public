using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class N_Attacks : AttackScript
{
    public Animator N_Animator;
    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        
    }
    public override void UpAttack()
    {
        UnityEngine.Debug.Log("Nico Up Attack");
    }
    public override void DownAttack()
    {
        UnityEngine.Debug.Log("Nico Down Attack");
    }
    public override void LeftAttack()
    {
        UnityEngine.Debug.Log("Nico Left Attack");
    }
    public override void RightAttack()
    {
        UnityEngine.Debug.Log("Nico Right Attack");
    }
}
