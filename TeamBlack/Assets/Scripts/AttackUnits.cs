using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class AttackUnits : Unit {
    public float Speed;
    public int Dir;
    private Rigidbody2D _rigidBody;
    private Collider2D _collider;
    private Vector2 _velocity;
    private float _multiplier;

    // Use this for initialization

	public override void Start () {
        Speed = 0.0f;
        _velocity = new Vector2(Time.deltaTime, 0);
        _multiplier = 1.0f;
    }

    public float getSpeed()
    {
        return Speed;
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
   	
	// Update is called once per frame
	public override void Update () { }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            encounterList.Add(collision.gameObject.GetComponent<Unit>());
        }
    }
}
