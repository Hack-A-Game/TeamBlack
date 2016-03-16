using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

    //GUIStyle style;

    void OnGUI()
    {
        //style.font = (Font)Resources.Load("Fonts/FontName");
        string text;
        text = "PLAYER 1: " + Controller.controller._player1.points + "\n MANA: " + Controller.controller._player1.mana;
        GUI.Label(new Rect(100, 0, 120, 100), text );

        text = "PLAYER 2: " + Controller.controller._player2.points + "\n MANA: " + Controller.controller._player2.mana;
        GUI.Label(new Rect(200, 0, 120, 100), text);
    }
}
