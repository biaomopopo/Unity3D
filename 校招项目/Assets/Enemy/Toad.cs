using Assets.Script.功能接口;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : Enemy
{
    Rigidbody2D rb;

    public float jump_force;

    private bool leftFace = true;

    public LayerMask groud;

    private Vector3 left;

    private Vector3 right;

    CircleCollider2D coll;

    // Start is called before the first frame update
    void Start()
    {
        left = this.GetComponent<Transform>().FindChild("left").transform.position;

        right = this.GetComponent<Transform>().FindChild("right").transform.position;

        Debug.Log("左边的位置 " + left + " " + " 右边的位置 " + right);

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        coll = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        SwitchAnim();
    }

    void MoveMent()
    {
        if(leftFace)
        {
            if (transform.position.x < left.x &&IsGroud())
            {
                transform.localScale = new Vector3(-4, 4, 1);

                leftFace = false;
            }
            if (IsGroud())
            {
                rb.velocity = new Vector2(-Speed, jump_force);

                anim.SetBool("enemy_jump", true);
            }
        }
        else
        {
            if (transform.position.x > right.x&&IsGroud())
            {
                transform.localScale = new Vector3(4, 4, 1);

                leftFace = true;
            }
            if (IsGroud())
            {
                rb.velocity = new Vector2(Speed, jump_force);

                anim.SetBool("enemy_jump", true);
            }
        }
    }

    void SwitchAnim()
    {
        if(anim.GetBool("enemy_jump"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("enemy_jump", false);

                anim.SetBool("enemy_fall", true);
            }
        }
        else if(IsGroud() && anim.GetBool("enemy_fall"))
        {
            anim.SetBool("enemy_fall", false);
        }
    }
    //地面检测
    public bool IsGroud()
    {
        return coll.IsTouchingLayers(groud);
    }

   

}
