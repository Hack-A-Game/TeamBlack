using UnityEngine;
using System.Collections;

public class NextTurn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DefensePhase()
    {
        if (Controller.controller.getPlayerAttack().countAttackUnits() > 0)
        {
            Controller.controller.changePhase();
        }
    }

    public void GamePhase()
    {
        Controller.controller.changePhase();

    }
}
