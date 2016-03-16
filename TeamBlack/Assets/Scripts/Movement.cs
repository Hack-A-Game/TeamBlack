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

        SetInitialPositionNow();
    }

    public void SetInitialPositionNow()
    {
        _initialPosition = transform.position;
    }

    private bool checkBounds()
    {
        if (movementType == MovementType.RADIUS_BOUNDED)
        {
            Vector3 pos = Controller.map.GridToWorld(_position.x + 1, _position.y);
            float distance = (transform.position - pos).sqrMagnitude;
            return (distance < movementRadius);
        }

        return true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Controller.controller.getCurrentPhase() != Controller.Phases.InGame)
        {
            //return;
        }

        if (!_unit.getIsAttacking() && movementType == MovementType.UNBOUNDED)
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
            else
            {
                _velocity = Vector2.zero;
            }
            
            _rigidBody.velocity = _velocity * _unit.getSpeed() * Time.deltaTime;
        }
        else if (_unit.getIsAttacking())
        {
            if (_unit.isInRange(_unit.range))
            {
                Debug.Log(gameObject + " STOP");
                _rigidBody.velocity = Vector2.zero;
            }
            else if (_unit.getTarget())
            {
                Vector2 direction = (_unit.getTarget().transform.position - transform.position).normalized;
                _rigidBody.velocity = direction * _unit.getSpeed() * Time.deltaTime;
            }
        }
	}

    void LateUpdate()
    {
        if (!checkBounds())
        {
            //_unit.targetOutOfRange();            
        }
    }
}
