using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventopy : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>(); //Получение компонента Canvas
        canvas.enabled = false; //Отключение инвентаря при старте
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.enabled = !canvas.enabled; //При нажатии на кнопку E окно будет отображаться или скрываться
        }
    }
}
