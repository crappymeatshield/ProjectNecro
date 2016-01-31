using UnityEngine;
using System.Collections;
using System;

public class Stats : MonoBehaviour
{

    public int strength; //against defense
    public int defense; //against strength
    public int magic; //player has offensive and enemies have defensive
    public int health;
    public int maxHealth;
    public GameObject corpse;
    public GameObject corpseClone;

	public Stats()
	{
		strength = 1;
		defense = 1;
		magic = 1;
        maxHealth = 1;
        health = maxHealth;
		corpse = null;
	}

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Vector3 deadObj = this.gameObject.transform.position;
            String lifeTag = this.gameObject.tag;
            if (lifeTag == "Enemy" || lifeTag == "ShootingEnemy")
            {
                Stats c = this.gameObject.GetComponent<Stats>();
				corpseClone = (GameObject)Instantiate(corpse, deadObj, transform.rotation);
                corpseClone.gameObject.GetComponent<Corpse>().lifeTag = lifeTag;
                corpseClone.gameObject.GetComponent<Corpse>().maxHealth = c.maxHealth;
                corpseClone.gameObject.GetComponent<Corpse>().strength = c.strength;
                corpseClone.gameObject.GetComponent<Corpse>().defense = c.defense;
                corpseClone.gameObject.GetComponent<Corpse>().magic = c.magic;
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