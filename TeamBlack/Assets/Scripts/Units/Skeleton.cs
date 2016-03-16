using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skeleton : DefenseUnits
{

	// Use this for initialization
	public override void Start ()
    {
        base.Start();

        HP = 10.0f;
        Att = 20.0f;
        Def = 2.0f;
        AttSp = 0.5f;
        MAXHP = HP;
        mana = 1;
        range = 0.5f;
        Speed = 80f;
        encounterList = new List<Unit>();
    }
}

