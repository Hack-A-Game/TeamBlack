using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

//torns, pausa, 
public class Controller : MonoBehaviour {
    public Player _player1;
    public Player _player2;
    private bool _gamePause;
    public enum Turns { Attack, Defense };
    public enum Phases { Attack, Defense, InGame };
    enum MenuScreen { Menu, Game, Options};
    private Turns turnPlayer1;
    private Turns turnPlayer2;
    private float countdown = 30.0f;
    private bool endTime;
    private Phases currentPhase = Phases.Attack;

    public Button myButtonStart;
    public Button myButtonPlayer1;
    public Button myButtonPlayer2;
    public Button myButtonRandom;
    public static Controller controller;
    public static Map map;

    private GameObject leftPanel;
    private GameObject rightPanel;

    public BoxCollider2D Castle1;

    // Use this for initialization
    void Start () {
        _player1 = new Player();
        _player2 = new Player();
        _gamePause = false;
        endTime = false;

        if (myButtonPlayer1 != null)
        {
            myButtonStart.enabled = true;
            myButtonPlayer1.enabled = false;
            myButtonPlayer2.enabled = false;
            myButtonRandom.enabled = false;
            myButtonPlayer1.gameObject.SetActive(false);
            myButtonPlayer2.gameObject.SetActive(false);
            myButtonRandom.gameObject.SetActive(false);
            
        }

        //DontDestroyOnLoad(transform.gameObject);

        controller = this;

        map = GameObject.Find("Map").GetComponent<Map>();
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        leftPanel = GameObject.Find("LeftPanel");
        rightPanel = GameObject.Find("RightPanel");
        
        leftPanel.SetActive(true);
        rightPanel.SetActive(false);
    }

    /*
    public void OnLevelWasLoaded(int level)
    {
        if (Application.loadedLevelName == "GamePlay")
        {
            map = GameObject.Find("Map").GetComponent<Map>();

            leftPanel = GameObject.Find("LeftPanel");
            rightPanel = GameObject.Find("RightPanel");

            leftPanel.SetActive(true);
            rightPanel.SetActive(false);
        }
    }
    */

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0.0f)
            endTime = true;

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        // Check number of attacker units
        if (getCurrentPhase() == Phases.InGame)
        {
            int attackers = getPlayerAttack().countAttackUnits();
            if (attackers == 0)
            {
                changePhase();
                changeTurn();
                loadScene("GamePlay");
            }
        }
    }

    public void defineTurn(Turns p1, Turns p2){
        turnPlayer1 = Turns.Defense;
        turnPlayer2 = Turns.Attack;
    }

    public void changeTurn() {
        if (turnPlayer1 == Turns.Attack)
        {
            turnPlayer1 = Turns.Defense;
            turnPlayer2 = Turns.Attack;
        }
        else
        {
            turnPlayer1 = Turns.Attack;
            turnPlayer2 = Turns.Defense;
        }
    }

    public Player getPlayerAttack(){
        if (turnPlayer1 == Turns.Attack)
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
        if (turnPlayer1 == Turns.Defense)
        {
            return _player1;
        }
        else
        {
            return _player2;
        }
    }

    public Phases getCurrentPhase()
    {
        return currentPhase;
    }

    public void changePhase()
    {
        if (currentPhase == Phases.Attack)
        {
            currentPhase = Phases.Defense;

            leftPanel.SetActive(false);
            rightPanel.SetActive(true);
        }
        else if (currentPhase == Phases.Defense)
        {
            currentPhase = Phases.InGame;
            Castle1.enabled = true;
            leftPanel.SetActive(false);
            rightPanel.SetActive(false);
        }
        else
        {
            currentPhase = Phases.Attack;
        }
    }

    public void loadScene (string nameScene)
    {
        SceneManager.LoadScene(nameScene);
    }

    public void startGame()
    {
        defineTurn(Turns.Defense, Turns.Attack);
        currentPhase = Phases.Attack;
        loadScene("GamePlay");
    }

    public void playerStarts(string choice)
    {
        Debug.Log(choice);
        if (choice.Equals("p1"))
        {
            defineTurn(Turns.Defense, Turns.Attack);
        }
        else if (choice.Equals("p2"))
        {
            defineTurn(Turns.Attack, Turns.Defense);
        }
        else if (choice.Equals("p3"))
        {
            defineTurn(Turns.Defense, Turns.Attack);
        }

        currentPhase = Phases.Attack;
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