using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PARENT CLASS - PLAYER
// need CHILD CLASSES for Dresden & Nicohemus
public class Player : MonoBehaviour
{
    // Fields
    public GameObject playerPrefab;
    public int pNumber; // determine player 1 or 2
    private string pName;
    private int health;
    private Vector2 position;

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    
    public Vector2 Position
    {
        get { return position; }
        set { position = value; }
    }

    // constructor
    public Player(int pNumber, string pName, int health, Vector2 position)
    {
        this.pNumber = pNumber;
        this.pName = pName;
        this.health = health;
        this.position = position;
    }

    //Methods 
    void TakeDamage(int pNumber, int damageDealt)
    {

        heatlh -= damageDealt;
    }

    abstract void OnCollision();

    // NOTE: still working on the class, what we need and logic 

}
