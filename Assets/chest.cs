using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class chest : MonoBehaviour
{
    public GameObject inv_chasta;// инвентарь сунрука где будут предматы
    public bool open;
    public Image[] items_imegas;// где будут хранится кортинки предметов
    public List<GameObject> Items = new List<GameObject>();// где хронятся сами предметы

    public int rnd = 0;// планируется что предметы рандомно будут появлятся
    public GameObject buton; // на кнопку открытие инвенторя сундука

    public Inventory INVEN;// куда будут переносит

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            buton.SetActive(true);
            open = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        buton.SetActive(false);
        inv_chasta.SetActive(false);
        open = false;
    }
    private void Start()
    {
       // rnd = Random.Range(0, gameObjects.Length);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && open == true)
        {
            buton.SetActive(false);
            inv_chasta.SetActive(true);
        }
        
        for (int i = 0; i < Items.Count; i++)
        {
            if(open == true) 
            { 
                if (Input.GetMouseButtonUp(0) == Items[i])
                {
                    Debug.Log("cc");
                   
                    INVEN.Items.Add(Items[i]);
                    INVEN.items_imegas[i].sprite = Items[i].GetComponent<SpriteRenderer>().sprite;
                    INVEN.items_imegas[i].gameObject.SetActive(true);
                    Items.Remove(Items[i]);
                }
            }
        }
        UpdateUI();
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
