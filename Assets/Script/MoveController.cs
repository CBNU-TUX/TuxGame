using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    float moveX;

    [Header("이동 속도 조절")]
    [SerializeField] [Range(1f, 50f)]
    float moveSpeed = 20f;
    [Header("점프 높이 조절")]
    [SerializeField]
    [Range(1f, 50f)]
    float maxJump = 20f;

    SpriteRenderer PlayerSP;
    float jumpTimerLimit = 0.1f; //최대 점프 시간
    float jumpTimer;
    //현재 점프시간이 너무 길기때문에 이를 방지하기 위해서 사용하는 변수이다.

    Rigidbody2D rigid; //자기 자신의 rigid(무게정보)를 가리킴
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
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//float곱할때는 f붙여줘야한다.

        }

        //위치 변환, -1인지와 1인지에 따라서 방향전환 
        if (Input.GetButtonDown("Horizontal"))
            PlayerSP.flipX = Input.GetAxisRaw("Horizontal") == 1;

        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        this.transform.position = new Vector2(transform.position.x + moveX, transform.position.y);


    }


}
