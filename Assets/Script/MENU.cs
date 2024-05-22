using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>(); //��������� ���������� Canvas
        canvas.enabled = false; //���������� ��������� ��� ������
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            canvas.enabled = !canvas.enabled; //��� ������� �� ������ Escape ���� ����� ������������ ��� ����������
        }
    }
}
