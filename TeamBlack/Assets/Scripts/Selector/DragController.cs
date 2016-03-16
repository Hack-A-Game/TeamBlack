using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour
{
    private Draggable _draggable;
    private Vector3 _offset;
    public SpriteRenderer castle;

	// Use this for initialization
	void Start()
    {
        hideTrash();

    }
    public void TrashUnit()
    {
        Debug.Log("TRASH");
        if(_draggable!=null)
        {
            Destroy(_draggable);
        }
    }
    private void ShowTrash()
    {
        castle.gameObject.SetActive(true);
    }
    private void hideTrash()
    {

        castle.gameObject.SetActive(false);
    }
    public void startDrag()
    {
        string unitName = EventSystem.current.currentSelectedGameObject.GetComponent<Draggable>().unitName;
        GameObject gob = AssetLoader.get().instantiate(unitName);
        Draggable dr = gob.GetComponent<Draggable>();
        _draggable = dr;
        _offset = Vector3.zero;
        ShowTrash();
    }
	// Update is called once per frame
	void Update()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if (hit.collider != null)
            {
                Draggable draggable = hit.collider.gameObject.GetComponent<Draggable>();
                if (draggable != null)
                {
                    _draggable = draggable;
                    Vector2 pos = new Vector2(draggable.transform.position.x, draggable.transform.position.y);
                    _offset = hit.point - pos;
                    _draggable.DragStart();
                    ShowTrash();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0) && _draggable != null)
        {
            _draggable.DragEnd();
            _draggable = null;
            hideTrash();
        }

        if (Input.GetMouseButton(0) && _draggable != null)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition) + _offset;
            _draggable.transform.position = new Vector2(pos.x, pos.y);
        }
	}
}
