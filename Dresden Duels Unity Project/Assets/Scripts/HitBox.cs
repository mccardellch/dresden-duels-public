using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    //size
    public Vector2 position;
    public Vector2 boxSize;
    public float rotX;
    public float rotY;
    public LayerMask mask;

    //functionality
    private bool hasHit = false;

    //stats
    public Player creator;
    public float damage = 0;
    public float knockbackAmount = 0;


    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position + (transform.rotation * position), boxSize, transform.rotation * Quaternion.Euler(rotX, rotY, 0), mask);

        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                //try to find "Player" script
                Player player = colliders[i].GetComponentInParent<Player>();

                //if the player script is found
                if (player != null)
                {
                    //if we havent hit anything and it isnt the creator
                    if (hasHit == false && player != creator)
                    {
                        //deal damage
                        Debug.Log(creator.name + " hits " + player.name + " for " + damage + " damage");
                        player.Health -= Mathf.RoundToInt(damage);
                        //player.currentKnockback += transform.up * knockbackAmount;

                        //Change hasHit to true to make sure it does not hit the same target twice
                        hasHit = true;
                    }
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, .2f);
        Gizmos.matrix = Matrix4x4.TRS(transform.position + (transform.rotation * position), transform.rotation * Quaternion.Euler(rotX, rotY, 0), transform.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(boxSize.x * 2, boxSize.y * 2, 1));
    }
}
