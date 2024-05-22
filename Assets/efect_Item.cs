using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class efect_Item : MonoBehaviour
{
    public int clik;
    public int damag;
    public GameObject Obg;
    public bool buf;
    public float time;
    public float times_buf;
   /* public void clicks(int cliks)
    {
        if (cliks == 5)
        {
            buf = true;
            damag = Obg.GetComponent<stats_for_damage>().dàmage * 2;
        }
    }*/
    private void Update()
    {
        if (clik == 5)
        {
            buf = true;
            damag = Obg.GetComponent<stats_for_damage>().dàmage * 2;
        }
    }
}
