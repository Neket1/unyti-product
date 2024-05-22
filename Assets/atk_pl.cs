using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class atk_pl : MonoBehaviour
{
    public bool atks;
    public float time;
    public float timer;
    public float speed;
    public GameObject hero;
    public Animator anim;
    public GameObject enem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.gameObject.tag == "Player" && collision.transform.GetComponent<PL>().imm == false)
        {
            atks = true;
            hero = collision.transform.gameObject;
            enem.GetComponent<EnemyAi>().target = hero.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //hero = null;
    }
    private void Start()
    {
        timer = time;
    }
    private void Update()
    {
        speed = enem.GetComponent<EnemyAi>().speed;
        if (atks== true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                anim.SetBool("atk_tru", true);
                enem.GetComponent<EnemyAi>().nextWaypointDistance = 1;
            }
        }

        if (hero == null)
        {
            timer = time;
            enem.GetComponent<EnemyAi>().nextWaypointDistance = 90;
        }
    }
}
