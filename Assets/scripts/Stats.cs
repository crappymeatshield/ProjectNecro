using UnityEngine;
using System.Collections;
using System;

public class Stats : MonoBehaviour
{

    public int strength; //against defense
    public int defense; //against strength
    public int magic; //player has offensive and enemies have defensive
    public int health;
//<<<<<<< HEAD
    public String lifeTag;//what tag an enemy was under when it died used for health/stats purposes wwhen reincarnating zombies
	public bool isDead;
    public GameObject corpse;
    public GameObject corpseClone;
   // public Stats stats;
//=======
    public int maxHealth;
   // public GameObject corpse;
   // public GameObject corpseClone;
//>>>>>>> origin/master

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
//<<<<<<< HEAD
//<<<<<<< HEAD
            isDead = true;
//=======
//>>>>>>> origin/master
            Vector3 deadObj = this.gameObject.transform.position;
            String lifeTag = this.gameObject.tag;
			/*
            if (lifeTag == "Enemy" || lifeTag == "ShootingEnemy")
            {
//<<<<<<< HEAD
				GameObject corpseClone = (GameObject)Instantiate(corpse, deadObj + new Vector3(0,0,0), transform.rotation);
			}*/
//=======
            //Vector2 deadObj = this.gameObject.transform.position;
            //lifeTag = this.gameObject.tag;
            if (lifeTag == "Enemy" || lifeTag == "ShootingEnemy")
            {
                //corpseClone = (GameObject)Instantiate(corpse, deadObj, transform.rotation);
//>>>>>>> origin/master
//=======
				//Corpse tempCorpse = corpse.GetComponent<Corpse>();
                Stats c = gameObject.GetComponent<Stats>();
				corpseClone = (GameObject)Instantiate(corpse, deadObj, transform.rotation);
				//*
                corpseClone.gameObject.GetComponent<Corpse>().lifeTag = c.lifeTag;
                corpseClone.gameObject.GetComponent<Corpse>().maxHealth = c.maxHealth;
                corpseClone.gameObject.GetComponent<Corpse>().strength = c.strength;
                corpseClone.gameObject.GetComponent<Corpse>().defense = c.defense;
                corpseClone.gameObject.GetComponent<Corpse>().magic = c.magic;
             //   */
				/*
				tempCorpse.lifeTag = c.lifeTag;
				tempCorpse.maxHealth = c.maxHealth;
				tempCorpse.strength = c.strength;
				tempCorpse.defense = c.defense;
				tempCorpse.magic = c.magic;
				corpse = (GameObject)Instantiate(corpse, deadObj, transform.rotation);
				*/

//>>>>>>> origin/master
            }
            try
            {
                Destroy(this.gameObject);
            }
            catch (Exception)
			{ print("Enemy not being destroyed");}
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