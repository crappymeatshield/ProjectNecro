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
    public GameObject corpse;

    // Use this for initialization
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            isDead = true;
            Vector2 deadObj = this.gameObject.transform.position;
            String deadTag = this.gameObject.tag;
            if (deadTag == "Enemy" || deadTag == "ShootingEnemy")
            {
                GameObject corpseClone = (GameObject)Instantiate(corpse, deadObj, transform.rotation);
            }
            try
            {
                Destroy(this.gameObject);
            }
            catch (Exception)
            { }
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