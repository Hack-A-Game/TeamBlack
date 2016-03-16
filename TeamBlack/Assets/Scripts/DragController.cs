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
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null)
            {
                Debug.Log(hit);
                Draggable draggable = hit.collider.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _draggable = draggable;
                    Vector2 pos = new Vector2(draggable.transform.position.x, draggable.transform.position.y);
                    _offset = hit.point - pos;

                    _draggable.DragStart();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && _draggable != null)
        {
            _draggable.DragEnd();
            _draggable = null;
        }

        if (Input.GetMouseButton(0) && _draggable != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
            _draggable.transform.position = new Vector2(pos.x, pos.y);
        }
	}
}
