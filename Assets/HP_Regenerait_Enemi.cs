using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_Regenerait_Enemi : MonoBehaviour
{
    public static Image bar;
    float value;
    private void Start()
    {
        bar = GetComponent<Image>();
    }

    public static void SetHPBarValue(float value)
    {
        bar.fillAmount = value;
    }
    public static float GetHPBarValue()
    {
        return bar.fillAmount;
    }
}
