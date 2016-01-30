using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    public Stats stats;

	// Use this for initialization
	void Start () {
        stats = gameObject.GetComponent<Stats>();
        stats.health = 80;
        stats.strength = 80;
        stats.defense = 20;
        stats.magic = 0;
	}
}
