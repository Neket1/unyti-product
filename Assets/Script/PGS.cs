using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PGS : MonoBehaviour
{
    public GameObject enemy;
    
    public int lifes = 3;
    public int Dinamical_HP_bar;
    public HP_reg_enemy hp_enem;

    [Header("TXT_DAM")]
    public TextMeshProUGUI text; 
    public Animator anim;
    public GameObject TXT;
    public int rnd;

    public Rigidbody2D _rb;
    public float dams;
    private Vector2 spawnPos;
    public float _thrust = 550f;

    public int dem_pl = 0;
    public float spawnRadius; // Радиус спауна

    public void toDamage(int dems)
    {
        if (Dinamical_HP_bar > 0)
        {
            Dinamical_HP_bar -= dems;
            hp_enem.setHealth(Dinamical_HP_bar);
            add_TXT_dam(dems);
        }
    }
    public void add_TXT_dam(int dam)
    {
        //Vector2 randomPosition = TXT.transform.localScale * Time.deltaTime;
        rnd = Random.Range(1, 2);
        text.text = dam.ToString();
        anim.SetInteger("TXT_dam", rnd);
            //("TXT_dam", rnd);
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