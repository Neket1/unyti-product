using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class atk_enemy : MonoBehaviour
{
    public int damage_enemy;
    public int rnd;
    public int rnd_enem;
    public Animator anim;
    public float BUF_CRT_dams;
    public bool BUF_CRT_dagems;
    public float BUF_dams;
    public float CRT_dams;
    public string tags;
    public Inventory inv;
    public TextMeshProUGUI stats_item_ATK;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")// если это враг то выполняется это
        {
            rnd = Random.Range(0, 100);
            if (inv.Items_ATKS.GetComponent<Item>().tags == "Axe")
            {
                tags = inv.Items_ATKS.GetComponent<Item>().tags;
                if (inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().bleeding != 5)
                {
                    inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().bleeding += 1;
                }
                ss(rnd);
                collision.gameObject.GetComponent<PGS>().toDamage(damage_enemy);
                collision.gameObject.GetComponent<PGS>().rnd = 0;
            }

            if (inv.Items_ATKS.GetComponent<Item>().tags == "Swordes")
            {
                if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik != 5)
                {
                    inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik += 1;
                }
                ss(rnd);
                collision.gameObject.GetComponent<PGS>().toDamage(damage_enemy);
                collision.gameObject.GetComponent<PGS>().rnd = 0;
            }
            //rnd_enem = Random.Range(1, 2);
            //collision.gameObject.GetComponent<PGS>().rnd = rnd_enem;

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
                stats_item_ATK.text = damage_enemy.ToString();
                inv.Items_ATKS.gameObject.GetComponent<efect_Item>().times_buf = inv.Items_ATKS.gameObject.GetComponent<efect_Item>().time;
                Debug.Log("BUF_dams: " + BUF_dams);
            }

        }

        if (inv.Items_ATKS.gameObject.GetComponent<Item>().tags == "Axe")
        {
            damage_enemy = inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().dаmage;
            inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().times_buf = inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().time;
            if (rnd > 0 && rnd < inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_Chance)
            {
                CRT_dams = damage_enemy * (1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100));
                damage_enemy = Mathf.FloorToInt(CRT_dams);
                Debug.Log("cof: " + (1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100)) + "  CRT_dams: " + CRT_dams);
            }
            if (inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().bleeding == 5 && !BUF_CRT_dagems)
            {
                stats_item_ATK.text = damage_enemy.ToString();
                inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().times_buf = inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().time;
            }
        }

    }
}
