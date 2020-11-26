using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    protected float endLag;
    protected float time;
    //public bool canAttack; 
    public float upLag=1, downLag=1, rightLag=1, leftLag=1, neutralLag=1;

    public void tryAttack(int attack)
    {
        //If the player is not in lag any more.
        if (endLag<=0)
        {
            if (attack == 0) {endLag = upLag; UpAttack(); }
            else if (attack == 1) { endLag = rightLag; RightAttack(); }
            else if (attack == 2) {endLag = downLag; DownAttack(); }
            else if (attack == 3) { endLag = leftLag; LeftAttack(); }
            else if (attack == 4) { endLag = neutralLag; NeutralAttack(); }
        }
    }
    public virtual void UpAttack() { endLag = upLag; }
    public virtual void RightAttack() { endLag = rightLag; }
    public virtual void DownAttack() { endLag = downLag; }

    public virtual void LeftAttack() { endLag = leftLag; }

    public virtual void NeutralAttack() { endLag = neutralLag; }

    public virtual void Start()
    {

    }

    public void Update()
    {
        time = Time.deltaTime;
        //UnityEngine.Debug.Log(endLag);
        if (endLag > 0)
        {
            endLag -= time;
        }
    }

}
