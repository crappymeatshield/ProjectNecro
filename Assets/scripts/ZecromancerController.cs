using UnityEngine;
using System.Collections;

public class ZecromancerController : MonoBehaviour {
    public bool aggressive = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.Q))
        {
            aggressive = !aggressive;
        }
        if(Input.GetMouseButtonDown(0))
        {
            aggressive = false;
        }
	}
}
