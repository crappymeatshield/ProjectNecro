using UnityEngine;
using System.Collections;

public class ZecromancerController : Keybinds
{
    public bool aggressive = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(ControllerConfig[4][0]) || Input.GetKeyDown(ControllerConfig[4][1]))
        {
            aggressive = !aggressive;
        }
        if(Input.GetKeyDown(ControllerConfig[6][0]) || Input.GetKeyDown(ControllerConfig[6][1]))
        {
            aggressive = false;
        }
	}
}
