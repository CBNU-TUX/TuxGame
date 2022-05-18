using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{
    public float maxSpeed;// 최대속도 설정
    public float jumpPower;
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse); 
            anim.SetBool("isJumping", true);
        }
        // Stop Speed 
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float곱할때는 f붙여줘야한다.

        }

        // change Direction
        if (Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //Walk
        if (Mathf.Abs(rigid.velocity.x) < 0.2) 
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

    }


    void FixedUpdate()
    {
        // Move by Control
        float h = Input.GetAxisRaw("Horizontal"); 
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); 


        // MaxSpeed Limit
        if (rigid.velocity.x > maxSpeed)// right
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Maxspeed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        if (rigid.velocity.y < 0.1f) 
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(0, 1, 0));//에디터 상에서만 레이를 그려준다
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("platform"));
            if (rayHit.collider != null) // 바닥 감지를 위해서 레이저를 쏜다! 
            {
                if (rayHit.distance < 0.5f)
                {
                    anim.SetBool("isJumping", false);
                }
            }
        }
    }
}