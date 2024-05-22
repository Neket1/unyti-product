using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGeneralSetting : MonoBehaviour
{
    public static PlayerGeneralSetting _PlayerGenericSetting;

    public static Dictionary<int, ItemDataBase> _Inventory = new Dictionary<int, ItemDataBase>();//»Õ¬≈Õ“¿–‹!!!

    void Awake()
    {
        _PlayerGenericSetting = this;
    }
}
