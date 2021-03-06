using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float speed;
    Animator animator;
    Rigidbody2D rigid;
    Vector2 move,direction;
    // Start is called before the first frame update
    void Start()
    {
        animator=this.GetComponent<Animator>();
        rigid=this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x=Input.GetAxisRaw("Horizontal");
        move.y=Input.GetAxisRaw("Vertical");

        animator.SetFloat("MoveSpeed", move.sqrMagnitude * speed);
        animator.speed = speed / 4; // 이동 속도의 4분의 1만큼의 빠르기로 애니메이션 재생

        if(move.sqrMagnitude>0){
            direction.x=Input.GetAxisRaw("Horizontal");
            direction.y=Input.GetAxisRaw("Vertical");
        }
         if (animator.GetFloat("MoveSpeed") > 0)
            {
                // 이동
                animator.SetFloat("MoveHorizontally", move.x);
                animator.SetFloat("MoveVertically", move.y);
            }

    }


     void FixedUpdate()
    {
        rigid.MovePosition(rigid.position + move * speed * Time.deltaTime);
    }

}
