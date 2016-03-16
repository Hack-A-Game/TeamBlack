using UnityEngine;
using System.Collections;

public class Bandera : MonoBehaviour {
    public float HP;
    private Player player;
    // Use this for initialization
    void Start () {
        HP = 100.0f;
        player = Controller.controller.getPlayerAttack();

    }
	
	// Update is called once per frame
	void Update () {
        if (HP <= 0)
        {
            player.points += 5;
        }
	
	}
    public void getAttacked(float damage)
    {

        HP -= damage;

    }

    public double getHP()
    {
        return HP;
    }
}
