using UnityEngine;
using System.Collections;

public class Sword : AttackUnits
{

    // Use this for initialization
    public override void Start()
    {
        mana = 10;
        //Dir = inDir;
        HP = 200.0f;
        Att = 10.0f;
        Def = 5.0f;
        Speed = 0.5f;
        AttSp = 1.0f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Attacking != null)
        {
            countdown -= Time.deltaTime;
            if (Attacking.getHP() > 0 && countdown <= 0.0f)
            {
                getRigidBody().velocity = Vector2.zero;
                Attacking.getAttacked(Att);
                countdown = AttSp;
            }
        }
        else
        {
            //Move
        }
    }
}
