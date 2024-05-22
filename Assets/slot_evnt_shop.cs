using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Item;

public class slot_evnt_shop : MonoBehaviour
{
    public shop shop;
    public Image info_panels;
    public GameObject info_panels_Obj;
    public GameObject hero_inv;

    public GameObject infoPanel_Item;
    public TextMeshProUGUI info_text_Item;
    public TextMeshProUGUI stats_item;
    public int SlotNumbers;
    public int item_price;
    public void OnPointerClick(int SlotNumber)
    {
        for (int i = 0; i < shop.Next_Items_shop.Count; i++)
        {
            if (SlotNumber == i)
            {
                SlotNumbers = SlotNumber;
                infoPanel_Item.SetActive(true);
                Info_pan(shop.Next_Items_shop[i]);
                item_price = shop.Next_Items_shop[i].GetComponent<Item>().prise; 
            }
        }
    }
    public void Info_pan(GameObject item)
    {
        info_panels.sprite = item.GetComponent<SpriteRenderer>().sprite;
        info_panels_Obj = item;
        info_panels.gameObject.SetActive(true);

        if (item.tag == "Sword")
        {
            info_text_Item.text = item.GetComponent<stats_for_damage>().info_item.ToString();
            stats_item.text = "урон: " + item.GetComponent<stats_for_damage>().dаmage.ToString() + "\r" + "\n"
                + "крит урон: " + item.GetComponent<stats_for_damage>().Crit_rate.ToString() + "\r" + "\n"
                + "крит шанс: " + item.GetComponent<stats_for_damage>().Crit_Chance.ToString() + "\r" + "\n"
                + "цена предмета: " + item.GetComponent<Item>().prise.ToString();
        }
        if (item.tag == "ART")
        {
            info_text_Item.text = "тут пока нечего не написано";
            stats_item.text = " и тутчч";
        }
        if (item.tag == "ARMOR")
        {
            info_text_Item.text = "тут пока нечего не написано";
            stats_item.text = " и тут";
        }
    }
    public void use_by()
    {
        //hero_inv = gameObject.GetComponent<tg_pl>().hero;
        for (int i = 0; i < shop.Items_shop.Count; i++)
        {
            if (SlotNumbers == i)
            {
                Debug.Log(info_panels_Obj.name);
                hero_inv.GetComponent<Inventory>().Items.Add(info_panels_Obj);
                shop.items_shop_imegas[i].gameObject.SetActive(false);
                hero_inv.GetComponent<PL>().money = hero_inv.GetComponent<PL>().money - item_price;
            }


        }
        
    }
}
