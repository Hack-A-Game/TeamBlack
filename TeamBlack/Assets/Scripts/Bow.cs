using UnityEngine;
using System.Collections;

public class Bow : AttackUnits
{
    
    // Use this for initialization
    public override void Start()
    {
        mana = 10;
        //Dir = inDir;
        HP = 150.0f;
        Att = 5.0f;
        Def = 3.0f;
        Speed = 0.3f;
        AttSp = 1.5f;
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
