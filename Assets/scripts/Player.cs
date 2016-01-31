using UnityEngine;
using System.Collections;

public class Player : Keybinds
{
    
    public float speed = 200.0f;
    public Rigidbody2D rb2d;
    Vector2 move;
    public float attackLengthAway = 3.0f;
    public GameObject enemy;
    public GameObject shootingEnemy;
    public GameObject castbar;
    public GameObject Icastbar;
    public Stats stats;
    public float timeOfLastAttack = 0;
    public float secondsBetweenAttacks = 1.0f;
    private bool teleporting = false;
    private float timestartteleport = 0.0f;
    private float teleportcasttime = 4.0f;
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
        if(Input.GetKeyDown(KeyCode.T))
        {
            teleporting = true;
            timestartteleport = Time.time;
            Vector3 pos = new Vector3(transform.position.x, transform.position.y+0.75f, transform.position.z);
            Icastbar = (GameObject)Instantiate(castbar, pos, Quaternion.identity);
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
