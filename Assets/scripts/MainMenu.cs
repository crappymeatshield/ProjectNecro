using UnityEngine;
using UnityEditor.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : Keybinds
{
    public GUIStyle fontguistyle = new GUIStyle();
    public string menu = "Main";
    private bool editcontrols = false;
    private int keybindrow = 0;
    private int keybindcol = 0;
    private string[] codename = new string[9];
    // Use this for initialization
    void Start () {
        codename[0] = "Up:";
        codename[1] = "Down:";
        codename[2] = "Right:";
        codename[3] = "Left:";
        codename[4] = "Aggressive:";
        codename[5] = "Zombie Return:";
        codename[6] = "Zombie Attack:";
        codename[7] = "Necro Attack:";
        codename[8] = "Pause:";
        KeyCode[] KC = new KeyCode[2];
        ControllerConfig = new KeyCode[9][];
        KC[0]=KeyCode.W;
        KC[1]=KeyCode.UpArrow;
        ControllerConfig[0]=KC;
        KeyCode[] KC1 = new KeyCode[2];
        KC1[0]=KeyCode.S;
        KC1[1]=KeyCode.DownArrow;
        ControllerConfig[1]=KC1;
        KeyCode[] KC2 = new KeyCode[2];
        KC2[0]=KeyCode.D;
        KC2[1]=KeyCode.RightArrow;
        ControllerConfig[2]=KC2;
        KeyCode[] KC3 = new KeyCode[2];
        KC3[0]=KeyCode.A;
        KC3[1]=KeyCode.LeftArrow;
        ControllerConfig[3]=KC3;
        KeyCode[] KC4 = new KeyCode[2];
        KC4[0]=KeyCode.Q;
        KC4[1]=KeyCode.M;
        ControllerConfig[4]=KC4;
        KeyCode[] KC5 = new KeyCode[2];
        KC5[0]=KeyCode.E;
        KC5[1]=KeyCode.None;
        ControllerConfig[5]=KC5;
        KeyCode[] KC6 = new KeyCode[2];
        KC6[0]=KeyCode.Mouse0;
        KC6[1]=KeyCode.None;
        ControllerConfig[6]=KC6;
        KeyCode[] KC7 = new KeyCode[2];
        KC7[0]=KeyCode.F;
        KC7[1]=KeyCode.None;
        ControllerConfig[7]=KC7;
        KeyCode[] KC8 = new KeyCode[2];
        KC8[0]=KeyCode.Escape;
        KC8[1]=KeyCode.P;
        ControllerConfig[8]=KC8;
    }

    void OnGUI()
    {
        fontguistyle.alignment = TextAnchor.MiddleCenter;
        fontguistyle.normal.textColor = Color.white;
        fontguistyle.hover.textColor = Color.yellow;
        switch (menu)
        {
            case "Main":
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 1.0f);
                GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.05f, Screen.width * 0.6f, Screen.height * 0.1f), "This is our Title of our gayME", fontguistyle);
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 2.0f);
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.6f, Screen.height * 0.1f), "Plauge gayME", fontguistyle))
                {
                    Application.LoadLevel(1);
                    print("jk no gayME to plauge");
                }
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.35f, Screen.width * 0.6f, Screen.height * 0.1f), "Introdestructoinions", fontguistyle))
                {
                    menu = "Instructions";
                }
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.5f, Screen.width * 0.6f, Screen.height * 0.1f), "Bondageforpianoivory", fontguistyle))
                {
                    menu = "Keybinds";
                }
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.65f, Screen.width * 0.6f, Screen.height * 0.1f), "PeepswhodidmakedthisgayMEpourplauaging", fontguistyle))
                {
                    menu = "Credits";
                }
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.8f, Screen.width * 0.6f, Screen.height * 0.1f), "getoutofthegayMeyoucannotplauge", fontguistyle))
                {
                    print("noescape");
                    Application.Quit();
                }
                break;
            case "Instructions":
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 1.0f);
                GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.05f, Screen.width * 0.6f, Screen.height * 0.1f), "Operation Maunal for Proper Onion Destruction", fontguistyle);
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 2.0f);
                GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.6f, Screen.height * 0.45f), "Don't it is aa trap. Also it maybe be a dick.", fontguistyle);
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.7f, Screen.width * 0.6f, Screen.height * 0.1f), "Bondageforpianoivory", fontguistyle))
                {
                    menu = "Keybinds";
                }
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.85f, Screen.width * 0.6f, Screen.height * 0.1f), "Main Menu", fontguistyle))
                {
                    menu = "Main";
                }
                break;
            case "Keybinds":
                if (editcontrols)
                {
                    Event e = Event.current;
                    if (e.isKey)
                    {
                        int tempcount = 0;
                        foreach (KeyCode[] code in ControllerConfig)
                        {
                            if (code[0] == e.keyCode)
                            {
                                ControllerConfig[tempcount][0] = KeyCode.None;
                            }
                            else if (code[1] == e.keyCode)
                            {
                                ControllerConfig[tempcount][1] = KeyCode.None;
                            }
                            tempcount++;
                        }
                        KeyCode[] tempkeycode = new KeyCode[2];
                        tempkeycode = ControllerConfig[keybindrow];
                        tempkeycode[keybindcol] = e.keyCode;
                        ControllerConfig[keybindrow] = tempkeycode;
                        editcontrols = false;
                    }
                }
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 1.0f);
                GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.05f, Screen.width * 0.6f, Screen.height * 0.1f), "KeyBindings", fontguistyle);
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 2.0f);
                GUI.Label(new Rect(Screen.width * 0.3f, Screen.height * 0.15f, Screen.width * 0.25f, Screen.height * 0.1f), "Primary", fontguistyle);
                GUI.Label(new Rect(Screen.width * 0.6f, Screen.height * 0.15f, Screen.width * 0.25f, Screen.height * 0.1f), "Secondary", fontguistyle);
                for (int i = 0; i < 9; i++)
                {
                    GUI.Label(new Rect(Screen.width * 0.05f, Screen.height * (0.25f+(i*0.075f)), Screen.width * 0.25f, Screen.height * 0.075f), codename[i], fontguistyle);
                    if (GUI.Button(new Rect(Screen.width * 0.3f, Screen.height * (0.25f + (i * 0.075f)), Screen.width * 0.25f, Screen.height * 0.075f), ControllerConfig[i][0].ToString(), fontguistyle))
                    {
                        editcontrols = true;
                        keybindrow = i;
                        keybindcol = 0;
                    }
                    if (GUI.Button(new Rect(Screen.width * 0.6f, Screen.height * (0.25f + (i * 0.075f)), Screen.width * 0.25f, Screen.height * 0.075f), ControllerConfig[i][1].ToString(), fontguistyle))
                    {
                        editcontrols = true;
                        keybindrow = i;
                        keybindcol = 1;
                    }
                }
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.9f, Screen.width * 0.6f, Screen.height * 0.1f), "Main Menu", fontguistyle))
                {
                    menu = "Main";
                }
                break;
            case "Credits":
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 1.0f);
                GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.05f, Screen.width * 0.6f, Screen.height * 0.1f), "Credits", fontguistyle);
                SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 2.0f);
                GUI.Label(new Rect(Screen.width * 0.2f, Screen.height * 0.2f, Screen.width * 0.6f, Screen.height * 0.6f), "Bear Coded this game in his sleep.\nIt would be better if he would have coded it while awake.", fontguistyle);
                if (GUI.Button(new Rect(Screen.width * 0.2f, Screen.height * 0.85f, Screen.width * 0.6f, Screen.height * 0.1f), "Main Menu", fontguistyle))
                {
                    menu = "Main";
                }
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void SetFontsizeBasedonElementSize(float elementheight, ref GUIStyle fontforsizing, float scaleby)
    {
        int tempfontsize = fontforsizing.fontSize;
        //float screenwidth = Screen.width;
        //float ratio = (elementwidth*25.0f)/screenwidth;
        tempfontsize = Convert.ToInt32(elementheight/scaleby);
        fontforsizing.fontSize = tempfontsize;
    }
}
