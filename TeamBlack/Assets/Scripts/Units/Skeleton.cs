using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Skeleton : DefenseUnits
{

	// Use this for initialization
	public override void Start ()
    {
        base.Start();

        HP = 25.0f;
        Att = 10.0f;
        Def = 2.0f;
        AttSp = 1.0f;
        mana = 1;
        range = 0.5f;
        Speed = 120f;
        encounterList = new List<Unit>();
    }
}

