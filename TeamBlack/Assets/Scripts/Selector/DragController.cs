using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragController : MonoBehaviour
{
    private Draggable _draggable;
    private Vector3 _offset;
    public Button castle;
    public Draggable[] buttons;
	// Use this for initialization
	void Start()
    {
        hideTrash();
        buttons = GetComponentsInChildren<Draggable>();
    }
    public void TrashUnit()
    {
        if(_draggable!=null)
        {
            Destroy(_draggable.gameObject);
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
        foreach (Draggable d in buttons)
        {
            //TODO MANA
        }
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
            if ((Controller.controller.getCurrentPhase() == Controller.Phases.Attack &&(castle.GetComponent<RectTransform>().rect.xMax +40 > Input.mousePosition.x)) ||
                ((Controller.controller.getCurrentPhase() == Controller.Phases.Defense && (castle.GetComponent<RectTransform>().rect.yMin-40 >Input.mousePosition.x))))
            {
                TrashUnit();
            }
            else
            {
                _draggable.DragEnd();
            }
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
