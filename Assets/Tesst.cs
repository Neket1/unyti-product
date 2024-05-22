using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tesst : MonoBehaviour
{// эта хрень может не работать потомучто курсор скрипт включен на персонаже

    public CapsuleCollider2D collisions;
    public Rigidbody2D selectedObject;

    public bool trig;
    Vector3 offset;
    Vector3 mousePosition;

    public float maxSpeed = 10;

    Vector2 mouseForce;
    Vector3 lastPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Attake_Item")
        {
            trig = true;
        }
    }
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (selectedObject)
        {
            mouseForce = (mousePosition - lastPosition) / Time.deltaTime;
            mouseForce = Vector2.ClampMagnitude(mouseForce, maxSpeed);
            lastPosition = mousePosition;
        }
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            if (targetObject)
            {
                if (trig == targetObject)
                {
                    selectedObject = targetObject.transform.gameObject.GetComponent<Rigidbody2D>();
                    offset = selectedObject.transform.position - mousePosition;
                }
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject.velocity = Vector2.zero;
            selectedObject.AddForce(mouseForce, ForceMode2D.Impulse);
            selectedObject = null;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        trig = false;
        if (selectedObject)
        {
            selectedObject.velocity = Vector2.zero;
            selectedObject.AddForce(mouseForce, ForceMode2D.Impulse);
            selectedObject = null;
        }
    }
    void FixedUpdate()
    {
        if (selectedObject)
        {
            selectedObject.MovePosition(mousePosition + offset);
        }
    }
}
