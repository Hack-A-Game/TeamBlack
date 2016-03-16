using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {
    public int mana = 0;
    public float HP = 0.0f;
    public float Att = 0.0f;
    public float Def = 0.0f;
    public float AttSp = 0.0f;
    public float Speed = 2.0f;
    public bool isAttacking;
    public float countdown = 0.0f;
    public List<Unit> encounterList = new List<Unit>();
    protected Unit target;
    public float range;

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

    public void targetOutOfRange()
    {
        if (target != null)
        {
            encounterList.RemoveAt(0);
        }
        target = null;
    }

    public Unit getTarget()
    {
        return target;
    }

    public bool isInRange(float range)
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        return dist < range;
    }

}
