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
        arrowRB = GetComponent<Rigidbody2D>();
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
