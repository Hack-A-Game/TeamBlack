using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    private Vector3 _startPosition;
    public string unitName;
    private bool isSet;
	// Use this for initialization
	void Start()
    {
        isSet = false;

    }
	
	// Update is called once per frame
	void Update()
    {
        
	}

    public void DragStart()
    {
        _startPosition = transform.position;
    }

    public void DragEnd()
    {
        gridPos pos = Controller.map.ToGridPos(transform.position);
        if (pos.outOfBounds())
        {
            // TODO: UI WARNING!
            if (!isSet)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = _startPosition;
            }
            return;
        }

        // FIXME: Towers are canBuild
        if (!Controller.map.hasFlag(pos, TileAtt.Passable))
        {
            // TODO: UI WARNING!
            if (!isSet)
            {
                Destroy(gameObject);
            }
            else
            {
                transform.position = _startPosition;
            }
            return;
        }

        GameObject unit = gameObject;
        bool result;
        if (!isSet && Controller.controller.getCurrentPhase() == Controller.Phases.Attack)
        {
            result = Controller.controller.getPlayerAttack().addAttackUnit(unit.GetComponent<AttackUnits>());
        }
        else if(!isSet)
        {
            result = Controller.controller.getPlayerAttack().addDefendUnitUnit(unit.GetComponent<DefenseUnits>());
        }
        isSet = true;
    }
}
