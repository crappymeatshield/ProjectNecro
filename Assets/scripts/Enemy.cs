using UnityEngine;
using System.Collections;

public class Enemy: MonoBehaviour
{
    public bool playerInSight;
    public GameObject player;
    public float sightLengthAway = 20.0f;
    private Stats health;
    public GameObject enemy;
    public GameObject shootingEnemy;
    public float timeOfLastAttack;
    public float secondsBetweenAttacks = 1.0f;
    public Rigidbody2D rb2d;
    public float lengthAway = 3.0f;
    public float shootingLengthAway = 10.0f;
    Vector2 follow;
    public float speed = 100.0f;
    public Stats stats;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Stats>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        shootingEnemy = GameObject.FindGameObjectWithTag("ShootingEnemy");
        stats = GetComponent<Stats>();
        SetStats();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(sightLengthAway > Vector2.Distance(player.transform.position, transform.position))
        {
            playerInSight = true;
        }
        else if (sightLengthAway < Vector2.Distance(player.transform.position, transform.position))
        {
            playerInSight = false;
        }
        if (playerInSight && !health.isDead)
        {
            if (rb2d.IsSleeping())
            {
                rb2d.WakeUp();
            }
            rb2d.velocity = Vector2.zero;
            if (this.tag == "ShootingEnemy")
            {
                if (shootingLengthAway < Vector2.Distance(player.transform.position, transform.position))
                {
                    Follow();
                }
                else
                {
                    Attack();
                }
            }
            else if (this.tag == "Enemy")
            {
                if (lengthAway < Vector2.Distance(player.transform.position, transform.position))
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
        if(stats.health<=0)
        {
            Destroy(this.gameObject);
        }
    }

    void Attack()
    {
        if (Time.time > timeOfLastAttack + secondsBetweenAttacks)
        {
            timeOfLastAttack = Time.time;
            health.TakeDamage(stats.strength);
        }
    }

    void Follow()
    {
        float x = player.transform.position.x - transform.position.x;
        float y = player.transform.position.y - transform.position.y;
        follow = new Vector2(x, y);
        follow.Normalize();
        rb2d.AddRelativeForce(follow * speed);
    }

    void SetStats()
    {
        if(this.tag == "Enemy")
        {
            stats.health = 60;
            stats.strength = 55;
            stats.defense = 40;
            stats.magic = 15;
        }
        else
        {
            stats.health = 40;
            stats.strength = 40;
            stats.defense = 25;
            stats.magic = 30;
        }
    }
}
