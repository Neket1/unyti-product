using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tg_pl_hp_reg : MonoBehaviour
{
    public bool trig;// простое обозначение что сработало
    public Collider2D box;// BoxCollider2D тот самый с тригером
    public GameObject hero;

    public GameObject info_pan;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            trig = true;
            hero = collision.transform.gameObject;
            for (int i = 0; i < gameObject.GetComponent<Shop_reg_HP>().items_shop_imegas.Length; i++)
            {
                gameObject.GetComponent<Shop_reg_HP>().items_shop_imegas[i].GetComponent<Slot_event_reg_HP>().hero_inv = hero;
                gameObject.GetComponent<Shop_reg_HP>().items_shop_imegas[i].GetComponent<Slot_event_reg_HP>().OnPointerClick();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        info_pan.SetActive(false);
    }
    private void Start()
    {
        box.enabled = true;// со старта включен
    }
}
