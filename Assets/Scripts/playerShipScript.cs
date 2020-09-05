using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShipScript : MonoBehaviour
{
    public float speed;
    Vector3 position;
    private float bound = 9;
    Rigidbody2D shipRb;
    public float fireRate;
    public bool canShoot;
    public GameObject bullet;
    public score PointM;
    public TMPro.TextMeshProUGUI lifeText;
    AudioSource pew;
    int hp = 3;

    // Start is called before the first frame update
    void Start()
    {
        pew = GetComponent<AudioSource>();
        shipRb = GetComponent<Rigidbody2D>();
        position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        movement();

        if (canShoot && Input.GetKey(KeyCode.Space))
        {
            Attack();
        }


    }


    public void movement()
    {

        float controlThrow = Input.GetAxis("Horizontal") * speed;
        Vector2 playerVelocity = new Vector2(controlThrow, shipRb.velocity.y);
        shipRb.velocity = playerVelocity;

        if (transform.position.x < -bound)
        {
            transform.position = new Vector2(bound, transform.position.y);



        }
        else if (transform.position.x > bound)
        {
            transform.position = new Vector2(-bound, transform.position.y);


        }


    }

    private void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        pew.Play();

        GameObject bulletInstance = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        canShoot = false;
        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void takeDamage()
    {
        hp = hp - 1;
        lifeText.text = "Life: "+hp.ToString();
    
        if (hp == 0)
        {
            Destroy(gameObject);
        }

    }


}