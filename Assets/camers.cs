using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camers : MonoBehaviour
{
    public Camera targets;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targets = collision.GetComponent<PL>().cam;
            Camera.main.transform.parent = null;
        }
    }
    private void Update()
    {
            
    }
}
