using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    //GUIStyle style;

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 25;

        //style.font = (Font)Resources.Load("Fonts/FontName");
        string text;
        text = "PLAYER 1: " + Controller.controller._player1.points + "\n MANA: " + Controller.controller._player1.mana;
        GUI.Label(new Rect(100, 0, 120, 100), text, style);

        text = "PLAYER 2: " + Controller.controller._player2.points + "\n MANA: " + Controller.controller._player2.mana;
        GUI.Label(new Rect(300, 0, 120, 100), text, style);
    }
}
