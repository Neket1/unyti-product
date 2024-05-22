using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot_event_reg_HP : MonoBehaviour
{
    public Shop_reg_HP shop;
    public Image info_panels;
    public GameObject info_panels_Obj;
    public GameObject hero_inv;

    public GameObject infoPanel_Item;
    public TextMeshProUGUI info_text_Item;
    public TextMeshProUGUI stats_item;
    public int item_price;
    public void OnPointerClick()
    {
        for (int i = 0; i < shop.Next_Items_reg_HP_shop.Count; i++)
        {
            infoPanel_Item.SetActive(true);
            Info_pan(shop.Next_Items_reg_HP_shop[i]);
            item_price = shop.Next_Items_reg_HP_shop[i].GetComponent<Item>().prise;
        }
    }
    public void Info_pan(GameObject item)
    {
        info_panels.sprite = item.GetComponent<SpriteRenderer>().sprite;
        info_panels_Obj = item;
        info_panels.gameObject.SetActive(true);

        if (item.tag == "HP_reg")
        {
            info_text_Item.text = "Может востановить здаровье игрока";
            stats_item.text = "востанавливает только часть здоровья";
        }
    }
    public void use_by()
    {
        //hero_inv = gameObject.GetComponent<tg_pl>().hero;
        for (int i = 0; i < shop.Items_reg_HP_shop.Count; i++)
        {
            Debug.Log(info_panels_Obj.name);
            hero_inv.GetComponent<Inventory>().Items.Add(info_panels_Obj);
            shop.Items_reg_HP_shop.Remove(info_panels_Obj);
            hero_inv.GetComponent<PL>().money = hero_inv.GetComponent<PL>().money - item_price;
        }

    }
}
