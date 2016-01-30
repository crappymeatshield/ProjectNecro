using UnityEngine;
using System.Collections;

public class clickonobject : Keybinds
{
    public GameObject clickedobj;
    	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(ControllerConfig[6][0]) || Input.GetKeyDown(ControllerConfig[6][1]))
        {
            Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
            if (hit)
            {
                if (hit.transform.tag == "Enemy" || hit.transform.tag == "ShootingEnemy")
                {
                    clickedobj = hit.transform.gameObject;
                }
            }
            else
            {
                clickedobj = null;
            }
        }
    }
}
