using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_move : MonoBehaviour
{

    [Header("�̵� �ӵ� ����")]
    [SerializeField]
    [Range(1f, 50f)]
    float maxSpeed = 20f;
    [Header("���� ���� ����")]
    [SerializeField]
    [Range(1f, 50f)]
    float jumpPower = 40f; //�ӵ� 

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetBool("isJumping", false);
        Debug.Log(collision.transform.name);

    }
    void Update()
    {
        //Jump -> Jump_2p : w
        if (Input.GetButtonDown("Jump") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }

        // Stop Speed 
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float���Ҷ��� f�ٿ�����Ѵ�.
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
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = Vector2.right * h + Vector2.up * v;
        dir.Normalize();

        transform.position += dir * maxSpeed * Time.deltaTime;

    }
}