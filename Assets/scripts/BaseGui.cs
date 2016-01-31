using UnityEngine;
using System;

public class BaseGui : MonoBehaviour {
    public Texture Background;
    public GUIStyle fontguistyle = new GUIStyle();
    private string menu = "BaseMain";
    // Use this for initialization
    void Start () {
	
	}

    void OnGUI()
    {
        fontguistyle.alignment = TextAnchor.MiddleCenter;
        fontguistyle.normal.textColor = Color.white;
        fontguistyle.hover.textColor = Color.yellow;
        SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 2.0f);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Background);
        switch (menu)
        {
            case "BaseMain":
                if (GUI.Button(new Rect(Screen.width * 0.11f, 0, Screen.width * 0.525f, Screen.height * 0.15f), "Inventory", fontguistyle))
                {
                    print("clicked inven");
                }
                if (GUI.Button(new Rect(Screen.width * 0.7f, Screen.height * 0.49f, Screen.width * 0.25f, Screen.height * 0.35f), "Ritual/Summoning", fontguistyle))
                {
                    print("clicked rit");
                }
                if (GUI.Button(new Rect(Screen.width * 0.05f, Screen.height * 0.4f, Screen.width * 0.125f, Screen.height * 0.3f), "Party", fontguistyle))
                {
                    print("clicked Party");
                }
                if (GUI.Button(new Rect(Screen.width * 0.4f, Screen.height * 0.9f, Screen.width * 0.1f, Screen.height * 0.1f), "World Map", fontguistyle))
                {
                    Application.LoadLevel(2);
                }
                break;
        }
    }
    public void SetFontsizeBasedonElementSize(float elementheight, ref GUIStyle fontforsizing, float scaleby)
    {
        int tempfontsize = fontforsizing.fontSize;
        //float screenwidth = Screen.width;
        //float ratio = (elementwidth*25.0f)/screenwidth;
        tempfontsize = Convert.ToInt32(elementheight / scaleby);
        fontforsizing.fontSize = tempfontsize;
    }
}
