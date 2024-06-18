using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("General Frends")]
    //list of items Piced Up
    public List<GameObject> Items = new List<GameObject>();
    public List<GameObject> info_Panel = new List<GameObject>();
    public List<GameObject> Items_ARTS = new List<GameObject>();
    public GameObject Items_ATKS;
    public GameObject Items_N_up;
    public GameObject Items_N_down;

    public bool isOpen;

    [Header("UI Items Section")]
    public GameObject ui_window;

    [Header("Info panel")]
    public GameObject infoPanel_Item;
    public TextMeshProUGUI info_text_Item;    
    public TextMeshProUGUI stats_item;

    public Image[] items_imegas;
    public Image[] info_panels;
    public Image[] items_ART;
    public Image items_ATK;
    public Image items_NEGLECT_up_image;
    public Image items_NEGLECT_down_image;

    [Header("Info STATS")]
    public TextMeshProUGUI stats_item_def;
    public TextMeshProUGUI stats_item_atk;
    public TextMeshProUGUI stats_item_crtD;
    public TextMeshProUGUI stats_item_crtR;

    public void Start()
    {
        stats_item_def.text = FindObjectOfType<PL>().def.ToString();
        HideAlls();
        items_ATK.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }
        UpdateUI();


        if (Items_N_up != null)
        {
            stats_item_def.text = FindObjectOfType<PL>().def.ToString();
        }

        if (Items_N_down != null)
        {
            stats_item_def.text = FindObjectOfType<PL>().def.ToString();
        }
        if (Items_ATKS != null)
        {
            stats_item_atk.text = Items_ATKS.GetComponent<stats_for_damage>().dàmage.ToString();
            stats_item_crtD.text = Items_ATKS.GetComponent<stats_for_damage>().Crit_rate.ToString();
            stats_item_crtR.text = Items_ATKS.GetComponent<stats_for_damage>().Crit_Chance.ToString();
        }
    }
    void ToggleInventory()
    {
        isOpen = !isOpen;

        ui_window.SetActive(isOpen);
    }
    //add the Item to the Items list
    public void PickUp(GameObject item)
    {
        Items.Add(item);
        UpdateUI();
    }/*
    //___________________________________________________________________//
    //                                ATK
    public void Eqp_ATK(GameObject item)
    {
        //Info_pan(item);
        //Items_ATKS.Add(item);
        UpdateUI();
    }
    //___________________________________________________________________//
    //                                ARMOR
    public void Eqp_ARMOR(GameObject item)
    {
        Items_N.Add(item);
        UpdateUI();
    }*/
    //____________________________________________________________________//
    //                                ART
    public void Eqp_ART(GameObject item)
    {
        Items_ARTS.Add(item);
        UpdateUI();
    }
    void UpdateUI()
    {
        HideAll();

        for (int i = 0; i < Items.Count; i++)
        {
            items_imegas[i].sprite = Items[i].GetComponent<SpriteRenderer>().sprite;
            items_imegas[i].gameObject.SetActive(true);
        }/*
        //_____________ATK
        items_ATK.sprite = Items_ATKS.GetComponent<SpriteRenderer>().sprite;
        items_ATK.gameObject.SetActive(true);
        infoPanel_Item.SetActive(false);
        info_Panel.Clear();
        //_____________ARMOR
        for (int i = 0; i < Items_N.Count; i++)
        {
            if (Input.GetMouseButton(0))
            {
                items_NEGLECT[i].sprite = Items_N[i].GetComponent<SpriteRenderer>().sprite;
                items_NEGLECT[i].gameObject.SetActive(true);
                infoPanel_Item.SetActive(false);
                info_Panel.Clear();
            }
        }*/
        //_____________ART
        for (int i = 0; i < Items_ARTS.Count; i++)
        {
            if (Input.GetMouseButton(0))
            {
                items_ART[i].sprite = Items_ARTS[i].GetComponent<SpriteRenderer>().sprite;
                items_ART[i].gameObject.SetActive(true);
                infoPanel_Item.SetActive(false);
                info_Panel.Clear();
            }
        }
    }
    
    void HideAll()
    {
        foreach(var i in items_imegas) {i.gameObject.SetActive(false); }
    }
    void HideAlls()
    {
        foreach (var i in items_ART) { i.gameObject.SetActive(false); }
        //foreach (var i in items_ATK) { i.gameObject.SetActive(false); }
        items_ATK.gameObject.SetActive(false);
        items_NEGLECT_down_image.gameObject.SetActive(false);
        items_NEGLECT_up_image.gameObject.SetActive(false);
        foreach (var i in info_panels) { i.gameObject.SetActive(false); }
    }
}
