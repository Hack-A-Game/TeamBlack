using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Golem : Unit {

	// Use this for initialization
	public override void Start () {
        HP = 250.0f;
        Att = 25.0f;
        Def = 10.0f;
        AttSp = 2.0f;
        mana = 5;
        encounterList = new List<Unit>();

    }

    // Update is called once per frame
    public override void Update()
    {
        if (getHP() <= 0)
        {
            isAttacking = false;
            Destroy(this);
        }

        if (encounterList.Count < 0)
        {
            countdown -= Time.deltaTime;
            if (encounterList[0].getHP() > 0 && countdown <= 0.0f)
            {
                isAttacking = true;
                encounterList[0].getAttacked(Att);
                countdown = AttSp;
            } else if(encounterList[0].getHP() <= 0)
            {
                encounterList.RemoveAt(0);
                isAttacking = false;
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
