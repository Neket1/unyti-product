using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemDataBase
{

    public string Name;//���
    public int Id;//������������� ��������
    public string IconPatch;//���� � ������
    [Multiline] public string Description;//�������� ��������(tooltip)
}
