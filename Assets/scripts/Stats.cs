using UnityEngine;
using System.Collections;
using System;

public class Stats : MonoBehaviour
{

    public int strength; //against defense
    public int defense; //against strength
    public int magic; //player has offensive and enemies have defensive
    public int health;
    public String lifeTag;//what tag an enemy was under when it died used for health/stats purposes wwhen reincarnating zombies
    public GameObject corpse;
    public GameObject corpseClone;
    public Stats stats;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (health <= 0)
        {
            Vector2 deadObj = this.gameObject.transform.position;
            lifeTag = this.gameObject.tag;
            if (lifeTag == "Enemy" || lifeTag == "ShootingEnemy")
            {
                corpseClone = (GameObject)Instantiate(corpse, deadObj, transform.rotation);
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