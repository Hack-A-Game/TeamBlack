using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Sword : AttackUnits
{

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        mana = 10;
        //Dir = inDir;
        HP = 20.0f;
        MAXHP = HP;
        Att = 20.0f;
        Def = 5.0f;
        Speed = 75f;
        AttSp = 1.0f;
        encounterList = new List<Unit>();
        range = 0.5f;
    }
}
