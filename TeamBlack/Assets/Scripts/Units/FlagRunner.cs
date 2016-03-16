using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewBehaviourScript : Unit {

	// Use this for initialization
	public override void Start () {
        base.Start();

        mana = 10;
        //Dir = inDir;
        HP = 15.0f;
        Att = 20.0f;
        MAXHP = HP;
        Def = 3.0f;
        Speed = 120f;
        AttSp = 0.05f;
        encounterList = new List<Unit>();
        range = 1.5f;
        canCapture = true;
    }
	
}
