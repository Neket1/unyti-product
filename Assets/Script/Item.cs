using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Item;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType { NONE,PickUp,Examine}
    public InteractionType type;
    public string tags;
    public int prise;
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
        gameObject.layer = 7;
    }
    public void Interact()
    {
        switch(type)
        {
            case InteractionType.PickUp:
                //add object to the PickedUpItems list
                FindObjectOfType<Inventory>().PickUp(gameObject);
                //Desaible the object
                gameObject.SetActive(false);
                Debug.Log("PICK UP");
                break;
            case InteractionType.Examine:
                Debug.Log("EXAMINE");
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }
}
