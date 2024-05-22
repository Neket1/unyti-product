using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_Regenerait : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image fill;
    public string HP;
    public TextMeshProUGUI text;
    public void SetMaxHealth(int Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;
        HP = Slider.maxValue.ToString();
        text.text = HP;
        fill.color = Gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        Slider.value = health;
        
        if(health <=0)
        {
            text.text = "0";
        }
        else
        {
            text.text = health.ToString();
            fill.color = Gradient.Evaluate(Slider.normalizedValue);
        }
    }
}
