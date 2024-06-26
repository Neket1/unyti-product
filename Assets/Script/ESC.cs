using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ESC : MonoBehaviour {

    public bool isOpen;
    public GameObject ui_window;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInventory();
        }
        if(ui_window == isOpen)
        {
            gameObject.GetComponent<Inventory>().ui_window.SetActive(false);
        }

        if (isOpen == false)
        {
            Time.timeScale = 1;
        }
    }

    void ToggleInventory()
    {
        isOpen = !isOpen;
        Time.timeScale = 0;
        ui_window.SetActive(isOpen);
    }
}
