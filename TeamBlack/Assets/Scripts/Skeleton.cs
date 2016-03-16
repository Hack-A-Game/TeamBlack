using UnityEngine;
using System.Collections;

public class Skeleton : Unit
{

	// Use this for initialization
	public override void Start () {
        HP = 75.0f;
        Att = 10.0f;
        Def = 2.0f;
        AttSp = 1.0f;
        mana = 1;
    }

    // Update is called once per frame
    public override void Update()
    {


        if (Attacking != null)
        {
            countdown -= Time.deltaTime;
            if (Attacking.getHP() > 0 && countdown <= 0.0f)
            {
                Attacking.getAttacked(Att);
                countdown = AttSp;
            }

        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "AttackUnit")
        {
            Attacking = coll.gameObject.GetComponent<Unit>();
        }


    }
}
