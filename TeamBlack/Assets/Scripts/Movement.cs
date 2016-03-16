using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private Vector2 _velocity = Vector2.zero;
    private float _multiplier = 1.0f;

    // Use this for initialization
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        // TODO: Get multiplier from unit descriptor
        // _multiplier = unit.velocity
    }

    // Update is called once per frame
    void Update ()
    {
        // TODO: Get velocity
        // _velocity = map.getDirection(transform.position)
        if (_velocity != Vector2.zero)
        {
            _rigidBody.velocity = _velocity * _multiplier * Time.deltaTime;
        }
	}
}
