using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
    private Player _player1;
    private Player _player2;
    private bool _player1Start;
    //private static Mapa mapa;

	// Use this for initialization
	void Start () {
        _player1 = new Player();
        _player2 = new Player();
        randomStartPlayer();
	}
	
    public void randomStartPlayer(){
        Debug.Log(Random.Range(1,10));
        if (Random.Range(1, 10)%2==0) {
            _player1Start = true;
        }
        else {
            _player1Start = false;
        }

    }
    public void startPlayer1(){
        _player1Start = true;
    }

    public void startPlayer2(){
        _player1Start = false;
    }
    

}
