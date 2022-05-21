using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    
    [Header("�̵� �ӵ� ����")]
    [SerializeField] [Range(1f, 50f)]
    float maxSpeed = 20f;
    [Header("���� ���� ����")]
    [SerializeField]
    [Range(1f, 50f)]
    float jumpPower = 40f;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    bool isLongJump = false;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Jump
        if (Input.GetButtonDown("Jump_2p") && !anim.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
        // Stop Speed 
        if (Input.GetButtonUp("Horizontal_2p"))
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
        float h = Input.GetAxisRaw("Horizontal_2p");
        float v = Input.GetAxisRaw("Vertical_2p");

        Vector3 dir = Vector2.right * h + Vector2.up * v;
        dir.Normalize();

        transform.position += dir * maxSpeed * Time.deltaTime;
    //    rigid.AddForce(Vector2.right * h+ Vector2.up*v, ForceMode2D.Impulse);

        // MaxSpeed Limit
        /*
        if (rigid.velocity.x > maxSpeed)// right
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1)) // Left Maxspeed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
        */
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));//������ �󿡼��� ���̸� �׷��ش�
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 500, LayerMask.GetMask("platform"));
            if (rayHit.collider != null) // �ٴ� ������ ���ؼ� �������� ���! �ȵ� �������
            {
                if (rayHit.distance < 6f)
                {
                    Debug.Log(rayHit.collider.name);
                    anim.SetBool("isJumping", false);
                }
            }
        }
    }

}
