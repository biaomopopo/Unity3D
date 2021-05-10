using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : Player
{
    public LayerMask groud;

    private Rigidbody2D rb;

    private CircleCollider2D coll;

    private BoxCollider2D boxColi;

    private Animator anim;

    public int continuous_Jump = 2;

    float horizonmove;

    float facedir;

    bool isHurt;

    bool isJump;

    [Header("冲刺参数")]

    public float startDash = -10f;

    public bool isDash;

    public float dashTime;

    private float dashSur;

    public float dashSpeed;

    private float lastDashTime;

    public float dashCool;

    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();

        coll = GetComponent<CircleCollider2D>();

        boxColi = GetComponent<BoxCollider2D>();

        anim.Play("默认动画");
    }


    public void FixedUpdate()
    {
        DashKeyCode();

        Dash();

        if(isDash)
        {
            return;
        }

        if (!isHurt)
        {
            Move();
        }
        SwitchAnim();

        isgroud = Physics2D.OverlapCircle(down.transform.position, 0.1f, groud);
    }

    void DashKeyCode()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (Time.time > lastDashTime + dashCool)
            {
                IsDashTime();
            }
        }
    }

    void IsDashTime()
    {
        isDash = true;

        lastDashTime = Time.time;

        dashSur = dashTime;
    }

    void Dash()
    {
        if(isDash)
        {
            if(dashSur > 0)
            {
                if(!IsGroud() && rb.velocity.y > 0 )
                {
                    rb.velocity = new Vector2(dashSpeed * facedir, jumping_Power * 0.2f);

                }
                if(IsGroud())
                {
                    rb.velocity = new Vector2(dashSpeed * facedir, rb.velocity.y);
                }

                dashSur -= Time.fixedDeltaTime;

                ObjectPoolManager.instance.ExitPool();
            }
            else if(dashSur <= 0)
            {
                isDash = false;

                if (!IsGroud())
                {
                    rb.velocity = new Vector2(dashSpeed * facedir, jumping_Power * 0.2f);
                }
            }
        }
    }
    public override void Update()
    {
        newJump();

        Crouch();
    }

    void newJump()
    {
        if(isgroud)
        {
            continuous_Jump = 2;
        }
        if (continuous_Jump < 0)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space) && continuous_Jump > 0)
        {
            continuous_Jump--;

            rb.velocity = Vector2.up * jumping_Power;

            anim.SetBool("is_jump", true);
        }
    }

    public override void Move()
    {
        horizonmove = Input.GetAxis("Horizontal");

        facedir = Input.GetAxisRaw("Horizontal");

        if(horizonmove != 0)
        {
            rb.velocity = new Vector2(horizonmove* speed, rb.velocity.y);

            anim.SetFloat("is_run", Mathf.Abs(horizonmove));
        }
        if(facedir != 0)
        {
            transform.localScale = new Vector3(facedir * 5, 5, 5);
        }
    }


    public void Crouch()
    {
        if(Input.GetKey(KeyCode.Z) && IsGroud())
        {
            boxColi.enabled = false;

            anim.SetBool("is_getDown", true);
        }
        else if(!Physics2D.OverlapCircle(up.transform.position,0.2f,groud))
        {
            boxColi.enabled = true;

            anim.SetBool("is_getDown", false);
        }

    }


    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGroud())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumping_Power * Time.deltaTime);

            anim.SetBool("is_jump", true);
        }
        if (Input.GetKey(KeyCode.Z) && IsGroud())
        {
            anim.SetBool("is_getDown", true);
        }
        else
        {
            anim.SetBool("is_getDown", false);
        }
    }
    void SwitchAnim()
    {
        if(rb.velocity.y < 0.1f && !IsGroud())
        {
            anim.SetBool("is_fall", true);
        }

        if(anim.GetBool("is_jump"))
        {
            if(rb.velocity.y < 0)
            {
                anim.SetBool("is_jump", false);

                anim.SetBool("is_fall", true);
            }
        }
        else if(isHurt)
        {
            anim.SetBool("is_hurt", true);

            if (Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                anim.SetBool("is_hurt", false);

                anim.SetFloat("is_run", 0);

                isHurt = false;
            }
        }
        else if(coll.IsTouchingLayers(groud))
        {
            anim.SetBool("is_fall", false);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (anim.GetBool("is_fall"))
            {
                Debug.Log("怪物的名字：" + collision.gameObject.name);

                if (collision.gameObject.name == "老鹰一号")
                {
                    UIManager.Instance.Integral_Edition(collision.gameObject.GetComponent<Eagle>().enemy_score);

                    collision.gameObject.GetComponent<Eagle>().animDetah();
                }
                else
                {
                    UIManager.Instance.Integral_Edition(collision.gameObject.GetComponent<Toad>().enemy_score);

                    collision.gameObject.GetComponent<Toad>().animDetah();
                }
                rb.velocity = new Vector2(rb.velocity.x, jumping_Power * Time.deltaTime);
            }
            else if(transform.position.x < collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(-5, rb.velocity.x);
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                rb.velocity = new Vector2(5, rb.velocity.x);
                isHurt = true;
            }
        }
    }

    //判断是否在地面上
    bool IsGroud()
    {
        return Physics2D.OverlapCircle(down.transform.position, 0.1f, groud); 
    }
}
