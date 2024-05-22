using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trg_PL : MonoBehaviour
{
    public Camera targets;//тут будет наш игрок
    public bool trig;// простое обозначение что сработало
    public BoxCollider2D box;// BoxCollider2D тот самый с тригером
    public Canvas Canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targets = collision.GetComponent<PL>().cam;
            Canvas.worldCamera = targets;
        }
    }
    private void Start()
    {
        box.enabled = true;// со старта включен
    }
    private void Update()
    {
       
    }
}
