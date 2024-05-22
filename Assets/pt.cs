using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pt : MonoBehaviour
{
    public GameObject player;
    public string main;

    // Update is called once per frame
    void Update()
    {       
        if(SceneManager.GetActiveScene().name== main)
        {
            player.SetActive(false);
        }
        else
        {
            player.SetActive(true);
        }
    }
}
