using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atk_enemy : MonoBehaviour
{
    public int damage_enemy;
    public int rnd;
    public Animator anim;
    public float BUF_CRT_dams;
    public bool BUF_CRT_dagems;
    public float BUF_dams;
    public float CRT_dams;
    public Inventory inv;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")// если это враг то выполняется это
        {
            rnd = Random.Range(0, 100);

            if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik != 5)
            {
                inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik += 1;
            }
            ss(rnd);
            collision.gameObject.GetComponent<PGS>().toDamage(damage_enemy);

        }
    }
    public void ss(int rnd)
    {
        if (inv.Items_ATKS.gameObject.GetComponent<Item>().tags == "Swordes")
        {
            damage_enemy = inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().dаmage;
            if (rnd > 0 && rnd < inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_Chance)
            {
                if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().buf == true)
                {
                    BUF_CRT_dams = inv.Items_ATKS.gameObject.GetComponent<efect_Item>().damag + damage_enemy * (1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100));
                    damage_enemy = Mathf.FloorToInt(BUF_CRT_dams);
                    BUF_CRT_dagems = true;
                    inv.Items_ATKS.gameObject.GetComponent<efect_Item>().times_buf = inv.Items_ATKS.gameObject.GetComponent<efect_Item>().time;
                    Debug.Log("BUF_CRT_dams: " + BUF_CRT_dams);
                }
                else
                {
                    CRT_dams = damage_enemy * (1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100));
                    damage_enemy = Mathf.FloorToInt(CRT_dams);
                    BUF_CRT_dagems = false;
                    Debug.Log("cof: " + (1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100)) + "  CRT_dams: " + CRT_dams);
                }

            }
            if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik == 5 && !BUF_CRT_dagems)
            {
                BUF_dams = inv.Items_ATKS.gameObject.GetComponent<efect_Item>().damag;
                damage_enemy = Mathf.FloorToInt(BUF_dams);
                inv.Items_ATKS.gameObject.GetComponent<efect_Item>().times_buf = inv.Items_ATKS.gameObject.GetComponent<efect_Item>().time;
                Debug.Log("BUF_dams: " + BUF_dams);
            }

        }

    }
    private void Update()
    {
        
    }
}
