using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    //Llistas de unitats amb monoBehavior

    public int points;
    public int maxAttackUnit;
    public int maxDefendUnit;
    public int mana;
    private List<AttackUnits> listAttackUnits = new List<AttackUnits>();
    private List<DefenseUnits> listDefendUnits = new List<DefenseUnits>();

    // Use this for initialization
    void Start ()
    {
        points = 0;
        maxAttackUnit = 10;
        maxDefendUnit = 5;
        mana = 5000;
	}

    // Update is called once per frame
    void Update()
    {
    }

	public bool addAttackUnit(AttackUnits attackUnit)
    {

        //if (listAttackUnits.Count < maxAttackUnit)
        {
            listAttackUnits.Add(attackUnit);
            mana = mana - attackUnit.getMana();
            return true;
        }
        return false;
    }

    public int countAttackUnits()
    {
        return listAttackUnits.Count;
    }

    public bool addDefendUnitUnit(DefenseUnits defendUnit)
    {
        //if (listDefendUnits.Count < maxDefendUnit)
        {
            listDefendUnits.Add(defendUnit);
            mana = mana - defendUnit.getMana();
            return true;
        }
        return false;
    }

    public void removeAttackUnity(AttackUnits attackUnit)
    {
        if (listAttackUnits.Count > 0)
        {
            listAttackUnits.Remove(attackUnit);
        }
    }

    public void removeDefendUnity(DefenseUnits defendUnit)
    {
        if (listDefendUnits.Count > 0)
        {
            listDefendUnits.Remove(defendUnit);
        }
    }
}
