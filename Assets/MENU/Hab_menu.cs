using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hab_menu : MonoBehaviour
{
    public GameObject Setings;
    public void Play(int scenid)
    {
        SceneManager.LoadScene(scenid);
    }
    public void setings()
    {
        Setings.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
