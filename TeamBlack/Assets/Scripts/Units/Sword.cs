using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sword : AttackUnits
{

    // Use this for initialization
    public override void Start()
    {
        mana = 10;
        //Dir = inDir;
        HP = 200.0f;
        Att = 20.0f;
        Def = 5.0f;
        Speed = 75f;
        AttSp = 1.0f;
        encounterList = new List<Unit>();
        range = 1.5f;
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
