using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AttackUnits : Unit {
    public int Dir;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private Vector2 _velocity;
    private float _multiplier;

    // Use this for initialization

	public override void Start ()
    {
        base.Start();
        _velocity = new Vector2(Time.deltaTime, 0);
        _multiplier = 1.0f;
    }
    
    public Rigidbody2D getRigidBody()
    {
        return _rigidBody;
    }

    public Collider2D getCollider()
    {
        return _collider;
    }

    public Vector2 getVelocity()
    {
        return _velocity;
    }

    public float getMultiplier()
    {
        return _multiplier;
    }
}
