﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : Keybinds
{
    
    public float speed = 200.0f;
    public Rigidbody2D rb2d;
    Vector2 move;
    public float attackLengthAway = 3.0f;
    public GameObject enemy;
    public GameObject shootingEnemy;
//<<<<<<< HEAD
	public GameObject childCamera;
    public Stats stats;
    public float timeOfLastAttack = 0;
    public float secondsBetweenAttacks = 1.0f;
	public List<GameObject> zombieHorde;

	void spawnHorde()
	{
		for(int i = 0; i < zombieHorde.Count; i++)
		{
			Instantiate(zombieHorde[i],new Vector3(gameObject.transform.position.x + i, 
				gameObject.transform.position.y + i, gameObject.transform.position.z),Quaternion.identity);
		}
	}

//=======
    public GameObject castbar;
    public GameObject Icastbar;
    //public Stats stats;
   // public float timeOfLastAttack = 0;
    //public float secondsBetweenAttacks = 1.0f;
    private bool teleporting = false;
    private float timestartteleport = 0.0f;
    private float teleportcasttime = 4.0f;
//>>>>>>> origin/master
	// Use this for initialization
	void Start () {
		//makes camera follow you, resizes camera
		childCamera = GameObject.Find("Main Camera");
		childCamera.transform.parent = gameObject.transform;
		childCamera.transform.localPosition = new Vector3(0,0,-3);
		childCamera.GetComponent<Camera>().orthographicSize = 5f;
		//
		spawnHorde();//spawns followers
		gameObject.transform.position += new Vector3(0,0,-1);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        shootingEnemy = GameObject.FindGameObjectWithTag("ShootingEnemy");
        rb2d = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        stats.maxHealth = 100;
        stats.health = stats.maxHealth;
        stats.strength = 30;
        stats.defense = 35;
        stats.magic = 50;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(Input.GetKeyDown(KeyCode.T))
        {
//<<<<<<< HEAD
            teleporting = true;
            timestartteleport = Time.time;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.75f, transform.position.z);
            Icastbar = (GameObject)Instantiate(castbar, pos, Quaternion.identity);
//=======
            Application.LoadLevel(1);
//>>>>>>> origin/master
        }
        rb2d.velocity = Vector2.zero;
        //float x = Input.GetAxis("Horizontal");
        float y=0;
        if (Input.GetKey(ControllerConfig[0][0]) || Input.GetKey(ControllerConfig[0][1]))
        {
            y = 1;
            teleporting = false;
        }
        else if (Input.GetKey(ControllerConfig[1][0]) || Input.GetKey(ControllerConfig[1][1]))
        {
            y = -1;
            teleporting = false;
        }
        else
            y = 0;
        float x = 0; //Input.GetAxis("Vertical");
        if (Input.GetKey(ControllerConfig[2][0]) || Input.GetKey(ControllerConfig[2][1]))
        {
            x = 1;
            teleporting = false;
        }
        else if (Input.GetKey(ControllerConfig[3][0]) || Input.GetKey(ControllerConfig[3][1]))
        {
            x = -1;
            teleporting = false;
        }
        else
            x = 0;
        move = new Vector2(x, y);
        move.Normalize();
        rb2d.AddRelativeForce(move * speed);
        if (Icastbar != null && !teleporting)
            Destroy(Icastbar);
        if(teleporting)
        {
            float timeleft = (timestartteleport + teleportcasttime) - Time.time;
            float timepercent = timeleft * 25;
            float scaleofbarx = 5 * (timepercent * 0.01f);
            Vector3 scalebar = new Vector3(scaleofbarx, 1, 1);
            Icastbar.transform.localScale = scalebar;
            if (Time.time>=timestartteleport+teleportcasttime)
            {
                Application.LoadLevel(1);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "ShootingEnemy")
        {
            if (Input.GetKeyDown(ControllerConfig[7][0])|| Input.GetKeyDown(ControllerConfig[7][1]))
            {
                if (Time.time > timeOfLastAttack + secondsBetweenAttacks)
                {
                    timeOfLastAttack = Time.time;
                    other.gameObject.GetComponent<Stats>().enemyTakeDamage(stats.strength, stats.magic);
                    stats.health += 10;
                }
            }
        }
        else if(other.gameObject.tag == "Corpse")
        {
            Corpse c = other.gameObject.GetComponent<Corpse>();
            Corpse corpse = new Corpse(c.lifeTag, c.maxHealth, c.strength, c.defense, c.magic);
            corpseList.Add(corpse);
            Destroy(other.gameObject);
            foreach(Corpse item in corpseList)
            {
                Debug.Log(item.lifeTag + " " + item.maxHealth + " " + item.strength + " " + item.defense + " " + item.magic);
            }
        }
        else if(other.gameObject.tag == "Item")
        {
            Item i = other.gameObject.GetComponent<Item>();
            Item item = new Item(i.nam, i.desc, i.quantity, i.goldValue);
            itemList.Add(item);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "ShootingEnemy")
        {
            Stats enemyStats = other.gameObject.GetComponent<Stats>();
            if (Input.GetKeyDown(ControllerConfig[7][0]) || Input.GetKeyDown(ControllerConfig[7][1]))
            {
                if (Time.time > timeOfLastAttack + secondsBetweenAttacks)
                {
                    timeOfLastAttack = Time.time;
                    enemyStats.enemyTakeDamage(stats.strength, stats.magic);
                    stats.health += 10;
                }
            }
        }
    }
}
