using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Moving : MonoBehaviour
{
    public float maxSpeed;
    Animator animator;
    SpriteRenderer renderer;
    Rigidbody2D rigid;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Stop Speed 
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
         GlobalTimer.timer+=Time.deltaTime;
    }

    void FixedUpdate()
    {
        // Move by Control
        float h = Input.GetAxisRaw("Horizontal"); 
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse); 


        // MaxSpeed Limit
        if (rigid.velocity.x > maxSpeed)// right
        {
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
            animator.SetBool("is_right", true);
        }
           
        else if (rigid.velocity.x < maxSpeed * (-1))
        {
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
            animator.SetBool("is_right",false);
        }
           

    }
}
