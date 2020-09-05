using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAlienScript : MonoBehaviour
{

    Rigidbody2D bulletRb;
    public float speed;

    private void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(0, speed);
    }


    void Update()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<playerShipScript>().takeDamage();
            Destroy(gameObject);
        }

        if (collision.tag == "base")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        if (collision.tag == "bullet")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
    }
}
