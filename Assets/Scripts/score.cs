using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class score : MonoBehaviour
{
    public float scoreP;
    public int Life;
    // public GameObject scoreText;

    [SerializeField] TMPro.TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame

    

    public void modifyScore(float points)
    {
        scoreP += points;
        scoreText.text = "Score: "+scoreP.ToString();
    }
   
}
