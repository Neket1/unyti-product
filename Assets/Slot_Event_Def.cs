using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Event_Def : MonoBehaviour
{
    public Inventory inven;
    public Image info_panels;
    public PL hero_def;
    public float new_hero_def;
    public float old_hero_def;
    public int st;
    public GameObject infoPanel_Item;
    public GameObject using_item;
    public TextMeshProUGUI info_text_Item;
    public TextMeshProUGUI stats_item;

    public void Take_of_DEF_rClick(int number_slot)
    {
        if (inven.Items_N_up != null && number_slot == 1)
        {
            Info_pan(inven.Items_N_up);
            infoPanel_Item.SetActive(true);
            using_item.SetActive(true);
        }
        if (inven.Items_N_down != null && number_slot == 2)
        {
            Info_pan(inven.Items_N_down);
            infoPanel_Item.SetActive(true);
            using_item.SetActive(true);
        }
    }
    public void Info_pan(GameObject item)
    {
        info_panels.sprite = item.GetComponent<SpriteRenderer>().sprite;
        info_panels.gameObject.SetActive(true);

        info_text_Item.text = item.GetComponent<stats_for_armor>().info_item.ToString();
        stats_item.text = "Снижает получаемый урон на: " + item.GetComponent<stats_for_armor>().def.ToString() + "\r" + "\n";
    }
    public void use( int number_slot)
    {
        if (inven.Items_N_up != null && number_slot == 1)
        {
            inven.Items.Add(inven.Items_N_up);
            inven.items_NEGLECT_up_image.sprite = null;
            inven.items_NEGLECT_up_image.gameObject.SetActive(false);
            Debug.Log(inven.Items);
            inven.Items_N_up = null;
            using_item.SetActive(false);
            infoPanel_Item.SetActive(false);
        }
        if (inven.Items_N_down != null && number_slot == 2)
        {
            inven.Items.Add(inven.Items_N_down);
            inven.items_NEGLECT_down_image.sprite = null;
            inven.items_NEGLECT_down_image.gameObject.SetActive(false);
            //new_hero_def = old_hero_def;
            //hero_def.def = old_hero_def;
            Debug.Log("Предмет"+inven.Items);
            inven.Items_N_down = null;
            using_item.SetActive(false);
            infoPanel_Item.SetActive(false);
        }
    }
    private void Start()
    {
        old_hero_def = hero_def.def;

    }
    private void Update()
    {/*
        if (inven.Items_N_up !=null)
        {

        }
        else
        {
            hero_def.def = old_hero_def;
        }*/

        if (inven.Items_N_down !=null && st != 1)
        {
            st = 1;
            new_hero_def = hero_def.def - inven.Items_N_down.GetComponent<stats_for_armor>().def;

            hero_def.def = new_hero_def;
        }
        else if(inven.Items_N_down == null && st == 1)
        {
            hero_def.def = old_hero_def;
            st = 0;
        }
    }
}
