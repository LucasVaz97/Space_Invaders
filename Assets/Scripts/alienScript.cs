using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienScript : MonoBehaviour
{

    public GameObject bullet;
    public int hp = 1;
    public int point=10;
    public playerShipScript Player;
    public Animator AlienAni;
    score PointM;
    public alienWave wave;
    AudioSource Bom;
    // Start is called before the first frame update
    void Start()
    {
        Bom = GetComponent<AudioSource>();
        Player = FindObjectOfType<playerShipScript>();
        PointM = Player.GetComponent<score>();
        AlienAni = GetComponent<Animator>();
        wave = transform.parent.GetComponent<alienWave>();
        StartCoroutine(AttackRoutine());

      
    }

    // Update is called once per frame



    IEnumerator AttackRoutine()
    {
        while (true) {
            int timer = Random.Range(3, 8);
            yield return new WaitForSeconds(timer);
            if (Random.value < 0.3)
            {
                GameObject bulletInstance = Instantiate(bullet, transform.position, transform.rotation);

            }

           
        }

     
    }

    void Die()
    {

        Destroy(gameObject);
        wave.Re();


    }

    public void TakeHit()
    {
        hp = hp - 1;

        if (hp <= 0)
        {
            PointM.modifyScore(point);


            AlienAni.SetTrigger("death");
            Bom.Play();
           

        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
  
      

        if (collision.tag == "Player")
        {

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.tag == "base")
        {
            Destroy(collision.gameObject);

        }
    }
}
