using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    protected float endLag=0;
    protected float time;
    public bool canAttack;
    public int upLag = 25, downLag = 0, forwardLag = 15, backLag = 30, neutralLag = 15;

    public void tryAttack(int attack)
    {
        if (endLag<=0)
        {
            if (attack == 0) UpAttack();
            else if (attack == 1) RightAttack();
            else if (attack == 2) DownAttack();
            else if (attack == 3) LeftAttack();
        }
    }
    public virtual void UpAttack() { endLag = upLag; }
    public virtual void RightAttack() { endLag = forwardLag; }
    public virtual void DownAttack() { endLag = downLag; }

    public virtual void LeftAttack() { endLag = backLag; }

    public virtual void NeutralAttack() { }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        time = Time.deltaTime;
        if (endLag > 0)
        {
            endLag -= time;
        }
    }

}
