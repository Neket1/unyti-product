using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pre_portal : MonoBehaviour
{
    public GameObject windowDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            windowDialog.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        windowDialog.SetActive(false);
    }
}
