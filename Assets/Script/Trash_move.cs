using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trash_move : MonoBehaviour
{
    Rigidbody2D rigid;
    //public Text text;
    public int nextMove;
    public int nextMove2;
    public GameObject net;
    GameObject Boat;
    bool isCollider=false;
    static public bool isFishing=false;
    Vector3 offset;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Boat=GameObject.Find("Boat");
        Invoke("Think", 1);
        offset=this.transform.position-Boat.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision) //Net�� ������� �浹�������
    {
        if (collision.gameObject.tag == "Net") 
        {
            rigid.velocity =Vector3.forward;
        }
        if(collision.name=="Collision")
            gameObject.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D collision){
        isCollider=false;
        //isFishing=false;
    }
    void Update(){
        if(isCollider)
            if(isFishing){
                transform.position = Vector3.MoveTowards(gameObject.transform.position,Boat.transform.position, 0.01f);    
            }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(!isCollider){
            rigid.velocity = new Vector2(nextMove, nextMove2);
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);
        nextMove2 = Random.Range(-1, 2);
        if (nextMove == 0 && nextMove2 == 0) 
        {
            Think();
        }
        if(!isCollider){
            Invoke("Think", 1);
        }
    }
}
