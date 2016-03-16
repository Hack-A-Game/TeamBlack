using UnityEngine;
using System.Collections;

public class MonsterUnit : Unit {


    public MonsterUnit(int n)
    {
        if (n == 3) //skeleton
        {
            HP = 75;
            Att = 10;
            Def = 2;
            AttSp = 1;
        } else if (n==4) //orc
        {
            HP = 150;
            Att = 20;
            Def = 5;
            AttSp = 1.2;
        } else { //golem?
            HP = 250;
            Att = 25;
            Def = 10;
            AttSp = 2;
        }
    }
    /*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	*/
	}
}
