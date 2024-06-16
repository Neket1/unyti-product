using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class elev : MonoBehaviour
{
    public float time;
    public float times;
    public bool trig;
    public Transform pl;
    public Rigidbody2D rb;
    public float tts;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            trig = true;
            pl = collision.gameObject.transform;
            pl.transform.position = new Vector2(pl.transform.position.x, pl.transform.position.y);
            times = Time.deltaTime;
            rb = pl.gameObject.GetComponent<Rigidbody2D>();
        }
        else
        {

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            trig = false;
            times = time;
            rb.gravityScale = 3;
        }
    }
    private void Start()
    {
        times = time;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && trig == true)
        {
            pl.Translate(new Vector2(0, tts) * times);
            rb.gravityScale = 0;
        }
    }
}
