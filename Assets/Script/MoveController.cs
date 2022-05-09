using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    float moveX;

    [Header("�̵� �ӵ� ����")]
    [SerializeField] [Range(1f, 50f)]
    float moveSpeed = 20f;
    [Header("���� ���� ����")]
    [SerializeField]
    [Range(1f, 50f)]
    float maxJump = 20f;

    SpriteRenderer PlayerSP;
    float jumpTimerLimit = 0.1f; //�ִ� ���� �ð�
    float jumpTimer;
    //���� �����ð��� �ʹ� ��⶧���� �̸� �����ϱ� ���ؼ� ����ϴ� �����̴�.

    Rigidbody2D rigid; //�ڱ� �ڽ��� rigid(��������)�� ����Ŵ
    bool is_Jumping;

    // Start is called before the first frame update
    void Start()
    {
        PlayerSP = this.GetComponent<SpriteRenderer>();
        rigid = this.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        is_Jumping = false;

        rigid.gravityScale = 1.0f;
    }
    // Update is called once per frame
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.UpArrow) && !is_Jumping)
        {
            rigid.AddForce(Vector2.up * maxJump, ForceMode2D.Impulse);
            is_Jumping = true;
        }
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float���Ҷ��� f�ٿ�����Ѵ�.

        }

        //��ġ ��ȯ, -1������ 1������ ���� ������ȯ 
        if (Input.GetButtonDown("Horizontal"))
            PlayerSP.flipX = Input.GetAxisRaw("Horizontal") == 1;

        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        this.transform.position = new Vector2(transform.position.x + moveX, transform.position.y);


    }


}
