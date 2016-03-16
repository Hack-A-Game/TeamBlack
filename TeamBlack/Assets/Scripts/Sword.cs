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
        Att = 10.0f;
        Def = 5.0f;
        Speed = 0.5f;
        AttSp = 1.0f;
        encounterList = new List<Unit>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (getHP() <= 0.0f)
        {
            Destroy(this);
        }
        if (encounterList != null)
        {
            countdown -= Time.deltaTime;
            if (encounterList[0].getHP() > 0 && countdown <= 0.0f)
            {
                getRigidBody().velocity = Vector2.zero;
                encounterList[0].getAttacked(Att);
                countdown = AttSp;
                if (encounterList[0].getHP() <= 0)
                {
                    encounterList.RemoveAt(0);
                }
            }
        }
        else
        {
            //Move
        }
    }
}
