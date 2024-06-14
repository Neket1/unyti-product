using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem_bird_dam : MonoBehaviour
{
    public GameObject enem;
    public GameObject enems;
    public bool tts;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            enem.GetComponent<PGS>()._rb.AddForce(new Vector2(1, 1) * enem.GetComponent<PGS>()._thrust);

        }
        if (collision.transform.gameObject.tag == "Player")
        {
            enem.GetComponent<PGS>()._rb.AddForce(new Vector2(1, 1) * enem.GetComponent<PGS>()._thrust * 2);
            collision.GetComponent<PL>()._rb.AddForce(new Vector2(1, 1) * enem.GetComponent<PGS>()._thrust);
            collision.gameObject.GetComponent<PL>().toDamage_PL(enem.GetComponent<PGS>().dams);
            tts = true;
        }
    }
    private void Update()
    {
        if (tts == true)
        {
            enems.GetComponent<atk_pl>().timer = enems.GetComponent<atk_pl>().time;
            enems.GetComponent<atk_pl>().anim.SetBool("atk_tru", false);
            enems.GetComponent<atk_pl>().atks = false;
            enem.GetComponent<EnemyAi>().nextWaypointDistance = 90;
            tts = false;
        }
    }
}
