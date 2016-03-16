using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
    public int mana;
    public float HP;
    public float Att;
    public float Def;
    public float AttSp;
    public float Speed;
    public float countdown = 0.0f;
    public bool isAttacking;
    public List<Unit> encounterList;
    //Constructor
    public Unit()
    {
        HP = 0;
        Att = 0;
        Def = 0;
        AttSp = 0.0f;
        Speed = 0.0f;
        encounterList = new List<Unit>();
        isAttacking = false;
    }

    public void getAttacked(float damage)
    {
        
        HP -= damage / Def;
        
    }

    public bool getIsAttacking()
    {
        return isAttacking;
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

    public float getSpeed()
    {
        return Speed;
    }
    public virtual void Start() { }
    public virtual void Update() { }

}
