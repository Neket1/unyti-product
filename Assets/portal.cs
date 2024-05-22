using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class portal : MonoBehaviour
{
    public GameObject hero;
    public float x ;
    public float y ;
    public float z ;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            hero = collision.transform.gameObject;
        }
    }

    public void Next_level(int scenid)
    {
        Debug.Log("прошло успешно!!!!!!!!!");
        hero.GetComponent<Transform>().position = new Vector3(x, y, z);
        SceneManager.LoadScene(scenid);
    }
}
