using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    public Stats stats;

	// Use this for initialization
	void Start () {
        stats.GetComponent<Stats>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
