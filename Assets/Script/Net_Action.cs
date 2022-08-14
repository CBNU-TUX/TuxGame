using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Net_Action : MonoBehaviour
{
    // Start is called before the first frame update
    int gold = 0;
    bool opening = false;
    Animator animator;
    Transform target;
    BoxCollider2D box;
    PolygonCollider2D polygon;
    public GameObject col;
    static public bool isThrowing;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GetComponent<Transform>();
        box = GetComponent<BoxCollider2D>();
        polygon = GetComponent<PolygonCollider2D>();
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
        if (Input.GetKey(KeyCode.Space) && opening == false&&!isThrowing)
        {
            polygon.offset = new Vector2(0, 0);
            isThrowing=true;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
            animator.SetTrigger("isFishing");
            animator.SetBool("is_open", true);
            Invoke("Status_open", 0.5f);
        }
        else if (Input.GetKey(KeyCode.Space) && opening == true&&!isThrowing)
        {
            polygon.offset=new Vector2(0, 10);
            FishingController.isFishing=true;
            animator.SetBool("is_open", false);
            Invoke("Status_close", 1f);
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