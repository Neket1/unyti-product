using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enem_dam : MonoBehaviour
{
    public GameObject enem;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            enem.GetComponent<PGS>()._rb.AddForce(new Vector2(1, 1) * enem.GetComponent<PGS>()._thrust);
            enem.GetComponent<PGS>().text.text = "";
            enem.GetComponent<PGS>().text.text = collision.gameObject.GetComponent<atk_enemy>().damage_enemy.ToString();
            enem.GetComponent<PGS>().text.transform.position = transform.position + Vector3.up * 1;
            enem.GetComponent<PGS>().toDamage(GetComponent<atk_enemy>().damage_enemy);
        }
    }
}
