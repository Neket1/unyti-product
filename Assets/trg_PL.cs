using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trg_PL : MonoBehaviour
{
    public Camera targets;//��� ����� ��� �����
    public bool trig;// ������� ����������� ��� ���������
    public BoxCollider2D box;// BoxCollider2D ��� ����� � ��������
    public Canvas Canvas;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targets = collision.GetComponent<PL>().cam;
            Canvas.worldCamera = targets;
        }
    }
    private void Start()
    {
        box.enabled = true;// �� ������ �������
    }
    private void Update()
    {
       
    }
}
