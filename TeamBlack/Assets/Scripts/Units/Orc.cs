using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orc : DefenseUnits
{

	// Use this for initialization
	public override void Start () {
        base.Start();

        HP = 15.0f;
        Att = 15.0f;
        Def = 10.0f;
        MAXHP = HP;
        AttSp = 0.5f;
        mana = 5;
        range = 0.5f;
        Speed = 70f;
        encounterList = new List<Unit>();
    }
}
