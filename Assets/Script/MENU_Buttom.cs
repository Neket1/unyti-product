using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MENU_Buttom : MonoBehaviour
{
    public GameObject gbj;
    public GameObject Setings;
    private void Start()
    {
    }
    public void Play()
    {
        gbj.SetActive(false);
        FindAnyObjectByType<ESC>().isOpen = false;
        Time.timeScale = 1;
    }
    public void OpenSetings()
    {
        gbj.SetActive(false);
        Setings.SetActive(true);
    }
    public void ReastartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gbj.SetActive(false);
        FindAnyObjectByType<ESC>().isOpen = false;
    }
    public void Exit_of_mainMenu(int scenid)
    {
        Debug.Log("игра закрылась");
        SceneManager.LoadScene(scenid);
        //Application.Quit();
    }
}
