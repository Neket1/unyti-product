using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class tg_pl : MonoBehaviour
{
    public bool trig;// простое обозначение что сработало
    public Collider2D box;// BoxCollider2D тот самый с тригером
    public GameObject hero;
    public shop shop;

    public int SlotNumbers;
    public GameObject info_pan;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            trig= true;
            hero = collision.transform.gameObject;
            for (int i = 0; i < shop.items_shop_imegas.Length; i++)
            {
                shop.items_shop_imegas[i].GetComponent<slot_evnt_shop>().hero_inv = hero;
                shop.items_shop_imegas[i].GetComponent<slot_evnt_shop>().OnPointerClick(SlotNumbers);
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
