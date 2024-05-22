using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSistem : MonoBehaviour
{
    [Header("Detect Parameters")]
    //detect Point
    public Transform detectionPoin;

    //detect Radius
    private const float detectionsRadius = 0.2f;

    //detection Layer
    public LayerMask detectionLayer;

    //Cached Trigger object
    public GameObject detectionObject;

    [Header("Oters")]
    //list of picked items
    public List<GameObject> pickedItem = new List<GameObject>();
    private void Update()
    {
        if (DetectedObjct())
        {
            if (IntractInput())
            {
                detectionObject.GetComponent<Item>().Interact();
            }
        }
    }

    bool IntractInput()
    {
        return Input.GetKeyDown(KeyCode.F);
    }

    bool DetectedObjct()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoin.position,detectionsRadius,detectionLayer);
        if (obj == null)
        {
            detectionObject = null;
            return false;
        }
        else
        {
            detectionObject = obj.gameObject;
            return true;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoin.position, detectionsRadius);
    }
}
