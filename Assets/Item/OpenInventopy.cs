using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenInventopy : MonoBehaviour
{
    private Canvas canvas;

    void Start()
    {
        canvas = GetComponent<Canvas>(); //��������� ���������� Canvas
        canvas.enabled = false; //���������� ��������� ��� ������
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            canvas.enabled = !canvas.enabled; //��� ������� �� ������ E ���� ����� ������������ ��� ����������
        }
    }
}
