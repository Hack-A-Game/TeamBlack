using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bow : AttackUnits
{
    
    // Use this for initialization
    public override void Start()
    {
        mana = 10;
        //Dir = inDir;
        HP = 150.0f;
        Att = 200.0f;
        Def = 3.0f;
        Speed = 0.3f;
        AttSp = 1.5f;
        encounterList = new List<Unit>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (getHP() <= 0.0f)
        {
            Destroy(this);
        }
        if (encounterList.Count > 0)
        {
            countdown -= Time.deltaTime;
            if (encounterList[0].getHP() > 0 && countdown <= 0.0f)
            {
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
