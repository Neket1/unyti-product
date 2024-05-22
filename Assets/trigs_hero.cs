using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigs_hero : MonoBehaviour
{
    public bool trig;
    public Collider2D box;
    public GameObject hero;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        trig = true;
        
        if (collision.tag == "Player")
        {
            
            hero = collision.gameObject;
            gameObject.GetComponent<chest>().INVEN = hero.GetComponent<Inventory>();
        }
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
