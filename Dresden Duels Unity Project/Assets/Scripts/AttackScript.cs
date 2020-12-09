using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    protected float endLag;
    protected float time;
    bool shouldChangeBackSprite;
    public HitBox hitBox;
    public GameObject upHitbox, leftHitbox, rightHitbox, neutralHitbox;
    public Sprite upSprite, leftSprite, rightSprite, neutralSprite, defaultSprite;
    public SpriteRenderer sr;
    //public bool canAttack; 
    public float upLag=0.3f, downLag=0.2f, rightLag=0.4f, leftLag=0.3f, neutralLag=0.2f;

    public void tryAttack(int attack)
    {
        //If the player is not in lag any more.
        if (endLag<=0)
        {
            shouldChangeBackSprite = true;
            if (attack == 0) {endLag = upLag; UpAttack(); }
            else if (attack == 1) { endLag = rightLag; RightAttack(); }
            else if (attack == 2) {endLag = downLag; DownAttack(); }
            else if (attack == 3) { endLag = leftLag; LeftAttack(); }
            else if (attack == 4) { endLag = neutralLag; NeutralAttack(); }
        }
    }
    public virtual void UpAttack() {  }
    public virtual void RightAttack() {}
    public virtual void DownAttack() {}

    public virtual void LeftAttack() {}

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
        else if (shouldChangeBackSprite)
        {
            sr.color = Color.black;
            sr.sprite = defaultSprite;
            shouldChangeBackSprite = false;
        }
    }

}
