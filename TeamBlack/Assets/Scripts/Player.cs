using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    //Llistas de unitats amb monoBehavior

    public int points;
    public int maxAttackUnit;
    public int maxDefendUnit;
    public int mana;
    private List<AttackUnits> listAttackUnits;
    private List<DefenseUnits> listDefendUnits;
    private Castle castle;

	// Use this for initialization
	void Start ()
    {
        points = 0;
        maxAttackUnit = 10;
        maxDefendUnit = 5;
        mana = 50;
        castle = new Castle();
        listAttackUnits = new List<AttackUnits>();
        listDefendUnits = new List<DefenseUnits>();
	}

    // Update is called once per frame
    void Update()
    {
    }

	public bool addAttackUnit(AttackUnits attackUnit)
    {

        if (listAttackUnits.Count < maxAttackUnit && attackUnit.getMana() <= mana)
        {
            listAttackUnits.Add(attackUnit);
            mana = mana - attackUnit.getMana();
            return true;
        }
        return false;
    }

    public bool addDefendUnitUnit(DefenseUnits defendUnit)
    {
        if (listDefendUnits.Count < maxDefendUnit && defendUnit.getMana() <= mana)
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

    public void addPoint()
    {
        this.points++;
    }
}
