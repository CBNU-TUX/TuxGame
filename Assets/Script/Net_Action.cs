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
    public Text don;

    static public bool isThrowing;

    void Start()
    {
        don.text = gold.ToString();
        animator = GetComponent<Animator>();
        target = GetComponent<Transform>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(opening){
            if (collision.gameObject.tag == "Trashs")
            {
                gold += 50;
                don.text=gold.ToString();
            }
            Debug.Log("충돌");
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && opening == false&&!isThrowing)
        {
            isThrowing=true;
            GameObject.Find("Canvas").transform.GetChild(1).gameObject.SetActive(true);
            animator.SetTrigger("isFishing");
            animator.SetBool("is_open", true);
            Invoke("Status_open", 0.5f);
        }
        else if (Input.GetKey(KeyCode.Space) && opening == true&&!isThrowing)
        {
            Trash_move.isFishing=true;
            animator.SetBool("is_open", false);
            Invoke("Status_close", 0.5f);
        }


    }
    private void Status_open()
    {
        opening=true;
    }
    private void Status_close()
    {
        opening = false;
        Trash_move.isFishing=false;
    }
}