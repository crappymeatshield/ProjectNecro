using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float speed = 200.0f;
    public Rigidbody2D rb2d;
    Vector2 move;
    public float attackLengthAway = 3.0f;
    public GameObject enemy;
    public GameObject shootingEnemy;
    public Stats stats;
    public float timeOfLastAttack = 0;
    public float secondsBetweenAttacks = 1.0f;

	// Use this for initialization
	void Start () {
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
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        move = new Vector2(x, y);
        move.Normalize();
        rb2d.AddRelativeForce(move * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "ShootingEnemy")
        {
            if (Input.GetKeyDown(KeyCode.F))
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
            if (Input.GetKeyDown(KeyCode.F))
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
