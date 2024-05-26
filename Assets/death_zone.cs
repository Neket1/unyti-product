using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death_zone : MonoBehaviour
{
    public GameObject hero;
    public int death_atk;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            hero = collision.gameObject;
            death_atk = hero.GetComponent<PL>().max_HP;
            hero.GetComponent<PL>().Dinamical_HP_bar -= death_atk;
        }
    }

}
