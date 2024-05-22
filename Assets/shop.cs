using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;
using System.Linq;
using Random = UnityEngine.Random;

public class shop : MonoBehaviour
{
    public Image[] items_shop_imegas;// где будут хранится кортинки предметов
    public List<GameObject> Items_shop = new List<GameObject>();
    public List<GameObject> Next_Items_shop = new List<GameObject>();
    public laver laver;
    public bool NewItem;
    public int rnd;
    public int tt;
    private void Start()
    {
        NewItemShop();
        tt = 0;
    }
    private void Update()
    {
        if (NewItem == true)
        {
            for (int i = 0; i < items_shop_imegas.Length; i++)
            {
                Next_Items_shop.Remove(gameObject);
            }
            NewItemShop();
        }
    }
    public void NewItemShop()
    {
        if (tt != 1)
        {
            tt++;
            for (int i = 0; i < items_shop_imegas.Length; i++)
            {
                rnd = Random.Range(0, Items_shop.Count);
                items_shop_imegas[i].sprite = Items_shop[rnd].GetComponent<SpriteRenderer>().sprite;
                Next_Items_shop[i] = Items_shop[rnd];
                items_shop_imegas[i].gameObject.SetActive(true);
                Debug.Log(rnd);
            }
        }
       
    }
    public void HideAll()
    {
        foreach (var i in items_shop_imegas) { i.gameObject.SetActive(false); }
    }
}
