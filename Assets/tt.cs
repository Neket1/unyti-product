using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Item;

public class tt : MonoBehaviour
{
    [Header("timer")]
    public float time = 2f;
    public float taimer = 0f;
    public Transform tst;
    public int rnd;
    public Vector2 ss;
    private void Start()
    {
        taimer = time;
        ss = tst.localPosition;
    }
    // Update is called once per frame
    void Update()
    {
        taimer -= Time.deltaTime;

        if (taimer < 5.1f && taimer > 5f)
        {
            rnd = Random.Range(0, 5);
        }
        if (taimer < 3f && taimer > 1.5)
        {
            switch (rnd)
            {
                case 0:
                    ss.x -= 1;
                    tst.localPosition = ss;
                    break;
                case 1:
                    ss.x += 1;
                    tst.localPosition = ss;
                    break;
                case 2:
                    ss.x += 1;
                    ss.y -= 1;
                    tst.localPosition = ss;
                    break;
                case 3:
                    ss.x -= 1;
                    ss.y -= 1;
                    tst.localPosition = ss;
                    break;
                case 4:
                    ss.x -= 1;
                    ss.y += 1;
                    tst.localPosition = ss;
                    break;
                case 5:
                    ss.x += 1;
                    ss.y += 1;
                    tst.localPosition = ss;
                    break;
                default:
                    Debug.Log("нучего не произошло");
                    break;
            }
        }
        if (taimer < 1.4f && taimer > 1.3)
        {
            ss.x = 0;
            ss.y = 0;
            tst.localPosition = ss;
        }
        if (taimer < 0)
        {
            taimer = time;
        }
    }
}
