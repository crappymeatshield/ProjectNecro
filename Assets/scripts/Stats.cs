using UnityEngine;
using System.Collections;
using System;

public class Stats : MonoBehaviour
{

    public int strength; //against defense
    public int defense; //against strength
    public int magic; //player has offensive and enemies have defensive
    public bool isDead;
    public int health;

    // Use this for initialization
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            isDead = true;
            try
            {
                Destroy(this.gameObject);
            }
            catch (Exception)
            {}
        }
    }

    public void enemyTakeDamage(int strength, int magic)
    {
        health -= (strength + magic - defense - this.magic);
    }
    
    public void TakeDamage(int strength)
    {
        health -= (strength - defense);
    }
}