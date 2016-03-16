using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detect the colision between the Castle and Monster
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log("> Colision Monster - Castle");   
        }
    }

    
}
