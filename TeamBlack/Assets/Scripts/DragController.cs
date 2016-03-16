using UnityEngine;
using System.Collections;

public class DragController : MonoBehaviour
{
    private GameObject _hitGameobject;

	// Use this for initialization
	void Start()
    {
	
	}
	
	// Update is called once per frame
	void Update()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition))
        }
	}
}
