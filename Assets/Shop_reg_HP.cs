using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_reg_HP : MonoBehaviour
{
    public Image[] items_shop_imegas;// где будут хранится кортинки предметов
    public List<GameObject> Items_reg_HP_shop = new List<GameObject>();
    public List<GameObject> Next_Items_reg_HP_shop = new List<GameObject>();
    public int rnd;
    private void Start()
    {
        NewItemShop();
    }
    public void NewItemShop()
    {
        for (int i = 0; i < items_shop_imegas.Length; i++)
        {
            rnd = Random.Range(0, Items_reg_HP_shop.Count);
            items_shop_imegas[i].sprite = Items_reg_HP_shop[rnd].GetComponent<SpriteRenderer>().sprite;
            Next_Items_reg_HP_shop[i] = Items_reg_HP_shop[rnd];
            items_shop_imegas[i].gameObject.SetActive(true);
            Debug.Log(rnd);
        }
    }
    public void HideAll()
    {
        foreach (var i in items_shop_imegas) { i.gameObject.SetActive(false); }
    }
}
