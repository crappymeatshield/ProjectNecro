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

	// Use this for initialization
	void Start () {
		childCamera = GameObject.Find("Main Camera");
		childCamera.transform.parent = gameObject.transform;
		childCamera.transform.localPosition = new Vector3(0,0,-3);
		childCamera.GetComponent<Camera>().orthographicSize = 5f;
		spawnHorde();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        shootingEnemy = GameObject.FindGameObjectWithTag("ShootingEnemy");
        rb2d = GetComponent<Rigidbody2D>();
        stats = GetComponent<Stats>();
        stats.health = 100;
        stats.strength = 30;
        stats.defense = 35;
        stats.magic = 50;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        rb2d.velocity = Vector2.zero;
        //float x = Input.GetAxis("Horizontal");
        float y=0;
        if (Input.GetKey(ControllerConfig[0][0]) || Input.GetKey(ControllerConfig[0][1]))
            y = 1;
        else if (Input.GetKey(ControllerConfig[1][0]) || Input.GetKey(ControllerConfig[1][1]))
            y = -1;
        else
            y = 0;
        float x = 0; //Input.GetAxis("Vertical");
        if (Input.GetKey(ControllerConfig[2][0]) || Input.GetKey(ControllerConfig[2][1]))
            x = 1;
        else if (Input.GetKey(ControllerConfig[3][0]) || Input.GetKey(ControllerConfig[3][1]))
            x = -1;
        else
            x = 0;
        move = new Vector2(x, y);
        move.Normalize();
        rb2d.AddRelativeForce(move * speed);
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
