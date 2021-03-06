﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy: MonoBehaviour
{
    public bool playerInSight;
    public GameObject player;
    public float sightLengthAway = 3.0f;
    private Stats health;
    public GameObject enemy;
    public GameObject shootingEnemy;
    public float timeOfLastAttack;
    public float secondsBetweenAttacks = 1.0f;
    public float secondsBetweenArrows = 2.0f;
    public Rigidbody2D rb2d;
    public float lengthAway = 0.5f;
    public float shootingLengthAway = 2.0f;
    Vector2 follow;
    public float speed = 100.0f;
    public Stats stats;
    public Rigidbody2D arrow;
    public float arrowSpeed = 100.0f;
    public GameObject arrowObj;
    private GameObject[] zombies;
    private GameObject closestenemy;
    private float CEdist = 0.0f;
    public float timeOfLastClosestCheck = 0f;
    public float secondsBetweenClosestCheck = 5.0f;
	public List<randomModifiers> statModifiers = new List<randomModifiers>(4);//health, strength, defense, magic

	[System.Serializable]//makes it show up in editor
	public class randomModifiers
	{
		public int min, max;

		randomModifiers(int mini, int maxi)
		{
			min = mini;
			max = maxi;
		}

		randomModifiers()
		{
			min = 0;
			max = 1;
		}
	}

    // Use this for initialization
    void Start()
    {
		//print("enemy start = "+ gameObject.name);
        player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        shootingEnemy = GameObject.FindGameObjectWithTag("ShootingEnemy");
        stats = GetComponent<Stats>();
        SetStats();
		//print("Health = " + stats.health);
        rb2d = GetComponent<Rigidbody2D>();
        arrow = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (closestenemy == null || Time.time > timeOfLastClosestCheck + secondsBetweenClosestCheck)
        {
            timeOfLastClosestCheck = Time.time;
            zombies = GameObject.FindGameObjectsWithTag("Zombie");
            CEdist = Mathf.Infinity;
            closestenemy = null;
            for (int i = 0; i < zombies.Length; i++)
            {
                if (CEdist > Vector2.Distance(zombies[i].transform.position, transform.position))
                {
                    closestenemy = zombies[i];
                    CEdist = Vector2.Distance(zombies[i].transform.position, transform.position);
                }
//<<<<<<< HEAD
               // Debug.Log(closestenemy.ToString());
              //  Debug.Log(CEdist.ToString());
//=======
//>>>>>>> origin/master
            }
            if(CEdist > Vector2.Distance(player.transform.position, transform.position))
            {
                closestenemy = player;
                CEdist = Vector2.Distance(player.transform.position, transform.position);
            }
        }
        if (sightLengthAway > Vector2.Distance(closestenemy.transform.position, transform.position))
        {
            playerInSight = true;
        }
        else if (sightLengthAway < Vector2.Distance(closestenemy.transform.position, transform.position))
        {
            playerInSight = false;
        }
        if (playerInSight)
        {
            if (rb2d.IsSleeping())
            {
                rb2d.WakeUp();
            }
            rb2d.velocity = Vector2.zero;
            if (this.tag == "ShootingEnemy")
            {
                if (shootingLengthAway < Vector2.Distance(closestenemy.transform.position, transform.position))
                {
                    Follow();
                }
                else
                {
                    ShootingAttack();
                }
            }
            else if (this.tag == "Enemy")
            {
                if (lengthAway < Vector2.Distance(closestenemy.transform.position, transform.position))
                {
                    Follow();
                }
                else
                {
                    Attack();
                }
            }
        }
        else
        {
            rb2d.Sleep();
        }
    }

    void Attack()
    {
        if (Time.time > timeOfLastAttack + secondsBetweenAttacks)
        {
            timeOfLastAttack = Time.time;
            closestenemy.GetComponent<Stats>().TakeDamage(stats.strength);
        }
    }

    void ShootingAttack()
    {
        if (Time.time > timeOfLastAttack + secondsBetweenArrows)
        {
            timeOfLastAttack = Time.time;
            Vector2 pos = transform.position;
            pos.x++;
            GameObject arrowClone = (GameObject)Instantiate(arrowObj, pos, transform.rotation);
            ArrowShot shot = arrowClone.GetComponent<ArrowShot>();
            Rigidbody2D arrowRB = arrowClone.GetComponent<Rigidbody2D>();
            shot.stats = stats;
            float x = closestenemy.transform.position.x - transform.position.x;
            float y = closestenemy.transform.position.y - transform.position.y;
            shot.arrowPos = new Vector2(x, y);
            float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            shot.startPos = transform.position;
            transform.rotation = Quaternion.Euler(0, 0, degrees - 90);
            shot.arrowPos.Normalize();
            arrow.AddForce(transform.forward * arrowSpeed);

            arrowClone.GetComponent<ArrowShot>();
        }
    }

    void Follow()
    {
        float x = closestenemy.transform.position.x - transform.position.x;
        float y = closestenemy.transform.position.y - transform.position.y;
        follow = new Vector2(x, y);
        follow.Normalize();
        rb2d.AddForce(follow * speed);
    }

    void SetStats()
    {
		
        if(this.tag == "Enemy")
        {
//<<<<<<< HEAD
			stats.health = 60 + ((Random.Range(statModifiers[0].min,statModifiers[0].max)) * 5);
			stats.strength = 55+ Random.Range(statModifiers[1].min,statModifiers[1].max);
			stats.defense = 40+ Random.Range(statModifiers[2].min,statModifiers[2].max);
			stats.magic = 15+ Random.Range(statModifiers[3].min,statModifiers[3].max);
////=======
			stats.maxHealth = stats.health;
			/*
            stats.health = stats.maxHealth;
            stats.strength = 55;
            stats.defense = 40;
            stats.magic = 15;
            */
//>>>>>>> origin/master
        }
        else
        {
            stats.maxHealth = 40;
            stats.health = stats.maxHealth;
            stats.strength = 40;
            stats.defense = 25;
            stats.magic = 30;
        }
    }
}
