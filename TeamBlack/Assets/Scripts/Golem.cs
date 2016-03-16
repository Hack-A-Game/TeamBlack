using UnityEngine;
using System.Collections;

public class Golem : Unit {

	// Use this for initialization
	public override void Start () {
        HP = 250.0f;
        Att = 25.0f;
        Def = 10.0f;
        AttSp = 2.0f;
        mana = 5;

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
