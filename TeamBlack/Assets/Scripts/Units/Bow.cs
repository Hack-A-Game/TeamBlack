using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bow : AttackUnits
{
    
    // Use this for initialization
    public override void Start()
    {
        base.Start();

        mana = 10;
        //Dir = inDir;
        HP = 10.0f;
        Att = 15.0f;
        MAXHP = HP;
        Def = 3.0f;
        Speed = 75f;
        AttSp = 0.05f;
        encounterList = new List<Unit>();
        range = 2.5f;
    }
}
