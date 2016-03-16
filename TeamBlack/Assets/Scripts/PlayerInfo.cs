using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {
    
    void OnGUI()
    {
        
        GUI.Label(new Rect(100, 0, 120, 100), "Player 1: " + Controller.controller._player1.points);
        GUI.Label(new Rect(200, 0, 120, 100), "Player 2: " + Controller.controller._player2.points);
    }
}
