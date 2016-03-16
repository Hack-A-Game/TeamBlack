using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//torns, pausa, 
public class Controller : MonoBehaviour {
    private Player _player1;
    private Player _player2;
    private bool _gamePause;
    public enum TurnPlayer1 { Attack, Defense };
    public enum TurnPlayer2 { Attack, Defense };
    enum MenuScreen { Menu, Game, Options};
    private TurnPlayer1 turnPlayer1;
    private TurnPlayer2 turnPlayer2;
    private float countdown = 30.0f;
    private bool endTime;

    public UnityEngine.UI.Button myButtonStart;
    public UnityEngine.UI.Button myButtonPlayer1;
    public UnityEngine.UI.Button myButtonPlayer2;
    public UnityEngine.UI.Button myButtonRandom;
    public static Controller controller;
    public static Map map;

    // Use this for initialization
    void Start () {
        _player1 = new Player();
        _player2 = new Player();
        _gamePause = false;
        endTime = false;
        myButtonStart.enabled = true;
        myButtonPlayer1.enabled = false;
        myButtonPlayer2.enabled = false;
        myButtonRandom.enabled = false;
        myButtonPlayer1.gameObject.SetActive(false);
        myButtonPlayer2.gameObject.SetActive(false);
        myButtonRandom.gameObject.SetActive(false);
        DontDestroyOnLoad(transform.gameObject);

        controller = this;
        map = GameObject.Find("Map").GetComponent<Map>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
            endTime = true;


        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void defineTurn(TurnPlayer1 p1, TurnPlayer2 p2){
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

    public Player getPlayerAttack(){
        if (turnPlayer1 == TurnPlayer1.Attack)
        {
            return _player1;
        }
        else
        {
            return _player2;
        }
    }

    public Player getPlayerDefense()
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

    public void startGame()
    {
        myButtonStart.enabled = false;
        myButtonPlayer1.gameObject.SetActive(true);
        myButtonPlayer2.gameObject.SetActive(true);
        myButtonRandom.gameObject.SetActive(true);

        myButtonStart.gameObject.SetActive(false);
        myButtonPlayer1.enabled = true;
        myButtonPlayer2.enabled = true;
        myButtonRandom.enabled = true;
        Debug.Log("StartGame");
    }

    public void playerStarts(string choice)
    {
        Debug.Log(choice);
        if (choice.Equals("p1"))
        {
            defineTurn(TurnPlayer1.Defense, TurnPlayer2.Attack);
        }
        else if (choice.Equals("p2"))
        {
            defineTurn(TurnPlayer1.Attack, TurnPlayer2.Defense);
        }
        else if (choice.Equals("p3"))
        {
            defineTurn(TurnPlayer1.Defense, TurnPlayer2.Attack);
        }
        loadScene("GamePlay");
    }

    public void activeGamePaused()
    {
        _gamePause = !_gamePause;
    }

    public void desactiveGamePaused()
    {
        _gamePause = !_gamePause;
    }

}