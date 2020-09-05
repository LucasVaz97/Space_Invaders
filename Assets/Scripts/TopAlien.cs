using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopAlien : MonoBehaviour
{
    Rigidbody2D topAlienRb;
    public float vel;
    public GameObject Bullet;
    Animator topAlienAn;
    public GameObject player;
    score scoreP;
    AudioSource Bom;

    int pos = 1;
    int hp = 4;
    public int velMult = 1;
    // Start is called before the first frame update
    void Start()
    {
        Bom = GetComponent<AudioSource>();
        scoreP = player.GetComponent<score>();
        topAlienRb = GetComponent<Rigidbody2D>();
        topAlienRb.velocity = new Vector2(vel, 0);
        topAlienAn=GetComponent<Animator>();
        StartCoroutine("Shot");

    }

    // Update is called once per frame
    void Update()
    {
        Move();
       

    }

    void Move()
    {
        topAlienRb.velocity = new Vector2(vel*velMult, 0);
  
        if (transform.position.x < -7 || transform.position.x >= 7)
        {
      
            transform.position = new Vector2(6.8f*pos, transform.position.y);
            vel = vel * -1;
            pos = pos * -1;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")

        {
            Destroy(collision.gameObject);
            TakeHit();
            
        }
    }
    void TakeHit()
    {
        hp = hp - 1;
        if (hp == 0)
        {
            scoreP.modifyScore(50);
            Destroy(gameObject);
        }

    }

    IEnumerator Shot()
    {

        while (true){
            topAlienAn.SetTrigger("shoot");
            yield return new WaitForSeconds(3f);
        }



    }

    public void bulletSu()
    {
        Vector3 pos2 = new Vector2(transform.position.x - 0.7f, transform.position.y - 0.6f);
        Vector2 pos1 = new Vector2(transform.position.x + 0.7f, transform.position.y - 0.6f);
        Instantiate(Bullet, pos1, transform.rotation);
        Instantiate(Bullet, pos2, transform.rotation);

    }
}
