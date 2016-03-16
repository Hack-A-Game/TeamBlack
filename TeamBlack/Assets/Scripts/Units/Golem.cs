using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Golem : DefenseUnits {

	// Use this for initialization
	public override void Start () {
        base.Start();

        HP = 30.0f;
        Att = 10.0f;
        Def = 10.0f;
        AttSp = 0.5f;
        MAXHP = HP;
        mana = 5;
        range = 0.5f;
        Speed = 50f;
        encounterList = new List<Unit>();
    }
}