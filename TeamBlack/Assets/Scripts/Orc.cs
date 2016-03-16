using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orc : Unit
{

	// Use this for initialization
	public override void Start () {
        HP = 150.0f;
        Att = 20.0f;
        Def = 5.0f;
        AttSp = 1.2f;
        mana = 2;
        encounterList = new List<Unit>();
    }
	
	// Update is called once per frame
	public override void Update () {
        if (getHP() <= 0)
        {
            Destroy(this);
        }

        if (encounterList[0] != null)
        {
            countdown -= Time.deltaTime;
            if (encounterList[0].getHP() > 0 && countdown <= 0.0f)
            {
                encounterList[0].getAttacked(Att);
                countdown = AttSp;
            }
            else if (encounterList[0].getHP() <= 0)
            {
                encounterList.RemoveAt(0);
            }

        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "AttackUnit")
        {
            //Attacking = coll.gameObject.GetComponent<Unit>();
            encounterList.Add(coll.gameObject.GetComponent<Unit>());
        }
            

    }
}
