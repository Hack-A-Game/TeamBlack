﻿using UnityEngine;
using System.Collections;

public class Rogue : AttackUnits
{

    // Use this for initialization
    public override void Start()
    {
        base.Start();

        mana = 10;
        //Dir = inDir;
        HP = 10.0f;
        Def = 2.0f;
        Speed = 50f;
    }

    // Update is called once per frame
    public override void Update()
    {
    }
}
