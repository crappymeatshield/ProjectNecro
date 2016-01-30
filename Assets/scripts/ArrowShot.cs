using UnityEngine;
using System.Collections;

public class ArrowShot : MonoBehaviour {

    public GameObject enemy;
    public Stats stats;
    public Rigidbody2D arrowRB;
    public float speed = 50.0f;
    public Vector2 arrowPos;
    public GameObject player;
    public Vector2 startPos;

    // Use this for initialization
    void Start() {
        //enemy = GameObject.FindGameObjectWithTag("ShootingEnemy");
        ////player = GameObject.FindGameObjectWithTag("Player");
        //stats = enemy.GetComponent<Stats>();
        arrowRB = GetComponent<Rigidbody2D>();
        //float x = player.transform.position.x - transform.position.x;
        //float y = player.transform.position.y - transform.position.y;
        //arrowPos = new Vector2(x, y);
        //float degrees = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
        //startPos = transform.position;
        //transform.rotation = Quaternion.Euler(0, 0, degrees - 90);
        //arrowPos.Normalize();
    }

    // Update is called once per frame
    void FixedUpdate () {
        arrowRB.AddRelativeForce(Vector2.up * speed);
        if (15 <= Vector2.Distance(startPos, transform.position))
        {
            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Zombie")
        {
            other.gameObject.GetComponent<Stats>().TakeDamage(stats.strength);
            Destroy(this.gameObject);
        }
    }
}
