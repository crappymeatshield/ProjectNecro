using UnityEngine;
using System.Collections;

public class Keybinds : MonoBehaviour {
    public KeyCode up1;
    public KeyCode up2;
    public KeyCode down1;
    public KeyCode down2;
    public KeyCode right1;
    public KeyCode right2;
    public KeyCode left1;
    public KeyCode left2;
    public KeyCode agressive1;
    public KeyCode agressive2;
    public KeyCode zombie_return1;
    public KeyCode zombie_return2;
    public KeyCode zombie_attack_move1;
    public KeyCode zombie_attack_move2;
    public KeyCode nec_attack1;
    public KeyCode nec_attack2;
    public KeyCode pause1;
    public KeyCode pause2;
	// Use this for initialization
	void Start () {
        up1=KeyCode.W;
        up2=KeyCode.UpArrow;
        down1=KeyCode.S;
        down2=KeyCode.DownArrow;
        right1=KeyCode.D;
        right2=KeyCode.RightArrow;
        left1=KeyCode.A;
        left2=KeyCode.LeftArrow;
        agressive1=KeyCode.Q;
        agressive2=KeyCode.M;
        zombie_return1=KeyCode.E;
        zombie_return2= KeyCode.Comma;
        zombie_attack_move1=KeyCode.Mouse0;
        zombie_attack_move2=KeyCode.Mouse1;
        nec_attack1=KeyCode.F;
        nec_attack2= KeyCode.K;
        pause1 = KeyCode.Escape;
        pause2 = KeyCode.P;
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
