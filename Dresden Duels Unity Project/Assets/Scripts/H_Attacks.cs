using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_Attacks : MonoBehaviour
{

    public GameObject pfFireball;
    public Transform spellFirePoint;
    public float fireballUseTimerMax;
    float fireballUseTimer;

    void Update()
    {
        //If a fireball has not been fired for a short time (equal to fireballUseTimerMax)
        if (fireballUseTimer <= 0)
        {
            if (Input.GetKeyDown("t"))
            {
                Shoot();
                fireballUseTimer = fireballUseTimerMax;
            }
        }
        else fireballUseTimer -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject tempFireBall = Instantiate(pfFireball, spellFirePoint.position, spellFirePoint.rotation);
        Destroy(tempFireBall, .5f);
    }

}
