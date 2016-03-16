using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour
{
    private Vector3 _startPosition;

	// Use this for initialization
	void Start()
    {
	
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
            transform.position = _startPosition;
        }

        // FIXME: Towers are canBuild
        if (!Controller.map.hasFlag(pos, TileAtt.Passable))
        {
            // TODO: UI WARNING!
            transform.position = _startPosition;
        }
    }
}
