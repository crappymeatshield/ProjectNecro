using UnityEngine;
using System;

public class WorldMapGui : MonoBehaviour {
    public Texture Background;
    public GUIStyle fontguistyle = new GUIStyle();
    void OnGUI()
    {
        fontguistyle.alignment = TextAnchor.MiddleCenter;
        fontguistyle.normal.textColor = Color.white;
        fontguistyle.hover.textColor = Color.yellow;
        fontguistyle.onHover.textColor = Color.yellow;
        SetFontsizeBasedonElementSize(Screen.height * 0.1f, ref fontguistyle, 2.0f);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), Background);
        if (GUI.Button(new Rect(Screen.width * 0.45f, Screen.height*0.05f, Screen.width * 0.525f, Screen.height * 0.425f), "Cave", fontguistyle))
        {
            Application.LoadLevel(4);
        }
        if (GUI.Button(new Rect(Screen.width * 0.265f, Screen.height * 0.21f, Screen.width * 0.11f, Screen.height * 0.15f), "Base", fontguistyle))
        {
            Application.LoadLevel(1);
        }
        if (GUI.Button(new Rect(Screen.width * 0.075f, Screen.height * 0.365f, Screen.width * 0.375f, Screen.height * 0.6f), "Farm", fontguistyle))
        {
            Application.LoadLevel(3);
        }
        if (GUI.Button(new Rect(Screen.width * 0.45f, Screen.height * 0.475f, Screen.width * 0.525f, Screen.height * 0.425f), "Forest", fontguistyle))
        {
            Application.LoadLevel(5);
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
