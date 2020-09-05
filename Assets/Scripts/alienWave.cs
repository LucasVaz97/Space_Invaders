using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alienWave : MonoBehaviour
{

    public int numEnemies;
    public int numLines;
    public GameObject alien;
    public GameObject alienHard;
    float xpos=0;
    float ypos = 2.5f;
    public float alDist = 1.3f;
    public float speed = 1f;
    public float wait = 0.4f;
    private bool invert = false;
    public int total;

    // Start is called before the first frame update
    void Start()
    {
        numLines = Random.Range(2, 3);
        numEnemies = Random.Range(5, 8); 
        setX();
        summonWaveY();
        InvokeRepeating("attack", 0, wait);
        total = numEnemies * numLines;
     
    


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setX()
    {

        if (numEnemies % 2 == 0)
            xpos = -((int)numEnemies / 2 * alDist) + 0.375f;
        else
            xpos = -((int)numEnemies / 2 * alDist);
    }



    public void summonWaveY()
    {
        for (int i = 0; i < numLines; i++)
        {
            for (int j = 0; j < numEnemies; j++)
            {
                if (Random.value < 0.10)
                {
                    GameObject alienH = Instantiate(alienHard, new Vector3(xpos, ypos, 0), transform.rotation);
                    alienH.transform.SetParent(transform);

                }
                else
                {
                    GameObject alienS = Instantiate(alien, new Vector3(xpos, ypos, 0), transform.rotation);
                    alienS.transform.SetParent(transform);

                }
               

                xpos += alDist;

            }

            setX();
            ypos += -1.5f;

        }
    }

    void attack()
    {
       
        if (invert)
        {
            speed = -speed;
            gameObject.transform.position += Vector3.down * Mathf.Abs(speed);
            invert = false;
            return;
        }
        else
        {
            gameObject.transform.position += Vector3.right * speed;
        }

        foreach (Transform alien in gameObject.transform)
        {
            if (alien.position.x < -8 || alien.position.x > 8)
            {
                invert = true;
                break;
            }
        }

    }
    public void Re()
    {
        speed = speed * 1.03f;


    
        if (transform.childCount==1)
        {
            speed = 0f;
            numLines = Random.Range(2, 3);
            numEnemies = Random.Range(5,8);
            total = numEnemies * numLines;
            setX();
            ypos = 2.5f;
            transform.position = new Vector2(4.17f, -1.4f);
            summonWaveY();
            speed = 1f;


        }

    }

}
