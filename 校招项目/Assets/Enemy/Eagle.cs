using Assets.Script.功能接口;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Enemy
{
    private Vector3 Up;

    private Vector3 Down;

    private bool isUp = true;

    void Start()
    {
        Up = transform.FindChild("up").transform.position;

        Down = transform.FindChild("down").transform.position;

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("enemy_fly", true);

        if (isUp)
        {
            if (Up.y < transform.position.y)
            {
                isUp = false;
            }

            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        else
        {
            if(Down.y > transform.position.y)
            {
                isUp = true;
            }

            transform.Translate(-Vector2.up * Speed * Time.deltaTime);
        }
    }

}
