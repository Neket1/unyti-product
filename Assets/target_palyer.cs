using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class target_palyer : MonoBehaviour
{
    public Transform targets;//��� ����� ��� �����
    public bool trig;// ������� ����������� ��� ���������
    public Collider2D box;// BoxCollider2D ��� ����� � ��������
    public GameObject enem;
    public Rigidbody2D rb;
    public GameObject tts;
    public GameObject prt;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            trig = true;
            targets = collision.gameObject.transform;// �������� ������� � �������� �� �������
            enem.GetComponent<EnemyAi>().target = targets;//��� �������� �� ��
            //box.enabled = false;// ����� ����� �� ������ �����������
            rb = enem.GetComponent<Rigidbody2D>();
        }
    }
    private void Start()
    {
        //box.enabled= true;// �� ������ �������
    }
    private void Update()
    {
        if (enem.GetComponent<EnemyAi>().enemyGXF.localScale.x == 1)
        {
            tts.transform.localScale = new Vector3(1,1,1);
        }
        else if (enem.GetComponent<EnemyAi>().enemyGXF.localScale.x == -1)
        {
            tts.transform.localScale = new Vector3(-1, 1, 1); 
        }
    }
}