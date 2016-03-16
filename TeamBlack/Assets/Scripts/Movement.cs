using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Unit))]
public class Movement : MonoBehaviour
{
    public enum MovementType
    {
        UNBOUNDED,
        RADIUS_BOUNDED
    }

    private Unit _unit;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private Vector2 _velocity = Vector2.zero;

    private gridPos _position;
    private Vector3 _initialPosition = Vector3.zero;

    public MovementType movementType;
    public float movementRadius;

    // Use this for initialization
    void Start()
    {
        _unit = GetComponent<Unit>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _position = new gridPos(0, 0);
    }

    public void SetInitialPositionNow()
    {
        _initialPosition = transform.position;
    }

    private void checkBounds(Vector2 bounds)
    {
        if (movementType == MovementType.RADIUS_BOUNDED)
        {
            Vector3 pos = Controller.map.GridToWorld(_position.x + 1, _position.y);
            // TODO: Check in radius
            //float distanceSqr = (transfor.position - tr.position).sqrMagnitude;
            //if (distanceSqr < rangeSqr)
        }
    }

    // Update is called once per frame
    void Update ()
    {
        // if (!unit.isAttacking())
        {
            _position = Controller.map.ToGridPos(transform.position);

            if (Controller.map.UnitCanMove(_position, Direction.right))
            {
                _velocity = Vector2.right;
            }
            else if (Controller.map.UnitCanMove(_position, Direction.down))
            {
                _velocity = Vector2.down;
            }
            
            if (_velocity != Vector2.zero)
            {
                // TODO: Get multiplier
                _rigidBody.velocity = _velocity /** _unit.getVelocity() */ * Time.deltaTime;
            }
        }
	}

    void LateUpdate()
    {

    }
}
