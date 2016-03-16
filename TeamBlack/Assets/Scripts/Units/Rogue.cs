using UnityEngine;
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
        MAXHP = HP;
        Def = 2.0f;
        Speed = 100f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (bar != null)
        {
            bar.updateHP(HP, MAXHP, transform.position);
        }

        if (getHP() <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
