using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PGS : MonoBehaviour
{
    public GameObject enemy;
    
    public int lifes = 3;
    public int Dinamical_HP_bar;
    public HP_reg_enemy hp_enem;
    public TextMeshProUGUI text;

    public Rigidbody2D _rb;
    public int dams;
    private Vector2 spawnPos;
    public float _thrust = 550f;

    public int dem_pl = 0;

    public void toDamage(int dems)
    {
        if (Dinamical_HP_bar > 0)
        {
            Dinamical_HP_bar -= dems;
            hp_enem.setHealth(Dinamical_HP_bar);
        }
    }
    public void Start()
    {
        spawnPos = enemy.transform.localPosition;
        Dinamical_HP_bar = lifes;
        hp_enem.SetMaxHealth(Dinamical_HP_bar);
        hp_enem.HP = Dinamical_HP_bar.ToString();
    }
    private void Update()
    {
        hp_enem.setHealth(Dinamical_HP_bar);
        if (Dinamical_HP_bar <= 0)
        {
            enemy.transform.localPosition = spawnPos;
            enemy.SetActive(false);
            Dinamical_HP_bar = lifes;
        }  
    } 

}