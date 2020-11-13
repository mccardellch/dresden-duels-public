using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    public GameObject pfFireball;
    public Transform spellFirePoint;

    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(pfFireball, spellFirePoint.position, spellFirePoint.rotation);
    }
}
