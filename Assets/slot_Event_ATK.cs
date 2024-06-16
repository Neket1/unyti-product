using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class slot_Event_ATK : MonoBehaviour
{
    public Inventory inven;
    public Image info_panels;

    public GameObject infoPanel_Item;
    public GameObject using_item;
    public TextMeshProUGUI info_text_Item;
    public TextMeshProUGUI stats_item;

    public void Take_of_ATK_rClick()
    {
        if (inven.Items_ATKS.gameObject.tag == "Sword")
        {
            Info_pan(inven.Items_ATKS);
            infoPanel_Item.SetActive(true);
            using_item.SetActive(true);
        }
    }
    public void Info_pan(GameObject item)
    {/*
        if (inven.Items_ATKS != null)
        {
            info_panels.sprite = item.GetComponent<SpriteRenderer>().sprite;
            info_panels.gameObject.SetActive(true);

            info_text_Item.text = item.GetComponent<stats_for_damage>().info_item.ToString();
            stats_item.text = "урон: " + item.GetComponent<stats_for_damage>().dаmage.ToString() + "\r" + "\n"
                + "крит урон: " + item.GetComponent<stats_for_damage>().Crit_rate.ToString() + "\r" + "\n"
                + "крит шанс: " + item.GetComponent<stats_for_damage>().Crit_Chance.ToString();
        }*/
    }
    public void use()
    {
        if (inven.Items_ATKS != null)
        {
            inven.Items.Add(inven.Items_ATKS);
            inven.items_ATK.sprite = null;
            inven.items_ATK.gameObject.SetActive(false);
            Debug.Log(inven.Items);
            inven.Items_ATKS = null;
            using_item.SetActive(false);
            infoPanel_Item.SetActive(false);
        }
    }
}