using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// PARENT CLASS - PLAYER
// need CHILD CLASSES for Dresden & Nicohemus
public class Player : MonoBehaviour
{

    // Fields
    public GameObject player;
    public OptionsMenu optionMenu;
    public int pNumber; // determine player 1 or 2
    private string pName;
    private int health = 50;
    private Vector2 position;
    private string animName;

    private void Start()
    {
        health = 50;
        animName = player.name.Substring(0, 1); //this makes it H_Hit or N_Hit
        //I will make that clearer/structure it better.
        animName += "_Hit";
    }

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = 50; }
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
    public void TakeDamage(int damageDealt)
    {
        health -= damageDealt;
        player.GetComponent<Animator>().Play(animName);
        UnityEngine.Debug.Log(name + " has " + health);
        if (health<=0)
        {
            optionMenu.ActivateEndMenu(player.name);
        }
    }

    //abstract void OnCollision();

    // NOTE: still working on the class, what we need and logic 

}
