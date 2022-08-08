using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Net_Action : MonoBehaviour
{
    // Start is called before the first frame update
    int gold = 0;
    public bool opening = false;
    public Animator animator;
    public Transform target;
    public BoxCollider2D box;
    public Text don;
    void Start()
    {
        don.text = gold.ToString();
        animator = GetComponent<Animator>();
        target = GetComponent<Transform>();
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trashs")
        {
            gold += 50;
            don.text=gold.ToString();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && opening == false)
        {
            animator.SetBool("is_open", true);
            box.size = new Vector2(0.5f, 4f);
            target.localScale = new Vector3(4.2f, 11f, 1f);
            Invoke("Status_open", 0.5f);
        }
        else if (Input.GetKey(KeyCode.Space) && opening == true)
        {
            animator.SetBool("is_open", false);
            box.size = new Vector2(0.5f, 0.3f);
            target.localScale = new Vector3(4.2f, 4.8f, 1f);
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
    }
}