using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public static ItemGenerator _ItemGenerator;

    public List<ItemDataBase> ItemList = new List<ItemDataBase>();//список предметов

    void Awake()
    {
        _ItemGenerator = this;//
    }

    //генерация предмета
    public ItemDataBase ItemGen(int win_id)
    {
        ItemDataBase item = new ItemDataBase();

        item.Name = ItemList[win_id].Name;
        item.Id = ItemList[win_id].Id;
        item.IconPatch = ItemList[win_id].IconPatch;
        item.Description = ItemList[win_id].Description;

        return item;
    }
}
