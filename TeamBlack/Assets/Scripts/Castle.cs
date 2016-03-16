using UnityEngine;
using System.Collections;

public class Castle : MonoBehaviour
{
    public int hits;
    //public AudioClip audioClip;
    
    private Rigidbody2D rb2d;
    private BoxCollider2D bc2d;
    private AudioSource audioSource;
    private Player player;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        bc2d = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();
        player = GetComponent<Player>();
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detect the colision between the Castle and Monster
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("> Colision Monster - Castle", gameObject);
        if (other.gameObject.tag == "Monster")
        {
            Debug.Log("> 2Colision Monster - Castle", gameObject);
            player.points++;
            hits++;
            audioSource.Play();
        }
    }

    
}
