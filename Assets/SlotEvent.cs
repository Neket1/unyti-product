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
                infoPanel_Item.SetActive(true);
                Info_pan(inven.Items[i]);
            }
        }
    }
    public void Info_pan(GameObject item)
    {
        info_panels.sprite = item.GetComponent<SpriteRenderer>().sprite;
        info_panels.gameObject.SetActive(true);

        if (item.GetComponent<Item>().tag == "Sword")
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
        if (item.GetComponent<Item>().tags == "BreastPlateArmor_down")
        {
            for (int i = 0; i < inven.Items.Count; i++)
            {
                if (st == 2)
                {
                    inven.Items_N_down = item;
                    inven.items_NEGLECT_down_image.sprite = inven.Items_N_down.GetComponent<SpriteRenderer>().sprite;
                    inven.items_NEGLECT_down_image.gameObject.SetActive(true);
                    infoPanel_Item.SetActive(false);
                    inven.Items.Remove(item);
                    inven.items_imegas[i].sprite = null;
                    st = 0;
                }
                info_text_Item.text = item.GetComponent<stats_for_armor>().info_item.ToString();
                stats_item.text = "Снижает получаемый урон на : " + item.GetComponent<stats_for_armor>().def.ToString() + "\r" + "\n"
                    + "цена предмета: " + item.GetComponent<Item>().prise.ToString();
            }
        }

        if (item.tag == "HP_reg")
        {
            if (st == 2)
            {
                FindAnyObjectByType<PL>().Dinamical_HP_bar += 5;
                inven.Items.Clear();
                using_item.SetActive(false);
                infoPanel_Item.SetActive(false);
                Debug.Log("dadsad сделано");
                info_text_Item.text = "Может востановить здаровье игрока";
                stats_item.text = "востанавливает только часть здоровья"; 
                st = 0;
            }
        }
    }
    public void use()
    {
        for (int i = 0; i < inven.Items.Count; i++)
        {
            if (inven.Items[i].gameObject.tag == "HP_reg")
            {
            }
        }
    }
}

