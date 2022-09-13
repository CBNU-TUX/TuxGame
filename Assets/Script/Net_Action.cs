using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Net_Action : MonoBehaviour
{
    // Start is called before the first frame update
    bool opening = false;
    Animator animator;
    Transform target;
    BoxCollider2D box;
    PolygonCollider2D polygon;
    SpriteRenderer spriteRenderer;
    public GameObject col;
    static public bool isThrowing;

    void Start()
    {
        opening = false;
        isThrowing = false;
        animator = GetComponent<Animator>();
        target = GetComponent<Transform>();
        box = GetComponent<BoxCollider2D>();
        polygon = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(opening){
            if (collision.gameObject.tag == "Trashs")
            {
                //collision.gameObject.SetActive(false);
            }
            Debug.Log("충돌");
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        Debug.Log("버그찾기 시작"+opening);
        if (Input.GetKey(KeyCode.Space) && opening == false &&!isThrowing)
        {
            Debug.Log("버그찾기 시작"+"????");
            polygon.offset = new Vector2(0, 0);
            isThrowing=true;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
            spriteRenderer.color = new Color(255, 255, 255, 255);
            SoundManager.instance.platSE("net");
            animator.SetTrigger("isFishing");
            animator.SetBool("is_open", true);
            Invoke("Status_open", 0.5f);
        }
        else if (Input.GetKey(KeyCode.Space) && opening == true&&!isThrowing)
        {
            polygon.offset=new Vector2(0, 10);
            FishingController.isFishing=true;
            spriteRenderer.color = new Color(255, 255, 255, 0);
            SoundManager.instance.platSE("net");
            animator.SetBool("is_open", false);
            Invoke("Status_close", 1f);
            isThrowing=false;
        }
    }
    private void Status_open()
    {
        opening=true;
    }
    private void Status_close()
    {
        opening = false;
        FishingController.isFishing=false;
    }
}