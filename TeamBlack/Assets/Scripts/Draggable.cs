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
        // if (!map.isValidPosition(_startPosition)
        {
            transform.position = _startPosition;
        }
    }
}
