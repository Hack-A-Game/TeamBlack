using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    public int mana;
    public float HP;
    public float Att;
    public float Def;
    public float AttSp;
    public Unit Attacking = null;
    public float countdown = 0.0f;
    //Constructor
    public Unit()
    {
        HP = 0;
        Att = 0;
        Def = 0;
        AttSp = 0.0f;
    }

    public void getAttacked(float damage)
    {
        HP -= damage / Def;
    }

    public double getHP()
    {
        return HP;
    }

    public double getAtt()
    {
        return Att;
    }

    public double getDef()
    {
        return Def;
    }

    public double getAttSp()
    {
        return AttSp;
    }

    public int getMana()
    {
        return mana;
    }
    public virtual void Start() { }
    public virtual void Update() { }

}
