using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Golem : DefenseUnits {

	// Use this for initialization
	public override void Start () {
        HP = 250.0f;
        Att = 250.0f;
        Def = 10.0f;
        AttSp = 2.0f;
        mana = 5;
        range = 4;
        encounterList = new List<Unit>();

    }

    // Update is called once per frame
    public override void Update()
    {
        if (getHP() <= 0.0f)
        {
            Destroy(gameObject);
        }
        if (encounterList.Count > 0)
        {
            isAttacking = true;
            countdown -= Time.deltaTime;

            if (target == null)
            {
                target = encounterList[0];
            }

            Debug.Log(target);
            Debug.Log(isInRange(range));
            if (isInRange(range) && target.getHP() > 0 && countdown <= 0.0f)
            {
                target.getAttacked(Att);
                countdown = AttSp;
                if (target.getHP() <= 0)
                {
                    encounterList.RemoveAt(0);
                    target = null;
                }
            }
        }
        else
        {
            isAttacking = false;
        }
    }
}