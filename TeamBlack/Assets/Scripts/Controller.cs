using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//torns, pausa, 
public class Controller : MonoBehaviour {
    private Player _player1;
    private Player _player2;
    private bool _startplayer1Attack;
    //private static Mapa _mapa;
    private bool _gamePause;
    enum TurnPlayer1 { Attack, Defense };
    enum TurnPlayer2 { Attack, Defense };
    enum MenuScreen { Menu, Game, Options};
    private TurnPlayer1 turnPlayer1;
    private TurnPlayer2 turnPlayer2;

    // Use this for initialization
    void Start () {
        _player1 = new Player();
        _player2 = new Player();
        _gamePause = false;
	}

    public void defineTurn(){
        turnPlayer1 = TurnPlayer1.Defense;
        turnPlayer2 = TurnPlayer2.Attack;
    }

    public void changeTurn() {
        if (turnPlayer1 == TurnPlayer1.Attack)
        {
            turnPlayer1 = TurnPlayer1.Defense;
            turnPlayer2 = TurnPlayer2.Attack;
        }
        else
        {
            turnPlayer1 = TurnPlayer1.Attack;
            turnPlayer2 = TurnPlayer2.Defense;
        }
    }

    public Player getTurnAttack(){
        if (turnPlayer1 == TurnPlayer1.Attack)
        {
            return _player1;
        }
        else
        {
            return _player2;
        }
    }

    public Player getTurnDefense()
    {
        if (turnPlayer1 == TurnPlayer1.Defense)
        {
            return _player1;
        }
        else
        {
            return _player2;
        }
    }

    public void loadScene (string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }
}
