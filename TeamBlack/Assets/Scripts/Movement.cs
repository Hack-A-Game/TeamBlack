﻿using UnityEngine;
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
    private Animator _animator;

    public MovementType movementType;
    public float movementRadius;

    // Use this for initialization
    void Start()
    {
        _unit = GetComponent<Unit>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _animator = GetComponent<Animator>();
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
            return;
        }

        if (!_unit.getIsAttacking() && movementType == MovementType.UNBOUNDED)
        {
            _position = Controller.map.ToGridPos(transform.position);

            if (Controller.map.UnitCanMove(_position, Direction.right))
            {
                _velocity = Vector2.right;
                _animator.SetInteger("status", 1);
            }
            else if (Controller.map.UnitCanMove(_position, Direction.down))
            {
                _velocity = Vector2.down;
                _animator.SetInteger("status", 4);
            }
            else
            {
                _velocity = Vector2.zero;
                _animator.SetInteger("status", 0);
            }
            
            _rigidBody.velocity = _velocity * _unit.getSpeed() * Time.deltaTime;
        }
        else if (_unit.getIsAttacking() && _unit.getTarget())
        {
            _animator.SetInteger("status", 6);
            if (_unit.isInRange(_unit.range))
            {
                Debug.Log(gameObject + " STOP");
                _rigidBody.velocity = Vector2.zero;
            }
            else
            {
                Vector2 direction = (_unit.getTarget().transform.position - transform.position).normalized;
                _rigidBody.velocity = direction * _unit.getSpeed() * Time.deltaTime + new Vector2(Time.deltaTime * 2, 0);
            }

            if (movementType == MovementType.UNBOUNDED)
            {
                gridPos pos = Controller.map.ToGridPos(transform.position);
                if (!Controller.map.hasFlag(pos, TileAtt.Passable))
                {
                    _rigidBody.velocity = Vector2.zero;
                }
            }
        }
        else
        {
            _rigidBody.velocity = Vector2.zero;
            _unit.resetAttacking();
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
