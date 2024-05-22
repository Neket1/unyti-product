using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laver : MonoBehaviour
{
    public Animator anim;
    public bool NewItem;
    public shop shop;
    private void Start()
    {
        anim.SetBool("lav", true);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            anim.Play("laver");
            shop.NewItem = true;
            Debug.Log("сработало");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("laver_idel"))
        {
            shop.NewItem = false;
            FindObjectOfType<shop>().tt = 0;
        }
    }
}
