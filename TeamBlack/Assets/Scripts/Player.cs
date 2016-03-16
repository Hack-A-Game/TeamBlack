using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Llistas de unitats amb monoBehavior

    public double life;
    public int maxAttackUnit;
    public int maxDefendUnit;
    public int mana;
    public bool turnAttack; // True-> turn d'atac | False -> Turn de defensa
    private ArrayList listAttackUnits;
    private ArrayList listDefendUnits;

	// Use this for initialization
	void Start ()
    {
        life = 100;
        maxAttackUnit = 10;
        maxDefendUnit = 5;
        mana = 50;
        listAttackUnits = new ArrayList();
        listDefendUnits = new ArrayList();
        //turnAttack = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public bool addAttackUnit(MonoBehaviour attackUnit)
    {
        if (listAttackUnits.Count < maxAttackUnit && attackUnit.getMana() <= mana)
        {
            listAttackUnits.Add(attackUnit);
            mana = mana - attackUnit.getMana();
            return true;
        }
        return false;
    }

    public bool addDefendUnitUnit(MonoBehaviour defendUnit)
    {
        if (listDefendUnits.Count < maxDefendUnit && defendUnit.getMana() <= mana)
        {
            listDefendUnits.Add(defendUnit);
            mana = mana - defendUnit.getMana();
            return true;
        }
        return false;
    }

    public void removeAttackUnity(MonoBehaviour attackUnit)
    {
        if (listAttackUnits.Count > 0)
        {
            listAttackUnits.Remove(attackUnit);
        }
    }

    public void removeDefendUnity(MonoBehaviour defendUnit)
    {
        if (listDefendUnits.Count > 0)
        {
            listDefendUnits.Remove(defendUnit);
        }
    }

    public void getDamage(int damage)
    {
        life = life - damage;
    }
}
