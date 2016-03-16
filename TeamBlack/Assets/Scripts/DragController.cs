using UnityEngine;
using System.Collections;

public class DragController : MonoBehaviour
{
    private Draggable _draggable;
    private Vector3 _offset;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Draggable draggable = hit.collider.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _draggable = draggable;
                    _offset = hit.point - draggable.transform.position;

                    _draggable.DragStart();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _draggable = null;
        }

        if (Input.GetMouseButton(0) && _draggable != null)
        {
            _draggable.transform.position = Input.mousePosition + _offset;
            _draggable.DragEnd();
        }
	}
}
