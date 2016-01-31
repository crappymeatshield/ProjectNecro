using UnityEngine;
using System.Collections;

public class Corpse : MonoBehaviour {

    public GameObject corpse;
    public string lifeTag;

	// Use this for initialization
	void Start () {
        corpse = GameObject.FindGameObjectWithTag("Corpse");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}
}
