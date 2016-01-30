using UnityEngine;
using System.Collections;

public class enemycontroller : MonoBehaviour {
    public int Health = 100;
	
	// Update is called once per frame
	void Update () {
	    if (Health<=0)
        {
            Destroy(this.gameObject);
        }
	}
    
}
