using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotEvent : MonoBehaviour
{
    public Inventory inven;
    public Image info_panels;

    public GameObject infoPanel_Item;
    public GameObject using_item;
    public TextMeshProUGUI info_text_Item;
    public TextMeshProUGUI stats_item;

    public int st;
    public void onPointerClick(int SlotNumber)
    {
        st += 1;

        for (int i = 0; i < inven.Items.Count; i++)
        {
            if (SlotNumber == i)
            {
                if (inven.Items[i].gameObject.tag == "Sword")
                {
                    infoPanel_Item.SetActive(true);
                    Info_pan(inven.Items[i]);
                }
                else
                {
                    infoPanel_Item.SetActive(false);
                }
                /*
                if (inven.Items[i].gameObject.tag == "ART")
                {
                    Info_pan(inven.Items[i]);
                    inven.Items_ARTS.Add(inven.Items[i]);
                    inven.Items.Remove(inven.Items[i]);
                    inven.items_imegas[i].sprite = null;
                }
                else
                {
                    infoPanel_Item.SetActive(false);
                }

                if (inven.Items[i].gameObject.tag == "ARMOR")
                {
                    Info_pan(inven.Items[i]);
                    inven.Items_N.Add(inven.Items[i]);
                    inven.Items.Remove(inven.Items[i]);
                    inven.items_imegas[i].sprite = null;
                }
                else
                {
                    infoPanel_Item.SetActive(false);
                }*/

                if (inven.Items[i].gameObject.tag == "HP_reg")
                {
                    infoPanel_Item.SetActive(true);
                    Info_pan(inven.Items[i]);
                    using_item.SetActive(true);
                }
            }
        }
    }
    public void Info_pan(GameObject item)
    {
        info_panels.sprite = item.GetComponent<SpriteRenderer>().sprite;
        info_panels.gameObject.SetActive(true);

        if (item.tag == "Sword")
        {
            for (int i = 0; i < inven.Items.Count; i++)
            {
                if (st == 2)
                {
                    inven.Items_ATKS = item;
                    inven.items_ATK.sprite = inven.Items_ATKS.GetComponent<SpriteRenderer>().sprite;
                    inven.items_ATK.gameObject.SetActive(true);
                    infoPanel_Item.SetActive(false);
                    inven.Items.Remove(item);
                    inven.items_imegas[i].sprite = null;
                    st = 0;
                }
                info_text_Item.text = item.GetComponent<stats_for_damage>().info_item.ToString();
                stats_item.text = "урон: " + item.GetComponent<stats_for_damage>().dаmage.ToString() + "\r" + "\n"
                    + "крит урон: " + item.GetComponent<stats_for_damage>().Crit_rate.ToString() + "\r" + "\n"
                    + "крит шанс: " + item.GetComponent<stats_for_damage>().Crit_Chance.ToString() + "\r" + "\n"
                    + "цена предмета: " + item.GetComponent<Item>().prise.ToString();
            }
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

        if (item.tag == "HP_reg")
        {
            info_text_Item.text = "Может востановить здаровье игрока";
            stats_item.text = "востанавливает только часть здоровья";
        }
    }
    public void use()
    {
        for (int i = 0; i < inven.Items.Count; i++)
        {
            if (inven.Items[i].gameObject.tag == "HP_reg")
            {
                FindAnyObjectByType<PL>().Dinamical_HP_bar += 5;
                inven.Items.Clear();
                using_item.SetActive(false);
                infoPanel_Item.SetActive(false);
                Debug.Log("dadsad сделано");
            }
        }
    }
}

