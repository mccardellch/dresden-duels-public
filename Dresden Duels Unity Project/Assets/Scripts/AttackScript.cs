using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void UpAttack() {}
    public virtual void RightAttack() {}
    public virtual void DownAttack() { }

    public virtual void LeftAttack() { }

    public void NeutralAttack()
    {
        UnityEngine.Debug.Log("Neutral Attack");
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

}
