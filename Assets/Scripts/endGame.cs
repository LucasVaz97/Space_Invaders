using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{

    public GameObject player;
    [SerializeField] TMPro.TextMeshProUGUI DefeatScreen;

    void Update()
    {
        if (player == null)
            DefeatScreen.text = "Defeat\nPress R  \n     to \nRestart.";
        if(Input.GetKey(KeyCode.R)){

            SceneManager.LoadScene("SampleScene");
        }
       

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            Destroy(player);
        }
    }
}
