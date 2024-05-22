using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{   
    public CharactController2D controller;
    public Animator anim;

    public float runSpeed = 40f;//��������
    public Rigidbody2D rb;
    float horizontalMove = 0f;//��� �

    bool jump = false;
    public Collider2D col_crouch;
    bool crouch = false;

    [Header("Dash")]
    public float Dash;
    public float increases;
    public bool immortals;

    [Header("timer")]
    public float dash_time = 2f;
    public float taimer = 0f;
    private void Start()
    {
        taimer = dash_time;
        Dash = runSpeed * increases;
    }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            anim.SetBool("IsJamping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            col_crouch.GetComponent<CapsuleCollider2D>().size = new Vector2(col_crouch.GetComponent<CapsuleCollider2D>().size.x, col_crouch.GetComponent<CapsuleCollider2D>().size.y / 2);
            col_crouch.GetComponent<CapsuleCollider2D>().offset = new Vector2(col_crouch.GetComponent<CapsuleCollider2D>().offset.x, col_crouch.GetComponent<CapsuleCollider2D>().offset.y * 1.5f);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            col_crouch.GetComponent<CapsuleCollider2D>().size = new Vector2(col_crouch.GetComponent<CapsuleCollider2D>().size.x, col_crouch.GetComponent<CapsuleCollider2D>().size.y * 2);
            col_crouch.GetComponent<CapsuleCollider2D>().offset = new Vector2(col_crouch.GetComponent<CapsuleCollider2D>().offset.x, col_crouch.GetComponent<CapsuleCollider2D>().offset.y / 1.5f);
        }
            Dash = runSpeed * increases;

        if (Input.GetKey(KeyCode.LeftShift) && Dash != 0)
        {
            taimer -= Time.deltaTime;

            if(taimer > 0f)
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * Dash;
                //rb.AddForce(new Vector2(1, 0) * Dash);
                immortals = true;
            }
            else
            {
                horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
                immortals = false;
            }
        }
        else
        {
            taimer = dash_time;
            immortals = false;
        }
    }
    public void OnLanding()
    {
        anim.SetBool("IsJamping", false);

    }
    public void OnCrocuhing(bool isCrouching)
    {
        anim.SetBool("isCroching", isCrouching);
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
