using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class info_items_is_shop : MonoBehaviour
{
    public GameObject inf;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inf.SetActive(true);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inf.SetActive(false);
    }
}
