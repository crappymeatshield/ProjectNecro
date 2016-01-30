using UnityEngine;
using System;
using System.Collections;

public class zombieAI : Keybinds
{
    public float speed = 100.0f;
    public GameObject master;
    public float stayaway = 2;
    public float estayaway = 2;
    public float attackrange = 15;
    public float secondsbetweenattacks = 1.0f;
    public int damage = 10;
    public bool gosomewhere = false;
    public GameObject attackthis;
    private Vector2 gohere;
    private float timeoflastattack = 0.0f;
    private Vector2 tomaster;
    private Vector2 toenemy;
    private Rigidbody2D rb2d;
    private ZecromancerController control;
    private bool attack = false;
    private GameObject[] enemies;
    private GameObject[] shootingenemies;
    private GameObject closestenemy;
    private GameObject maincam;
    private float CEdist = 0.0f;
	// Use this for initialization
	void Start () {
        master = GameObject.FindGameObjectWithTag("Player");
        control = master.GetComponent<ZecromancerController>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        shootingenemies = GameObject.FindGameObjectsWithTag("ShootingEnemy");
        closestenemy = null;
        CEdist = Mathf.Infinity;
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if(Input.GetKeyDown(ControllerConfig[5][0]) || Input.GetKeyDown(ControllerConfig[5][1]))
        {
            gosomewhere = false;
        }
        if (control.aggressive)
        {
            if (closestenemy == null)
            {
                enemies = GameObject.FindGameObjectsWithTag("Enemy");
                shootingenemies = GameObject.FindGameObjectsWithTag("ShootingEnemy");
                CEdist = Mathf.Infinity;
                for(int i =0; i<enemies.Length; i++)
                {
                    if (CEdist > Vector2.Distance(enemies[i].transform.position, transform.position))
                    {
                        closestenemy = enemies[i];
                        CEdist = Vector2.Distance(enemies[i].transform.position, transform.position);
                    }
                }
                for (int i = 0; i < shootingenemies.Length; i++)
                {
                    try {
                        if (CEdist > Vector2.Distance(shootingenemies[i].transform.position, transform.position))
                        {
                            closestenemy = enemies[i];
                            CEdist = Vector2.Distance(shootingenemies[i].transform.position, transform.position);
                        }
                    }
                    catch(IndexOutOfRangeException)
                    { }
                }
            }
            if (attackrange > CEdist)
            {
                attack = true;
            }
            else
            {
                attack = false;
            }
            if (attack)
            {
                rb2d.velocity = Vector2.zero;
                if (estayaway < Vector2.Distance(closestenemy.transform.position, transform.position))
                {
                    float mX = closestenemy.transform.position.x - transform.position.x;
                    float mY = closestenemy.transform.position.y - transform.position.y;
                    toenemy = new Vector2(mX, mY);
                    toenemy.Normalize();
                    rb2d.AddRelativeForce(toenemy * speed);
                }
                else
                {
                    if(Time.time> timeoflastattack + secondsbetweenattacks)
                    {
                        timeoflastattack = Time.time;
                        DoDamage(closestenemy);
                    }
                }
            }
            else
            {

                rb2d.velocity = Vector2.zero;
                if (stayaway < Vector2.Distance(master.transform.position, transform.position))
                {
                    movetoward(master.transform.position);
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(ControllerConfig[6][0]) || Input.GetKeyDown(ControllerConfig[6][1]))
            {                
                gosomewhere = true;
                float goX = Input.mousePosition.x;
                float goY = Input.mousePosition.y;
                Vector3 gohere3 = Camera.main.ScreenToWorldPoint(new Vector3(goX, goY, 0));
                gohere = new Vector2(gohere3.x, gohere3.y);
            }
            if (gosomewhere)
            {
                maincam = GameObject.FindGameObjectWithTag("MainCamera");
                clickonobject cobj= maincam.GetComponent<clickonobject>();
                if (cobj.clickedobj != null)
                    attackthis = cobj.clickedobj;
                else
                    attackthis = null;
                if (attackthis != null)
                {
                    rb2d.velocity = Vector2.zero;
                    if (estayaway < Vector2.Distance(attackthis.transform.position, transform.position))
                    {
                        float mX = attackthis.transform.position.x - transform.position.x;
                        float mY = attackthis.transform.position.y - transform.position.y;
                        toenemy = new Vector2(mX, mY);
                        toenemy.Normalize();
                        rb2d.AddRelativeForce(toenemy * speed);
                    }
                    else
                    {
                        if (Time.time > timeoflastattack + secondsbetweenattacks)
                        {
                            timeoflastattack = Time.time;
                            DoDamage(attackthis);
                        }
                    }
                }
                else
                {
                    rb2d.velocity = Vector2.zero;
                    if (stayaway < Vector2.Distance(gohere, transform.position))
                    {
                        movetoward(gohere);
                    }
                }
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                if (stayaway < Vector2.Distance(master.transform.position, transform.position))
                {
                    movetoward(master.transform.position);
                }
            }
        }
	}
    public void DoDamage(GameObject targettohit)
    {
        try
        {
            Enemy econtrol = targettohit.GetComponent<Enemy>();
            econtrol.stats.health -= 10;
        }
        catch(Exception)
        { }
    }

    private void movetoward(Vector3 toward)
    {
        float mX = toward.x - transform.position.x;
        float mY = toward.y - transform.position.y;
        tomaster = new Vector2(mX, mY);
        tomaster.Normalize();
        rb2d.AddRelativeForce(tomaster * speed);
    }
}
