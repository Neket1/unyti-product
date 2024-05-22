using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>(); //Получение компонента Canvas
        canvas.enabled = false; //Отключение инвентаря при старте
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            canvas.enabled = !canvas.enabled; //При нажатии на кнопку Escape окно будет отображаться или скрываться
        }
    }
}
