using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObjectOnAllDisabled : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();
    public GameObject targetObject;
    void Update()
    {
        bool allDisabled = true;
        foreach (GameObject obj in objects)
        {
            if (obj.activeSelf)
            {
                Debug.Log(obj.activeSelf);
                allDisabled = false;
                break;
            }
        }

        // ���� ��� ������� � ����� "checkTag" ���������, �������� ������ � ����� "targetTag"
        if (allDisabled)
        {
            targetObject.SetActive(true);
        }
    }
}
