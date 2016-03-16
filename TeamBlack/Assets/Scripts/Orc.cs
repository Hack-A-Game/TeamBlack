using UnityEngine;
using System.Collections;

public class Orc : Unit
{

	// Use this for initialization
	void Start () {
        HP = 150.0f;
        Att = 20.0f;
        Def = 5.0f;
        AttSp = 1.2f;
        mana = 2;
    }
	
	// Update is called once per frame
	public override void Update () {

        
        if (Attacking != null)
        {
            countdown -= Time.deltaTime;
            if (Attacking.getHP > 0 && countdown <= 0.0f)
            {
                Attacking.getAttacked(Att);
                countdown = AttSp;
            }
           
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "AttackUnit")
        {
            Attacking = coll.gameObject.GetComponent<Unit>();
        }
            

    }
}
