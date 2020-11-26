using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spells : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int dir;

    // Start is called before the first frame update
    void Start()
    {
        //dir is set in H_Attacks, and is based on whether this is the left or right attack.
        if (dir==0)
        {
            rb.velocity = -transform.right * speed; //leftward velocity
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else rb.velocity = transform.right * speed; //rightward velocity

    }

}
