using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class AndroidCamera : MonoBehaviour
{
    private new Camera camera;
    private bool _shaking;
    private Vector3 _shakeDirection;
    private int _pendingUpdates;
    private float _updateRemaining;

    public int NumberOfUpdates = 6;
    public float UpdateDuration = 0.1f;

    // Use this for initialization
    void Start()
    {
        float targetaspect = 16.0f / 9.0f;
        float windowaspect = (float)Screen.width / (float)Screen.height;
        float scaleheight = windowaspect / targetaspect;

        camera = GetComponent<Camera>();

        // if scaled height is less than current height, add letterbox
        if (scaleheight < 1.0f)
        {
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleheight;
            rect.x = 0;
            rect.y = (1.0f - scaleheight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            float scalewidth = 1.0f / scaleheight;

            Rect rect = camera.rect;

            rect.width = scalewidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scalewidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }

        moveTo(GameObject.Find("devastated_castle"));
    }

    public void moveTo(GameObject obj)
    {
        camera.transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y, -10);
    }

    public void shake()
    {
        _shaking = true;
        _shakeDirection = Vector3.left;
        _pendingUpdates = NumberOfUpdates;
        _updateRemaining = UpdateDuration;
    }
	
	// Update is called once per frame
	void Update()
    {
	    if (_shaking)
        {
            _updateRemaining -= Time.deltaTime;
            if (_updateRemaining <= 0)
            {
                _shakeDirection = -_shakeDirection;
                _updateRemaining = UpdateDuration;
                --_pendingUpdates;

                _shaking = _pendingUpdates > 0;
            }

            transform.position = transform.position + _shakeDirection * Time.deltaTime;
        }
	}
}
