using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    //Llistas de unitats amb monoBehavior
    public float life;
    public ArrayList attackUnits;
    public ArrayList defendUnits;

	// Use this for initialization
	void Start () {
        life = 100;
        attackUnits = new ArrayList();
        defendUnits = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void addAttackUnit(MonoBehaviour attackUnit)
    {
        attackUnits.Add(attackUnit);
    }

    public void addDefendUnitUnit(MonoBehaviour defendUnit)
    {
        defendUnits.Add(defendUnit);
    }

    public void removeAttackUnity(MonoBehaviour attackUnit)
    {
        attackUnits.Remove(attackUnits);
    }

    public void removeDefendUnity(MonoBehaviour defendUnit)
    {
        defendUnits.Remove(defendUnits);
    }

    public void getDamage(int damage)
    {
        life = life - damage;
    }
}
