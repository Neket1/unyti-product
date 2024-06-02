using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ATK : MonoBehaviour
{
    public Animator anim;
    public bool anims;
    public GameObject Obg;
    public float dams;
    public TextMeshProUGUI text;
    public Inventory inv;
    public bool activ;

    void Start()
    {
        Obg.SetActive(false);
        anims = false;
    }

    // Update is called once per frame
    void Update()
    {

        /*if (inv.Items_ATKS.gameObject == false)
        {
            Obg.SetActive(false);
            Obg.GetComponent<SpriteRenderer>().sprite = null;
            anim.SetBool("IsClick", false);
        }*/
        //----------------------------------------------------------SWORD
        if (inv.Items_ATKS != null)
        {
            if (inv.Items_ATKS.gameObject.GetComponent<Item>().tags == "Swordes")
            {
                if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik == 5)
                {
                    inv.Items_ATKS.gameObject.GetComponent<efect_Item>().buf = true;
                    inv.Items_ATKS.gameObject.GetComponent<efect_Item>().times_buf -= Time.deltaTime;
                    activ = true;
                    if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().times_buf <= 0)
                    {
                        inv.Items_ATKS.gameObject.GetComponent<efect_Item>().buf = false;
                        inv.Items_ATKS.gameObject.GetComponent<efect_Item>().clik = 0;
                        inv.Items_ATKS.gameObject.GetComponent<efect_Item>().times_buf = 0;
                        Obg.gameObject.GetComponent<atk_enemy>().damage_enemy = Obg.gameObject.GetComponent<atk_enemy>().damage_enemy / 2;
                        activ = false;
                    }
                }
                if (Input.GetKey(KeyCode.C))
                {
                    Obg.SetActive(true);
                    Obg.GetComponent<SpriteRenderer>().sprite = FindObjectOfType<Inventory>().items_ATK.sprite;
                    anim.Play("Attack");
                }
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("idel"))
                {
                    Obg.SetActive(false);
                }

                Debug.Log("ANIM_IsClick: " + anim.GetBool("IsClick"));
                Debug.Log("ANIM_GetCurrent: " + anim.GetCurrentAnimatorStateInfo(0).IsName("idel"));
            }
        }
        //----------------------------------------------------------------------------------AXE
        if (Input.GetKeyDown(KeyCode.C) && inv.Items_ATKS.gameObject.GetComponent<Item>().tags == "Axe")
        {
            if (Obg.gameObject.GetComponent<atk_enemy>().rnd > 0 && Obg.gameObject.GetComponent<atk_enemy>().rnd < inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_Chance)
            {
                dams = dams * (1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100));
                Debug.Log("cof: " + 1 + (inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().Crit_rate / 100) + "  dams: " + dams);
            }
            Obg.gameObject.GetComponent<atk_enemy>().damage_enemy = inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().dàmage;
            dams = Obg.gameObject.GetComponent<atk_enemy>().damage_enemy;
            Obg.SetActive(true);
            Obg.GetComponent<SpriteRenderer>().sprite = FindObjectOfType<Inventory>().items_ATK.sprite;
            anim.SetBool("IsClick", true);
        }
        else if (Input.GetKeyUp(KeyCode.C) && inv.Items_ATKS.gameObject.GetComponent<Item>().tags == "Axe")
        {
            Obg.SetActive(false);
            anim.SetBool("IsClick", false);
        }
        /*
        if (inv.Items_ATKS.gameObject.GetComponent<efect_Item>().cliks == 5)
        {
            Obg.gameObject.GetComponent<atk_enemy>().damage_enemy = inv.Items_ATKS.gameObject.GetComponent<stats_for_damage>().dàmage * 2;
            dams = Obg.gameObject.GetComponent<atk_enemy>().damage_enemy;
            inv.Items_ATKS.gameObject.GetComponent<efect_Item>().cliks = 0;
        }*/
    }
}
