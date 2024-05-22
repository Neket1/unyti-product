using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU_Buttom : MonoBehaviour
{
    public GameObject gbj;
    private void Start()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        gbj.SetActive(false); 
        Time.timeScale = 1;
    }

    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit_of_mainMenu(int scenid)
    {
        Debug.Log("игра закрылась");
        SceneManager.LoadScene(scenid);
        //Application.Quit();
    }
}
