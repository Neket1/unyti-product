using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [Header("General Frends")]
    //list of items Piced Up
    public List<GameObject> Items = new List<GameObject>();
    public List<GameObject> Items_N = new List<GameObject>();
    public bool isOpen;
    [Header("UI Items Section")]
    public GameObject ui_window;
    public Image[] items_imegas;
    public Image[] items_NEGLECT;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleInventory();
        }

        UpdateUI();
        Eqyip();
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
        Items_N = Items;
    }

    public void Eqyip()
    {

        for (int i = 0; i < Items_N.Count; i++)
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (Items_N[i].gameObject.tag == "Sword")
                {
                    items_NEGLECT[0].sprite = Items_N[i].GetComponent<SpriteRenderer>().sprite;
                    items_NEGLECT[0].gameObject.SetActive(true);

                    items_imegas[i].gameObject.SetActive(false);
                }

                if (Items_N[i].gameObject.tag == "ARMOR")
                {
                    items_NEGLECT[1].sprite = Items_N[i].GetComponent<SpriteRenderer>().sprite;
                    items_NEGLECT[1].gameObject.SetActive(true);
                }

                if (Items_N[i].gameObject.tag == "ART")
                {
                    items_NEGLECT[3].sprite = Items_N[i].GetComponent<SpriteRenderer>().sprite;
                    items_NEGLECT[3].gameObject.SetActive(true);
                }
            }
        }
    }

    void UpdateUI()
    {
        HideAll();

        for (int i = 0; i < Items.Count; i++)
        {
            items_imegas[i].sprite = Items[i].GetComponent<SpriteRenderer>().sprite;
            items_imegas[i].gameObject.SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var i in items_imegas) { i.gameObject.SetActive(false); }
    }
}


