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
        //----------------------------------------------------------------------------------AXE
            if (inv.Items_ATKS.gameObject.GetComponent<Item>().tags == "Axe")
            {
                if (inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().bleeding == 5)
                {
                    inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().buf = true;
                    inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().times_buf -= Time.deltaTime;
                    activ = true;
                    FindObjectOfType<PGS>().Bladings();
                    if (inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().times_buf <= 0)
                    {

                        inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().buf = false;
                        inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().bleeding = 0;
                        inv.Items_ATKS.gameObject.GetComponent<Buf_of_AXE>().times_buf = 0;
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
            }
        }
    }
}
