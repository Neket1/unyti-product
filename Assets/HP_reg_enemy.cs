using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HP_reg_enemy : MonoBehaviour
{
    public Slider Slider;
    public Gradient Gradient;
    public Image fill;
    public string HP;
    public void SetMaxHealth(int Health)
    {
        Slider.maxValue = Health;
        Slider.value = Health;
        HP = Slider.maxValue.ToString();
        fill.color = Gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        Slider.value = health;

        if (health <= 0)
        {
            
        }
        else
        {
            fill.color = Gradient.Evaluate(Slider.normalizedValue);
        }
    }
}
